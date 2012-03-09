
// @source core/direct/DirectEvent.js

Ext.net.DirectEvent = new Ext.data.Connection({
    autoAbort : false,
    /*LOCALIZE*/
    confirmTitle : "Confirmation",
    /*LOCALIZE*/
    confirmMessage : "Are you sure?",

    confirmRequest : function (directEventConfig) {
        directEventConfig = directEventConfig || {};
        if (directEventConfig.confirmation && directEventConfig.confirmation.confirmRequest) {
            if (directEventConfig.confirmation.beforeConfirm && directEventConfig.confirmation.beforeConfirm(directEventConfig) === false) {
                Ext.net.DirectEvent.request(directEventConfig);
                return;
            }

            Ext.Msg.confirm(
                directEventConfig.confirmation.title || this.confirmTitle,
                directEventConfig.confirmation.message || this.confirmMessage,
                Ext.Function.bind(this.confirmAnswer, this, [directEventConfig], true),
                this);
        } else {
            Ext.net.DirectEvent.request(directEventConfig);
        }
    },

    confirmAnswer : function (btn, text, buttonConfig, directEventConfig) {
        if (btn == "yes") {
            Ext.net.DirectEvent.request(directEventConfig);
        }
        if (btn == "no" && directEventConfig.confirmation.cancel) {
            directEventConfig.confirmation.cancel(directEventConfig);
        }
    },

    serializeForm : function (form) {
        return Ext.lib.Ajax.serializeForm(form);
    },

    setValue : function (form, name, value) {
        Ext.net.ResourceMgr.initAspInputs();

        var input = null, 
            pe,
            els = Ext.fly(form).select("input[name=" + name + "]");

        if (els.getCount() > 0) {
            input = els.elements[0];
        } else {
            input = document.createElement("input");
            input.setAttribute("name", name);
            input.setAttribute("type", "hidden");
        }

        input.setAttribute("value", value);

        pe = input.parentElement ? input.parentElement : input.parentNode;

        if (Ext.isEmpty(pe)) {
            form.appendChild(input);
        }
    },

    delayedF : function (el, remove) {
        if (!Ext.isEmpty(el)) {
            el.unmask();

            if (remove === true) {
                el.remove();
            }
        }
    },

    showFailure : function (response, errorMsg) {
        var bodySize = Ext.getBody().getViewSize(),
            width = (bodySize.width < 500) ? bodySize.width - 50 : 500,
            height = (bodySize.height < 300) ? bodySize.height - 50 : 300,
            win;

        if (Ext.isEmpty(errorMsg)) {
            errorMsg = response.responseText;
        }

        win = new Ext.window.Window({ 
            modal: true, 
            width: width, 
            height: height, 
            title: "Request Failure", 
            layout: "fit", 
            maximizable: true,            
            items : [{
                xtype:"container",
                layout  : {
                    type: "vbox",
                    align: "stretch"
                },                
                items : [
                    {
                        xtype: "container",
                        height: 42,
                        layout: "absolute",
                        defaultType: "label",
                        items: [
                            {
                                xtype : "component",
                                x    : 5,
                                y    : 5,
                                html : '<div class="x-message-box-error" style="width:32px;height:32px"></div>'
                            },
                            {
                                x    : 42,
                                y    : 6,
                                html : "<b>Status Code: </b>"
                            },
                            {
                                x    : 125,
                                y    : 6,
                                text : response.status
                            },
                            {
                                x    : 42,
                                y    : 25,
                                html : "<b>Status Text: </b>"
                            },
                            {
                                x    : 125,
                                y    : 25,
                                text : response.statusText
                            }  
                        ]
                    },                    
                    {
                        flex: 1,
                        itemId : "__ErrorMessageEditor",
                        xtype    : "htmleditor",
                        value    : errorMsg,
                        readOnly : true,
                        enableAlignments : false,
                        enableColors     : false,
                        enableFont       : false,
                        enableFontSize   : false,
                        enableFormat     : false,
                        enableLinks      : false,
                        enableLists      : false,
                        enableSourceEdit : false
                    }
                ]
            }]
        });
        
        win.show();
    },

    parseResponse : function (response, options) {
        var text = response.responseText,
            result = {},
            exception = false;

        result.success = true;

        try {
            if (/^<\?xml/.test(text)) {
                //xml parsing      
                var xmlData = response.responseXML,
                    root = xmlData.documentElement || xmlData,
                    q = Ext.DomQuery;

                if (root.nodeName == "DirectResponse") {
                    //root = q.select("DirectResponse", root);
                    //success
                    var sv = q.selectValue("Success", root, true),
                        pSuccess = sv !== false && sv !== "false",
                        pErrorMessage = q.selectValue("ErrorMessage", root, ""),
                        pScript = q.selectValue("Script", root, ""),
                        pViewState = q.selectValue("ViewState", root, ""),
                        pViewStateEncrypted = q.selectValue("ViewStateEncrypted", root, ""),
                        pEventValidation = q.selectValue("EventValidation", root, ""),
                        pServiceResponse = q.selectValue("ServiceResponse", root, ""),
                        pUserParamsResponse = q.selectValue("ExtraParamsResponse", root, ""),
                        pResult = q.selectValue("Result", root, "");

                    if (!Ext.isEmpty(pSuccess)) {
                        Ext.apply(result, { success: pSuccess });
                    }

                    if (!Ext.isEmpty(pErrorMessage)) {
                        Ext.apply(result, { errorMessage: pErrorMessage });
                    }

                    if (!Ext.isEmpty(pScript)) {
                        Ext.apply(result, { script: pScript });
                    }

                    if (!Ext.isEmpty(pViewState)) {
                        Ext.apply(result, { viewState: pViewState });
                    }

                    if (!Ext.isEmpty(pViewStateEncrypted)) {
                        Ext.apply(result, { viewStateEncrypted: pViewStateEncrypted });
                    }

                    if (!Ext.isEmpty(pEventValidation)) {
                        Ext.apply(result, { eventValidation: pEventValidation });
                    }

                    if (!Ext.isEmpty(pServiceResponse)) {
                        Ext.apply(result, { serviceResponse: eval("(" + pServiceResponse + ")") });
                    }

                    if (!Ext.isEmpty(pUserParamsResponse)) {
                        Ext.apply(result, { extraParamsResponse: eval("(" + pUserParamsResponse + ")") });
                    }

                    if (!Ext.isEmpty(pResult)) {
                        Ext.apply(result, { result: eval("(" + pResult + ")") });
                    }

                    return { 
                        result    : result, 
                        exception : false 
                    };
                } else {
                    return { 
                        result    : response.responseXML, 
                        exception : false 
                    }; 
                    // root.text || root.textContent;
                }
            }

            //json parsing
            result = eval("(" + text + ")");

        } catch (e) {
            result.success = false;
            exception = true;

            if (response.responseText.length === 0) {
                result.errorMessage = "NORESPONSE";
            } else {
                result.errorMessage = "BADRESPONSE: " + e.message;
                result.responseText = response.responseText;
            }

            response.statusText = result.errorMessage;
        }
        
        if (result && result.d) {
            result = result.d;

            if (Ext.isString(result) && options.isDirectMethod !== true) {
                result = Ext.decode(result);
            }
        }

        return { 
            result    : result, 
            exception : exception 
        };
    },
    
    cacheBusterCheck : function (o) {
        var method = o.method || this.method || ((o.params || o.xmlData || o.jsonData || o.form) ? "POST" : "GET"),
            url = o.url || this.url,
            form = Ext.getDom(o.form);
            
        if (form) {
            url = url || form.action;            
        }
        
        if (method === "POST" && (this.disableCaching && o.disableCaching !== false)) {
            if (Ext.isFunction(url)) {
                url = url.call(o.scope || "window", o);
            }

            var dcp = o.disableCachingParam || this.disableCachingParam;
            o.url = Ext.urlAppend(url, dcp + '=' + (new Date().getTime()));
        }
    },
    
    buildForm : function (o, cmp) {
        o.formCfg = {};
        o.formCfg.action = Ext.ClassManager.instantiateByAlias('formaction.standardsubmit', Ext.apply({}, {form: cmp.getForm()}));
        o.formCfg.form = o.formCfg.action.buildForm();
        o.form = Ext.get(o.formCfg.form);
    },

    listeners : {
        beforerequest : {
            fn : function (conn, options) {
                var o = options || {};

                o.eventType = o.eventType || "event";

                var isInstance = o.eventType == "public",
                    submitConfig = {},
                    forms,
                    aspForm;

                o.extraParams = o.extraParams || {};

                switch (o.eventType) {
                case "event":
                case "bus":
                case "custom":
                case "proxy":
                case "postback":
                case "public":
                    if (isInstance) {
                        o.action = o.name;
                    }

                    o.control = o.control || {};
                    o.type = o.type || "submit";
                    o.viewStateMode = o.viewStateMode || "default";
                    o.action = o.action || "Click";
                    o.headers = Ext.apply(o.headers || {}, { "X-Ext.Net" : "delta=true" });

                    if (o.type == "submit") {
                        o.form = Ext.get(o.formId);

                        if (!Ext.isEmpty(o.form) && !Ext.isEmpty(o.form.id)) {
                            var cmp = Ext.getCmp(o.form.id);

                            if (!Ext.isEmpty(cmp) && cmp.getForm && cmp.submit) {
                                this.buildForm(o, cmp);
                            }
                        }

                        if (Ext.isEmpty(o.form) && !Ext.isEmpty(o.control.el)) {
                            if (Ext.isEmpty(o.control.isComposite) || o.control.isComposite === false) {
                                o.form = o.control.el.up("form");
                                
                                if (Ext.isEmpty(o.form) && o.control.up) {
                                    var formPanel = o.control.up("form");

                                    if (!Ext.isEmpty(formPanel) && formPanel.getForm && formPanel.submit) {
                                        this.buildForm(o, formPanel);
                                    }
                                }
                            } else {
                                o.form = Ext.get(o.control.elements[0]).up("form");
                            }
                        } 
                        
                        if (Ext.isEmpty(o.form) && Ext.isEmpty(o.url) && !Ext.isEmpty(Ext.net.ResourceMgr.aspForm)) {
                            o.form = Ext.get(Ext.net.ResourceMgr.aspForm);
                        }                       
                    } else if (o.type == "load" && Ext.isEmpty(o.method)) {
                        o.method = "GET";
                    }                    
                    
                    if (Ext.isEmpty(o.form) && Ext.isEmpty(o.url)) {
                        if (!Ext.isEmpty(Ext.net.ResourceMgr.aspForm)) {
                            aspForm = Ext.getDom(Ext.net.ResourceMgr.aspForm);
                        }                     

                        if (aspForm) {
                            if (o.type == "submit") {
                                o.form = aspForm;
                            } else {
                                o.url = aspForm.action;
                            }
                        }
                    }

                    var argument = Ext.net.StringUtils.format("{0}|{1}|{2}", o.proxyId || o.control.storeId || o.control.proxyId || o.control.id || "-", o.eventType, o.action);

                    if (!Ext.isEmpty(o.form)) {
                        this.setValue(o.form.dom, "__EVENTTARGET", Ext.net.ResourceMgr.id);
                        this.setValue(o.form.dom, "__EVENTARGUMENT", argument);
                        Ext.getDom(o.form).ignoreAllSubmitFields = true;
                    } else {
                        o.url = o.url || Ext.net.ResourceMgr.url || window.location.href;
                        Ext.apply(submitConfig, { 
                            __EVENTTARGET   : Ext.net.ResourceMgr.id, 
                            __EVENTARGUMENT : argument 
                        });
                    }

                    if (o.viewStateMode != "default") {
                        Ext.apply(submitConfig, { 
                            viewStateMode : o.viewStateMode                             
                        });
                    }
                    
                    if (o.rethrowException) {
                        submitConfig.rethrowException = true;
                    }

                    if (o.before) {
                        if (o.before.call(o.control || window, o.control, o.eventType, o.action, o.extraParams, o) === false) {
                            return false;
                        }
                    }

                    if (this.fireEvent("beforeajaxrequest", o.control, o.eventType, o.action, o.extraParams, o) === false) {
                        return false;
                    }

                    if (!Ext.isEmpty(o.extraParams) && !Ext.isEmptyObj(o.extraParams)) {
                        Ext.apply(submitConfig, { 
                            extraParams : o.extraParams 
                        });
                    }

                    if (!Ext.isEmpty(o.serviceParams)) {
                        Ext.apply(submitConfig, { serviceParams: o.serviceParams });
                    }

                    if (!Ext.isEmpty(submitConfig) && !Ext.isEmptyObj(submitConfig)) {
                        o.params = { submitDirectEventConfig: Ext.encode({ config : submitConfig }) };
                    } else {
                        o.params = {};
                    }

                    if (!Ext.isEmpty(o.form)) {
                        var enctype = Ext.getDom(o.form).getAttribute("enctype");

                        if ((enctype && enctype.toLowerCase() == "multipart/form-data") || o.isUpload) {
                            Ext.apply(o.params, { "__ExtNetDirectEventMarker" : "delta=true" });
                        }
                    }

                    if (o.cleanRequest) {
                        o.params = Ext.apply({}, o.extraParams || {});                        

                        if (o.json) {
                            o.jsonData = o.params;
                            if ((o.method || this.method) !== "GET") {
                                o.params = "";
                            }
                            o.json = false;
                        } else {
							var ov;

                            for (var key in o.params) {
                                ov = o.params[key];

                                if (typeof ov == "object") {
                                    o.params[key] = Ext.encode(ov);
                                }
                            }
                        }
                    }

                    if (!Ext.isEmpty(o.form)) {
                        o.form.dom.action = o.form.dom.action || o.form.action || o.url || Ext.net.ResourceMgr.url || window.location.href;
                    }

                    break;
                case "static":
                    o.headers = { 
                        "X-Ext.Net" : "delta=true,staticmethod=true" 
                    };

                    if (Ext.isEmpty(o.form) && Ext.isEmpty(o.url)) {
                        forms = Ext.select("form").elements;
                        o.url = (forms.length == 1 && !Ext.isEmpty(forms[0].action)) ? forms[0].action : Ext.net.ResourceMgr.url || window.location.href;
                    }

                    if (o.before) {
                        if (o.before(o.control, o.eventType, o.action, o.extraParams) === false) {
                            return false;
                        }
                    }

                    if (this.fireEvent("beforeajaxrequest", o.control, o.eventType, o.action, o.extraParams, o) === false) {
                        return false;
                    }

                    o.params = Ext.apply(o.extraParams, { "_methodName_": o.name });
                    if (o.rethrowException) {
                        o.params._rethrowException_ = true;                   
                    }
                    break;
                }

                o.scope = this;

                //--Common part----------------------------------------------------------

                if (o.disableControl && o.control && Ext.isFunction(o.control.disable)) {
                    o.control.disable();
                }

                var el, em = o.eventMask || {};

                if ((em.showMask === true)) {
                    if (!Ext.isEmpty(em.customTarget, false) && Ext.isEmpty(em.target, false)) {
                        em.target = "customtarget";
                    }
                    switch (em.target || "page") {
                    case "this":
                        if (o.control.getEl) {
                            el = o.control.getEl();
                        } else if (o.control.dom) {
                            el = o.control;
                        }
                        
                        break;
                    case "parent":
                        if (o.control.getEl) {
                            el = o.control.getEl().parent();
                        } else if (o.control.parent) {
                            el = o.control.parent();
                        }
                        
                        break;
                    case "page":
                        var theHeight = "100%";

                        if (window.innerHeight) {
                            theHeight = window.innerHeight + "px";
                        } else if (document.documentElement && document.documentElement.clientHeight) {
                            theHeight = document.documentElement.clientHeight + "px";
                        } else if (document.body) {
                            theHeight = document.body.clientHeight + "px";
                        }

                        el = Ext.getBody().createChild({ 
                            cls : "x-page-mask",
                            style : "position:absolute;left:0;top:0;width:100%;height:" + theHeight + ";z-index:20000;background-color:Transparent;" 
                        });

                        var scroll = Ext.getBody().getScroll();
                        el.setLeftTop(scroll.left, scroll.top);
                        break;
                    case "customtarget":
                        var trg = em.customTarget || "";
                        el = Ext.net.getEl(trg);

                        if (Ext.isEmpty(el)) {
                            el = trg.getEl ? trg.getEl() : null;
                        }

                        break;
                    }

                    if (!Ext.isEmpty(el)) {
                        el.mask(em.msg || Ext.LoadMask.prototype.msg, em.msgCls || Ext.LoadMask.prototype.msgCls);
                        o.maskEl = el;
                    }
                }

                var removeMask = function (o) {
                    if (o.maskEl !== undefined && o.maskEl !== null) {
                        var delay = 0,
                            em = o.eventMask || {},
                            task;

                        if (em && em.minDelay) {
                            delay = em.minDelay;
                        }

                        var remove = (em.target || "page") == "page";

                        task = new Ext.util.DelayedTask(function (o, remove) {
                            o.scope.delayedF(o.maskEl, remove);
                        }, o.scope, [o, remove]).delay(delay);
                    }
                };

                var executeScript = function (o, result, response) {
                    var delay = 0,
                        em = o.eventMask || {};

                    if (em.minDelay) {
                        delay = em.minDelay;
                    }
                    
                    var task = new Ext.util.DelayedTask(
                        function (o, result, response) {
                            if (result.script && result.script.length > 0) {
                                (function (o, result, response) { 
                                    eval(result.script); 
                                }).call(window, o, result, response);
                            }

                            this.fireEvent("ajaxrequestcomplete", response, result, o.control, o.eventType, o.action, o.extraParams, o);

                            if (o.userSuccess) {
                                o.userSuccess.call(o.control || window, response, result, o.control, o.eventType, o.action, o.extraParams, o);
                            }
                            
                            if (o.userComplete) {
                                o.userComplete.call(o.control || window, true, response, result, o.control, o.eventType, o.action, o.extraParams, o);
                            }
                        },
                        o.scope, [o, result, response]).delay(delay);
                };


                o.failure = function (response, options) {
                    var o = options;

                    removeMask(o);

                    if (o.disableControl && o.control && Ext.isFunction(o.control.enable)) {
                        o.control.enable();
                    }
                    
                    if (this.fireEvent("ajaxrequestexception", response, { "errorMessage": response.statusText }, o.control, o.eventType, o.action, o.extraParams, o) === false) {
                        o.cancelFailureWarning = true;
                    }
                    
                    if (o.userFailure) {
                        o.userFailure.call(o.control || window, response, { "errorMessage": response.responseText }, o.control, o.eventType, o.action, o.extraParams, o);
                    } else if (o.showWarningOnFailure !== false && !o.cancelFailureWarning) {
                        o.scope.showFailure(response, "");
                    }
                    
                    if (o.userComplete) {
                        o.userComplete.call(o.control || window, false, response, { "errorMessage": response.statusText }, o.control, o.eventType, o.action, o.extraParams, o);
                    }
                };

                o.success = function (response, options) {
                    var o = options;

                    removeMask(o);

                    if (o.disableControl && o.control && Ext.isFunction(o.control.enable)) {
                        o.control.enable();
                    }

                    var parsedResponse = o.scope.parseResponse(response, options);

                    if (!Ext.isEmpty(parsedResponse.result.documentElement)) {
                        executeScript(o, parsedResponse.result, response);
                        return;
                    }

                    var result = parsedResponse.result,
                        exception = parsedResponse.exception;

                    if (result.success === false) {
                        if (this.fireEvent("ajaxrequestexception", response, result, o.control, o.eventType, o.action, o.extraParams, o) === false) {
                            o.cancelFailureWarning = true;
                        }

                        if (o.userFailure) {
                            o.userFailure.call(o.control || window, response, result, o.control, o.eventType, o.action, o.extraParams, o);
                        } else {
                            if (o.showWarningOnFailure !== false && !o.cancelFailureWarning) {
                                var errorMsg = "";
                                if (!exception && result.errorMessage && result.errorMessage.length > 0) {
                                    errorMsg = result.errorMessage;
                                }
                                o.scope.showFailure(response, errorMsg);
                            }
                        }
                        
                        if (o.userComplete) {
                            o.userComplete.call(o.control || window, false, response, result, o.control, o.eventType, o.action, o.extraParams, o);
                        } 

                        return;
                    }

                    if (!Ext.isEmpty(result.viewState) && o.form !== null) {
                        o.scope.setValue(o.form.dom, "__VIEWSTATE", result.viewState);
                        delete result.viewState;

                        if (!Ext.isEmpty(result.viewStateEncrypted) && o.form !== null) {
                            o.scope.setValue(o.form.dom, "__VIEWSTATEENCRYPTED", result.viewStateEncrypted);
                            delete result.viewStateEncrypted;
                        }

                        if (!Ext.isEmpty(result.eventValidation) && o.form !== null) {
                            o.scope.setValue(o.form.dom, "__EVENTVALIDATION", result.eventValidation);
                            delete result.eventValidation;
                        }
                    }

                    executeScript(o, result, response);
                };
                
                this.cacheBusterCheck(o);                
            }
        }
    }
});

Ext.net.DirectEvent.addEvents("beforeajaxrequest", "ajaxrequestcomplete", "ajaxrequestexception");
                    
Ext.net.DirectEvent.request = Ext.Function.createSequence(Ext.net.DirectEvent.request, function (o) {
    if (!Ext.isEmpty(o.form)) {
        this.setValue(o.form.dom, "__EVENTTARGET", "");
        this.setValue(o.form.dom, "__EVENTARGUMENT", "");
    } 
    
    if (o.formCfg) {
        Ext.removeNode(o.formCfg.form);
        delete o.formCfg;
    }
    
    if (o.after) {
        o.after(o.control, o.extraParams);
    }
});

Ext.net.directRequest = Ext.bind(Ext.net.DirectEvent.confirmRequest, Ext.net.DirectEvent);