
// @source core/net/ResourceMgr.js

Ext.net.ResourceMgr = function () {
    return {
        id    : "",
        url   : "",
        theme : "blue",
        quickTips       : true,
        cssClasses      : {},
        submitDisabled  : true,
        BLANK_IMAGE_URL : "",
        aspInputs       : [],
        ns : "App",
        
        initAspInputs : function (inputs) {
            if (this.inputsInit) {
                return;
            }

            inputs = Ext.applyIf(inputs, {
                "__EVENTTARGET": "",
                "__EVENTARGUMENT": ""
            });
            
            Ext.iterate(inputs, function (key, value) {
                this.aspInputs.push(Ext.core.DomHelper.append(this.getAspForm() || Ext.getBody(), {
                    tag : "input",
                    type : "hidden",
                    name : key,
                    value : value
                }));
            }, this);
            
            this.inputsInit = true;            
        },

        resolveUrl : function (url) {
            if (url && Ext.net.StringUtils.startsWith(url, "~/")) {                
                return url.replace(/^~/, Ext.isEmpty(this.appName, false) ? "" : ("/"+this.appName))
            }

            return url;
        },

        hasCssClass : function (id) {
            return !!this.cssClasses[id];
        },

        registerCssClass : function (id, cssClass, /*private*/registerId) {
            if (!this.hasCssClass(id)) {                
                if (!this.resourcesSheet) {
                    this.resourcesSheet = Ext.util.CSS.createStyleSheet("/* Ext.Net resources stylesheet */\n", "extnet-resources");
                }

                if (!Ext.isIE) {
					var csssplitregexp = /([^{}]+)\{([^{}]+)+\}/img,
                        match = csssplitregexp.exec(cssClass);

                    while (match != null) {	                    
                        this.resourcesSheet.insertRule(match[0], this.resourcesSheet.cssRules.length);
	                    match = csssplitregexp.exec(cssClass);
                    }                    
				} else {					
					document.styleSheets["extnet-resources"].cssText += cssClass;
				}

				Ext.util.CSS.refreshCache();

                if (registerId !== false) {
                    this.cssClasses[id] = true;
                }
            }
        },

        // private
        toCharacterSeparatedFileName : function (name, separator) {
            if (Ext.isEmpty(name, false)) {
                return;
            }

            var matches = name.match(/([A-Z]+)[a-z]*|\d{1,}[a-z]{0,}/g);

            var temp = "";

            for (var i = 0; i < matches.length; i++) {
                if (i !== 0) {
                    temp += separator;
                }

                temp += matches[i].toLowerCase();
            }

            return temp;
        },

        getIcon : function (icon) {
            this.registerIcon(icon);
            icon = icon.toLowerCase();

            return !Ext.net.StringUtils.startsWith(icon, "icon-") ? ("icon-" + icon) : icon;
        },

        getRenderTarget : function () {
            return Ext.net.ResourceMgr.getAspForm() || Ext.getBody();
        },

        setIconCls : function (cmp, propertyName) {
            var val = cmp[propertyName];

            if (val && Ext.isString(val) && val.indexOf('#') === 0) {
                cmp[propertyName] = this.getIcon(val.substring(1));
            }
        },

        getIconUrl : function (icon) {
            var iconName = this.toCharacterSeparatedFileName(icon, "_"),                
                template = "/{0}icons/{1}-png/ext.axd",
                appName = Ext.isEmpty(this.appName, false) ? "" : (this.appName + "/");

            return Ext.net.StringUtils.format(template, appName, iconName);
        },

        registerIcon : function (name, init) {
            var buffer = [],
                templateEmb = ".{0}{background-image:url(\"/{1}icons/{2}-png/ext.axd\") !important;}",
                templateCdn = ".{0}{background-image:url(\"{1}/icons/{2}.png\") !important;}",
                appName = Ext.isEmpty(this.appName, false) ? "" : (this.appName + "/");

            Ext.each(name, function (icon) {
                if (!Ext.isObject(icon)) {
                    icon = { name: icon };
                }

                var iconName = this.toCharacterSeparatedFileName(icon.name, "_"),
                    iconRule = icon.name.toLowerCase(),
                    id = !Ext.net.StringUtils.startsWith(iconRule, "icon-") ? ("icon-" + iconRule) : iconRule;

                if (!this.hasCssClass(id)) {
                    if (icon.url) {
                        buffer.push(Ext.net.StringUtils.format(".{0}{background-image:url(\"{1}\") !important;}", id, icon.url));
                    } else {
                        if (this.cdnPath) {
                            buffer.push(Ext.net.StringUtils.format(templateCdn, id, this.cdnPath, iconName));
                        } 
                        else {
                            buffer.push(Ext.net.StringUtils.format(templateEmb, id, appName, iconName));
                        }                        
                    }

                    this.cssClasses[id] = true;
                }
            }, this);

            if (buffer.length > 0) {
                this.registerCssClass("", buffer.join(" "), false);
            }
        },
        
        getCmp : function (id) {
            var d = id.split("."),
                o = window[d[0]];

            Ext.each(d.slice(1), function (v) {
                if (!o) {
                   return null;
                }

                o = o[v];
            });
            
            return o ? Ext.getCmp(o.id) || o : null;
        },

        destroyCmp : function (id) {
            var obj = Ext.getCmp(id) || window[id];
            
            if (!Ext.isObject(obj) || (!obj.destroy && !obj.destroyStore)) {
                obj = Ext.net.ResourceMgr.getCmp(id);
            } 

            if (Ext.isObject(obj) && (obj.destroy || obj.destroyStore)) {
                try {
                    obj.destroyStore ?  obj.destroyStore() : obj.destroy();
                } catch (e) { }
            }
        },

        init : function (config) {
            window.X = window.Ext;
            window.X.net.RM = this;
            Ext.apply(this, config || {});

            if (this.quickTips !== false) {
                Ext.QuickTips.init();
            }

            if (Ext.isIE6 || Ext.isIE7 || Ext.isAir) {
                if (Ext.isEmpty(this.BLANK_IMAGE_URL)) {
                    Ext.BLANK_IMAGE_URL =  (Ext.isEmpty(this.appName, false) ? "" : ("/"+this.appName)) + "/extjs/resources/themes/images/default/s-gif/ext.axd";
                } else {
                    Ext.BLANK_IMAGE_URL = this.BLANK_IMAGE_URL;
                }
            }

            this.registerPageResources();

            if (this.theme) {
                if (Ext.isReady) {
                    Ext.getBody().addCls("x-theme-" + this.theme);
                }
                else {
                    Ext.onReady(function () {
                        Ext.getBody().addCls("x-theme-" + this.theme);
                    }, this);
                }
            }

            if (this.icons) {
                this.registerIcon(this.icons, true);
            }

            if (!Ext.isEmpty(this.ns)) {
                if (Ext.isArray(this.ns)) {
                    Ext.each(this.ns, function (ns) {
                        if (ns) {
                            Ext.ns(ns);
                        }
                    });
                } else {
                    Ext.ns(this.ns);
                }
            }

            Ext.onReady(function () {
                if (!this.inputsInit) {
                    this.initAspInputs({});
                }
            }, this, {delay:10});            
        },

        registerPageResources : function () {
            Ext.select("script").each(function (el) {
                var url = el.dom.getAttribute("src");

                if (!Ext.isEmpty(url) && !this.queue.contains(url)) {
                    this.queue.buffer.push({
                        url: url,
                        loading: false
                    });
                }
            }, this);

            Ext.select("link[type=text/css]").each(function (el) {
                var url = el.dom.getAttribute("href");

                if (!Ext.isEmpty(url) && !this.queue.contains(url)) {
                    this.queue.buffer.push({
                        url: url,
                        loading: false
                    });
                }
            }, this);
        },

        getAspForm : function (dom) {
            if (this.aspForm) {
                return Ext[dom ? "getDom" : "get"](this.aspForm);
            }
        },

        load : function (config, groupCallback) {
            this.queue.clear();

            if (groupCallback) {
                groupCallback = {
                    fn: groupCallback,
                    counter: config.length || 1,
                    config: config,
                    step : function () {
                        this.counter--;

                        if (this.counter === 0) {
                            this.fn.apply(window, [this.config]);
                        }
                    }
                };
            }

            Ext.each(Ext.isArray(config) ? config : [config], function (config) {
                if (Ext.isString(config)) {
                    var url = config;

                    config = { url: url };

                    if (url.substring(url.length - 4) === ".css") {
                        config.mode = "css";
                    }
                }

                config.options = Ext.applyIf(config.options || {}, {
                    mode: config.mode || "js"
                });

                if (config.callback) {
                    config.loadCallback = config.callback;
                    delete config.callback;
                }

                if (groupCallback) {
                    config.groupCallback = groupCallback;
                }

                if (!Ext.isEmpty(config.url)) {
                    this.queue.enqueue(config);
                }
            }, this);

            this.doLoad();
        },

        // private
        doLoad : function () {
            var config = this.queue.peek();

            if (config === undefined) {
                return;
            }

            var url = config.url,
                item,
                contains = this.queue.contains(url);

            if (config.force === true || contains !== true) {
                if (contains !== true) {
                    this.queue.buffer.push({
                        url: url,
                        loading: true
                    });
                }

                Ext.Ajax.request(Ext.apply({
                    scope: this,
                    method: "GET",
                    callback: this.onResult,
                    disableCaching: false
                }, config));
            } else {
                item = this.queue.getItem(url);

                if (item && item.loading) {
                    this.queue.waitingList.push(config);
                    return;
                }

                if (config.loadCallback) {
                    config.loadCallback.apply(window, [config]);
                }

                if (config.groupCallback) {
                    config.groupCallback.step();
                }

                this.queue.dequeue(config);
                this.doLoad();
            }
        },

        // private
        onResult : function (options, success, response) {
            if (success === true) {
                if (options.mode === "css") {
                    Ext.util.CSS.createStyleSheet(response.responseText);
                } else {
                    var head = document.getElementsByTagName("head")[0],
                        el = document.createElement("script");

                    el.setAttribute("type", "text/javascript");
                    el.text = response.responseText;

                    head.appendChild(el);
                }

                var i = 0,
                    item = this.queue.getItem(options.url);

                if (item !== null) {
                    item.loading = false;
                }

                if (options.loadCallback) {
                    options.loadCallback.apply(window, [options]);
                }

                if (options.groupCallback) {
                    options.groupCallback.step();
                }

                while (this.queue.waitingList.length > i) {
                    item = this.queue.waitingList[i];

                    if (item.url === options.url) {
                        if (item.loadCallback) {
                            item.loadCallback.apply(window, [item]);
                        }

                        if (item.groupCallback) {
                            item.groupCallback.step();
                        }

                        this.queue.waitingList.remove(item);
                    } else {
                        i++;
                    }
                }
            }

            this.queue.dequeue(options);

            this.doLoad();
        },

        // private
        queue : function () {
            // first-in-first-out
            return {
                // private
                js: [],

                // private
                css: [],

                // private
                buffer: [],

                waitingList: [],

                enqueue : function (item) {
                    this[item.options.mode].push(item);
                },

                dequeue : function (item) {
                    var mode = item.options.mode,
                        temp = this[mode][0];

                    this[mode] = this[mode].slice(1);

                    return temp;
                },

                clear : function () {
                    this.js = [];
                    this.css = [];
                },

                contains : function (url) {
                    // workaround, need more universal fix
                    url = url.replace("&amp;", "&");
                    for (var i = 0; i < this.buffer.length; i++) {
                        if (this.buffer[i].url.replace("&amp;", "&") === url) {
                            return true;
                        }
                    }

                    return false;
                },

                getItem : function (url) {
                    for (var i = 0; i < this.buffer.length; i++) {
                        if (this.buffer[i].url === url) {
                            return this.buffer[i];
                        }
                    }

                    return null;
                },

                peek : function () {
                    return this.css.length > 0 ? this.css[0] : this.js[0];
                }
            };
        } (),

        setTheme : function (url, name) {
            var html = Ext.get(document.getElementsByTagName("html")[0]);

            if (this.theme) {
                html.removeCls("x-theme-" + this.theme);
            }

            if (name) {
                this.theme = name;
                html.addCls("x-theme-" + this.theme);
            }

            Ext.util.CSS.swapStyleSheet("ext-theme", url);
        },
        
        notifyScriptLoaded : function () {
            if (typeof Sys !== "undefined" && 
                typeof Sys.Application !== "undefined" && 
                typeof Sys.Application.notifyScriptLoaded !== "undefined") {

                Sys.Application.notifyScriptLoaded();    
            }
        }       
    };
} ();