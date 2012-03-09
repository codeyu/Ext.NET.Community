
// @source core/tree/TreePanel.js

Ext.net.TreePanel = function (config) {
    Ext.net.TreePanel.superclass.constructor.call(this, config);
};

Ext.extend(Ext.net.TreePanel, Ext.tree.TreePanel, {
    mode : "local",
    
    initNoLeafIcon : function () {
        if (this.noLeafIcon) {
            var css = "#" + this.id + " .x-tree-node-leaf .x-tree-node-icon{background-image: none;width:0px;}";
			Ext.net.ResourceMgr.registerCssClass("treepanel_css_" + this.id, css);        
        }
    },
    
    initComponent : function () {
        Ext.net.TreePanel.superclass.initComponent.call(this);
        this.initEditors();
        this.initChildren(this.nodes);
        this.initNoLeafIcon();
        
        if (Ext.isEmpty(this.selectionSubmitConfig) || this.selectionSubmitConfig.disableAutomaticSubmit !== true) {
            this.getSelectionModel().on("selectionchange", this.updateSelection, this);
            this.on("checkchange", this.updateCheckSelection, this);
        }
        
        if (!this.loader.hasListener("loadexception")) {
            this.loader.on("loadexception", function (loader, node, response) {
                if (Ext.net.DirectEvent.fireEvent("ajaxrequestexception", response, { "errorMessage": response.responseText }, null, null, null, null, null) !== false) {
                    if ((this.directEventConfig || {}).showWarningFailure !== false) {
                        Ext.net.DirectEvent.showFailure(response, response.responseText);
                    }
                }            
            }, this);
        }
        
        this.addEvents({
            "submit"                : true, 
            "submitexception"       : true,
            "beforeremoteaction"    : true,            
            "remoteactionexception" : true,
            "remoteactionrefusal"   : true,
            "remoteactionsuccess"   : true,
            "beforeremotemove"      : true,
            "beforeremoterename"    : true,
            "beforeremoteremove"    : true,
            "beforeremoteinsert"    : true,
            "beforeremoteappend"    : true            
        });
        
        if (this.sorter && !this.sorter.doSort) {
            this.sorter = new Ext.tree.TreeSorter(this, this.sorter);
        }        
		
		if (this.mode === "remote") {
		    this.mode = "local";
		    this.setMode("remote");
		}
		
		this.on("nodedragover", this.onNodeDragOver, this);
    },
    
    //---remote mode section------
    
    setMode : function (mode) {
        if (mode === "remote" && this.mode === "local") {            
            this.localActions = this.localActions || [];
            
            if (this.loader.preloadChildren) {
			    this.loader.on("load", this.onRemoteDoPreload);
		    }
		    
		    if (this.editors) {
			    Ext.each(this.editors, function (editor) {
			        editor.on("complete", this.onRemoteNodeEditComplete, this);
			        editor.on("canceledit", this.onRemoteNodeCancelEdit, this);
			    }, this);			    
		    }
		    
		    if (this.enableDD) {
			    this.on("beforenodedrop", this.onRemoteBeforeNodeDrop, this);			        
		    }
        } else if (mode === "local" && this.mode === "remote") {
            if (this.loader.preloadChildren) {
			    this.loader.un("load", this.onRemoteDoPreload);
		    }
		    
		    if (this.editors) {
			    Ext.each(this.editors, function (editor) {
			        editor.un("complete", this.onRemoteNodeEditComplete, this);
			        editor.un("canceledit", this.onRemoteNodeCancelEdit, this);
			    }, this);			    
		    }
		    
		    if (this.enableDD) {
			    this.un("beforenodedrop", this.onRemoteBeforeNodeDrop, this);
		    }
        }
        
        this.mode = mode;
    },
    
    onRemoteBeforeNodeDrop : function (e) {
		if (this.mode === "local" || this.localActions.indexOf("move") !== -1) {
		    return true;
		}
		
		this.moveNodeRequest(e);
		e.dropStatus = true;
		return false;
	},	
    
    remoteOptions : function (action, node) {
		var dc = this.directEventConfig || {},
		    options = {action : action, node : node, params : {}};
		
		if (this.fireEvent("beforeremoteaction", this, node, options, action) !== false) {
		    dc.userSuccess = this.remoteActionSuccess.createDelegate(this);
            dc.userFailure = this.remoteActionFailure.createDelegate(this);
            dc.extraParams = options.params;
            dc.node = node;
            dc.control = this;
            dc.eventType = "postback";
            dc.action = action;
            
            if (!Ext.isEmpty(this[action + "Url"], false)) {
                dc.url = this[action + "Url"];
                dc.cleanRequest = true;
            }
            
            return dc;
        }
        
        return false;
	},
	
	remoteActionSuccess : function (response, result, context, type, action, extraParams, o) {
		if (o.node) {
			o.node.getUI().afterLoad();
		}
        
        var rParams;
		
		try {
			rParams = result.extraParamsResponse || result.response || (result.d ? result.d.response : {}) || {};
			var responseObj = result.serviceResponse || result.d || result;
            result = { success: Ext.isDefined(responseObj.actionSuccess) ? responseObj.actionSuccess : responseObj.success, msg: responseObj.message };
		} catch (ex) {
			this.fireEvent("remoteactionexception", this, response, ex, o);
			
			if (o.cancelWarningFailure !== true && 
		        (this.directEventConfig || {}).showWarningFailure !== false &&
		        !this.hasListener("remoteactionexception")) {
		        Ext.net.DirectEvent.showFailure(response, result.msg);
		    }
			
			return;
		}
		
		if (result.success === false) {
			this.fireEvent("remoteactionrefusal", this, response, {message: result.msg}, o, rParams);
			
			if (o.action === "raAppend" || o.action === "reInsert") {
			    o.node.parentNode.removeChild(o.node);
			}
			
			return;
		}

		switch (o.action) {
		case "raRename":
			o.node.setText(rParams.ra_newText || rParams.text || Ext.util.Format.htmlDecode(o.raConfig.newText));
		    break;
		case "raRemove":
			o.node.parentNode.removeChild(o.node);
		    break;
		case "raMove":
			if (o.e.point === "append") {
			    o.e.target.expand();
			}
            
            if (!o.e.target.isLoaded || o.loaded) {
			    this.dropZone.completeDrop(o.e);
			} else {
			    o.e.dropNode.remove();
			}
		    break;
		case "raAppend":
		case "raInsert":
		    var id = rParams.ra_id || rParams.id;
		    if (id) {
			    o.node.setId(id);
			}
		
			if (rParams.ra_text || rParams.text) {
			    o.node.setText(rParams.ra_text || rParams.text);
			}
		
			o.node.select();
		    break;
		}
		
		this.fireEvent("remoteactionsuccess", this, o.node, action, o, rParams);
	},
	
	remoteActionFailure : function (response, result, context, type, action, extraParams, o) {
        if (o.node) {
			o.node.getUI().afterLoad();
		}
		
		this.fireEvent("remoteactionexception", this, response, {message: response.statusText}, o);
		
		if (o.cancelWarningFailure !== true && 
            (this.directEventConfig || {}).showWarningFailure !== false &&
	        !this.hasListener("remoteactionexception")) {
	        Ext.net.DirectEvent.showFailure(response, response.responseText);
		}
    },
    
    onRemoteDoPreload : function (loader, node) {
		node.cascade(function (n) {
			loader.doPreload(n);
		});
	},
	
	onRemoteNodeEditComplete : function (editor, value, startValue) {
		if (editor.editNode.isNew) {
		    var insert = editor.editNode.insertAction;

			delete editor.editNode.isNew;
			delete editor.editNode.insertAction;
			
            editor.editNode.setText(value);
			this.appendChildRequest(editor.editNode, insert);

			return;
		}

		this.renameNode(editor.editNode, value);
		return false;
	},
	
	onRemoteNodeCancelEdit : function (editor, value, startValue) {
	    if (editor.editNode.isNew) {		
	        editor.editNode.parentNode.removeChild(editor.editNode);
	    }
	},
	
	performRemoteAction : function (config) {	    
	    if (config.cleanRequest) {
	        if (this.remoteJson) {
	            config.json = true;
	            config.method = "POST";
	        }

	        config.extraParams = Ext.apply(config.extraParams, config.raConfig);
	        config.type = "load";	        
	    } else {
	        config.serviceParams = Ext.encode(config.raConfig);
	    }

        config.node.getUI().beforeLoad();
        Ext.net.DirectEvent.request(config);
	},
	
	moveNodeRequest : function (e) {	
	    if (this.mode === "local" || this.localActions.indexOf("move") !== -1) {
		    return;
		}
		
		var dc = this.remoteOptions("raMove", e.dropNode);
		
		if (dc !== false && this.fireEvent("beforeremotemove", this, e.dropNode, e.target, e, dc.extraParams) !== false) {
		    dc.e = e;
		    dc.loaded = e.target.loaded || e.target.loading;
		    dc.raConfig = {
	            id       : e.dropNode.id,
	            targetId : e.target.id,
	            point    : e.point
	        };
	        
	        this.performRemoteAction(dc); 
		}
	},
	
	convertText : function (text) {
	    if (text == "&#160;") {
	        return "";
	    }
	    
	    return Ext.util.Format.htmlEncode(text);
	},
	
	renameNode : function (node, newText) {
		if (this.mode === "local" || this.localActions.indexOf("rename") !== -1) {
		    node.setText(newText);
		    return;
		}
		
		var dc = this.remoteOptions("raRename", node);
		
		if (dc !== false && this.fireEvent("beforeremoterename", this, node, dc.extraParams) !== false) {
		    dc.raConfig = {
	            id      : node.id,
	            newText : this.convertText(newText),
	            oldText : this.convertText(node.text)
	        };
	        
	        this.performRemoteAction(dc); 
		}
	},
	
	removeNode : function (node) {
		if (node.isRoot) {
			return;
		}
		
		if (this.mode === "local" || this.localActions.indexOf("remove") !== -1) {
		    node.parentNode.removeChild(node);
		    return;
		}
		
		var dc = this.remoteOptions("raRemove", node);
		
		if (dc !== false && this.fireEvent("beforeremoteremove", this, node, dc.extraParams) !== false) {
		    dc.raConfig = {
	            id : node.id
	        };
	        
	        this.performRemoteAction(dc);
		}
	},
	
	appendChildRequest : function (node, insert) {
        if (this.mode === "local" || this.localActions.indexOf(insert ? "insert" : "append") !== -1) {
		    return;
		}
		
		var dc = this.remoteOptions("ra" + (insert ? "Insert" : "Append"), node);
		
		if (dc !== false && this.fireEvent("beforeremote" + (insert ? "insert" : "append"), this, node, dc.extraParams, insert) !== false) {
		    dc.raConfig = {
	            id       : node.id,
	            parentId : node.parentNode.id,
	            text     : this.convertText(node.text)
	        };
	        
	        this.performRemoteAction(dc);
		}
	},
	
	//---end remote mode section
	
	onNodeDragOver : function (e) {
		if (this.allowLeafDrop) {
			e.target.leaf = false;
		}
	},
	
	appendChild : function (parentNode, defaultText, insert, index) {
		var node = parentNode,
		    nodeAttr = {},
		    child;
		    
		node.leaf = false;
		node.expand(false, false);
		
		if (Ext.isString(defaultText)) {
		    nodeAttr = {text: defaultText || "", loaded: true};
		} else {
		    nodeAttr = Ext.applyIf(defaultText, {text: "", loaded: true});
		}
		
		if (insert) {
			var beforeNode = index ? node.childNodes[index] : node.firstChild;
			child = node.insertBefore(this.loader.createNode(nodeAttr), beforeNode);
		} else {
			child = node.appendChild(this.loader.createNode(nodeAttr));
		}

		child.isNew = true;
		child.insertAction = insert;
		
		this.startEdit(child);
	},
	
	insertBefore : function (node, defaultText) {
		var nodeAttr = {},
		    child;	
		    
		if (Ext.isString(defaultText)) {
		    nodeAttr = {text: defaultText || "", loaded: true};
		} else {
		    nodeAttr = Ext.applyIf(defaultText, {text: "", loaded: true});
		}	    
		    
		child = node.parentNode.insertBefore(this.loader.createNode(nodeAttr), node);

		child.isNew = true;
		child.insertAction = true;
		
		this.startEdit(child);
	},
    
    startEdit : function (node, defer) {
        if (typeof node === "string") {
            node = this.getNodeById(node);
        }
        
        node.select();
        
        if (this.editors) {
            Ext.each(this.editors, function (ed) {
                ed.beforeNodeClick(node, undefined, defer);
            }, this);            
        }
    },
    
    completeEdit : function () {
        if (this.editors) {
            Ext.each(this.editors, function (ed) {
                ed.completeEdit();
            }, this);            
        }
    },
    
    cancelEdit : function () {
        if (this.editors) {
            Ext.each(this.editors, function (ed) {
                ed.cancelEdit();
            }, this);            
        }
    },
    
    onRender : function (ct, position) {
        Ext.net.TreePanel.superclass.onRender.call(this, ct, position);
        
        if (Ext.isEmpty(this.selectionSubmitConfig) || this.selectionSubmitConfig.disableAutomaticSubmit !== true) {
            this.getSelectionModelField().render(this.el.parent() || this.el);
            this.getCheckNodesField().render(this.el.parent() || this.el);
        }
    },
    
    initEditors : function () {
        if (this.editors) {
            if (!Ext.isArray(this.editors)) {
                this.editors = [this.editors];
            }            
                
            Ext.each(this.editors, function (editor, index) {
                editor.tree = this;
                this.editors[index] = new Ext.net.TreeEditor(editor);
            }, this);
        }
    },

    initChildren : function (nodes) {
        if (!Ext.isEmpty(nodes) && nodes.length > 0) {
            var root = nodes[0],
                rootNode = this.createNode(root);
                
            this.setRootNode(rootNode);

            if (root.children) {
                rootNode.beginUpdate();
                this.setChildren(root, rootNode);
                rootNode.endUpdate();
            }
        }
    },

    setChildren : function (parent, node) {
        for (var i = 0; i < parent.children.length; i++) {

            var child = parent.children[i],
                childNode = this.createNode(child);

            node.appendChild(childNode);

            if (child.children) {
                this.setChildren(child, childNode);
            }
        }
    },

    createNode : function (config) {
        var type = config.nodeType || "node";
        
        if (this.loader.baseAttrs) {
            Ext.applyIf(config, this.loader.baseAttrs);
        }

        if (Ext.isString(config.uiProvider)) {
            config.uiProvider = this.loader.uiProviders[config.uiProvider] || eval(config.uiProvider);
        }
        
        if (config.nodeType) {
            return new Ext.tree.TreePanel.nodeTypes[config.nodeType](config);
        } else {
            if (type == "node" || config.leaf) {
                return new Ext.tree.TreeNode(config);
            }
        }

        return new Ext.tree.AsyncTreeNode(config);
    },
    
    getSelectionModelField : function () {
        if (!this.selectionModelField) {
            this.selectionModelField = new Ext.form.Hidden({ id : this.id + "_SM", name : this.id + "_SM" });

			this.on("beforedestroy", function () { 
                if (this.rendered) {
                    this.destroy();
                }
            }, this.selectionModelField);
        }
        
        return this.selectionModelField;
    },
    
    getCheckNodesField : function () {
        if (!this.checkNodesField) {
            this.checkNodesField = new Ext.form.Hidden({ id : this.id + "_CheckNodes", name : this.id + "_CheckNodes" });

			this.on("beforedestroy", function () { 
                if (this.rendered) {
                    this.destroy();
                }
            }, this.checkNodesField);
        }
        
        return this.checkNodesField;
    },
    
    excludeAttributes : [
        "expanded", 
        "allowDrag", 
        "allowDrop", 
        "disabled", 
        "icon",
        "cls", 
        "loader",
        "children",
        "iconCls", 
        "href", 
        "hrefTarget", 
        "qtip", 
        "singleClickExpand", 
        "uiProvider"
    ],
    
    defaultAttributeFilter : function (attrName, attrValue) {
        return typeof attrValue != "function" && this.excludeAttributes.indexOf(attrName) == -1;
    },
    
    defaultNodeFilter : function (node) {
        return true;
    },
    
    serializeTree : function (config) {    
	    config = config || {};
        if (Ext.isEmpty(config.withChildren)) {
            config.withChildren = true;
        }
        
	    return Ext.encode(this.convertToSubmitNode(this.getRootNode(), config));	    
    },
    
    convertToSubmitNode : function (node, config) {
        config = config || {};
        
        if (!config.prepared) {
	        config.attributeFilter = config.attributeFilter || this.defaultAttributeFilter.createDelegate(this);
	        config.nodeFilter = config.nodeFilter || this.defaultNodeFilter.createDelegate(this);
	        config.prepared = true;
	    }
        
        if (!config.nodeFilter(node)) {
	        return;
	    }
        
        var sNode = {}, 
            path = node.getPath(config.pathAttribute || "id"), 
            deleteAttrs = true;
        
        if (config.attributeFilter("id", node.id)) {
            sNode.nodeID = node.id;
        }
        
        if (config.attributeFilter("text", node.text)) {
            sNode.text = config.encode ? Ext.util.Format.htmlEncode(node.text) : node.text;
        }
        
        if (config.attributeFilter("path", path)) {
            sNode.path = path;
        }
        
        sNode.attributes = {};
        
        for (var attr in node.attributes) {
            if (attr == "id" || attr == "text") {
                continue;
            }
        
            var attrValue = node.attributes[attr];
        
            if (config.attributeFilter(attr, attrValue)) {
                sNode.attributes[attr] = attrValue;
                deleteAttrs = false;
            }
        }
        
        if (deleteAttrs) {
            delete sNode.attributes;
        }
        
        if (config.withChildren) {
            var children = node.childNodes;
            
	        if (children.length !== 0) {
	            sNode.children = [];
	            
	            for (var i = 0; i < children.length; i++) {
	                var cNode = this.convertToSubmitNode(children[i], config);
	               
	                if (!Ext.isEmpty(cNode)) {
	                    sNode.children.push(cNode);
	                }
	            }
	            
	            if (sNode.children.length === 0) {
	                delete sNode.children;
	            }
	        }
	    }
        
        return sNode;
    },
    
    getSelectedNodes : function (config) {
        var sm = this.getSelectionModel();
        if (!sm.selMap) {
            if (sm.selNode) {
                return this.convertToSubmitNode(sm.selNode, config);
            }
            return;
        }
        
        if (Ext.isEmpty(sm.selNodes)) {
            return [];
        }
        
        var selNodes = [];
        
        Ext.each(sm.selNodes, function (node) {
            selNodes.push(this.convertToSubmitNode(node, config));
        }, this);
        
        return selNodes;
    },
    
    getCheckedNodes : function (config) {
        var checkedNodes = this.getChecked();
        
        if (Ext.isEmpty(checkedNodes)) {
            return [];
        }
        
        var nodes = [];
        
        Ext.each(checkedNodes, function (node) {
            nodes.push(this.convertToSubmitNode(node, config));
        }, this);
        
        return nodes;
    },
    
    updateSelection : function () {      
        this.selectionSubmitConfig = this.selectionSubmitConfig || {};
        
        if (Ext.isEmpty(this.selectionSubmitConfig.withChildren)) {
            this.selectionSubmitConfig.withChildren = false;
        }
        
        var selection = this.getSelectedNodes(this.selectionSubmitConfig);  
        
        if (!Ext.isEmpty(selection)) {
            this.getSelectionModelField().setValue(Ext.encode(selection));
        } else {
            this.getSelectionModelField().setValue("");
        }
    },
    
    updateCheckSelection : function () {      
        this.selectionSubmitConfig = this.selectionSubmitConfig || {};
        
        if (Ext.isEmpty(this.selectionSubmitConfig.withChildren)) {
            this.selectionSubmitConfig.withChildren = false;
        }
        
        var selection = this.getCheckedNodes(this.selectionSubmitConfig);  
        
        if (!Ext.isEmpty(selection)) {
            this.getCheckNodesField().setValue(Ext.encode(selection));
        } else {
            this.getCheckNodesField().setValue("");
        }
    },
    
    submitNodes : function (config) {
        var nodes = this.serializeTree(config),
            ac = Ext.apply(this.directEventConfig || {}, config);

        if (ac.params) {
            ac.extraParams = ac.params;
            delete ac.params;
        }
        
        if (ac.callback) {
            ac.userCallback = ac.callback;
            delete ac.callback;
        }
        
        if (ac.scope) {
            ac.userScope = ac.scope;
            delete ac.scope;
        }
        
        Ext.apply(ac, {
            control       : this,
            eventType     : "postback",
            action        : "submit",
            serviceParams : nodes,
            userSuccess   : this.submitSuccess,
            userFailure   : this.submitFailure
        });

        Ext.net.DirectEvent.request(ac);
    },
    
    submitFailure : function (response, result, context, type, action, extraParams, o) {
        var msg = { message : result.errorMessage || response.statusText };
        
        if (o && o.userCallback) {
            o.userCallback.call(o.userScope || context, o, false, response);
        }
        
        if (!context.hasListener("submitexception")) {
            if (o.showWarningOnFailure !== false && o.cancelFailureWarning !== true) {
                Ext.net.DirectEvent.showFailure(response, msg.message);
            }
        }
        
        context.fireEvent("submitexception", context, o, response, msg);
    },

    submitSuccess : function (response, result, context, type, action, extraParams, o) {
        try {
            var responseObj = result.serviceResponse;
            result = { success: responseObj.success, msg: responseObj.message };
        } catch (e) {
            if (o && o.userCallback) {
                o.userCallback.call(o.userScope || context, o, false, response);
            }
            
            if (Ext.net.DirectEvent.fireEvent("ajaxrequestexception", {}, { "errorMessage" : e.message }, null, null, null, null, o) !== false) {
                if (!context.hasListener("submitexception")) {
                    if (o.showWarningOnFailure !== false) {
                        Ext.net.DirectEvent.showFailure(response, e.message);
                    }
                }
            }             
            
            context.fireEvent("submitexception", context, o, response, e);
            
            return;
        }

        if (!result.success) {
            if (o && o.userCallback) {
                o.userCallback.call(o.userScope || context, o, false, response);
            }
            
            if (Ext.net.DirectEvent.fireEvent("ajaxrequestexception", {}, { "errorMessage" : result.msg }, null, null, null, null, o) !== false) {
                if (!context.hasListener("submitexception")) {
                    if (o.showWarningOnFailure !== false) {
                        Ext.net.DirectEvent.showFailure(response, result.msg);
                    }
                }
            }           
            
            context.fireEvent("submitexception", context, o, response, { message : result.msg });
            
            return;
        }

        if (o && o.userCallback) {
            o.userCallback.call(o.userScope || context, o, true, response);
        }
        
        context.fireEvent("submit", context, o);
    },
    
    filterBy : function (fn, config) {
		config = config || {};
		var startNode = config.startNode || this.root;
		
		if (config.autoClear) {
			this.clearFilter();
		}
		
		var af = this.filtered;

		var f = function (n) {
			if (n === startNode) {
				return true;
			}
			
			if (af[n.id]) {
				return false;
			}
			
			var m = fn.call(config.scope || n, n);
			
			if (!m) {
				af[n.id] = n;
				n.ui.hide();
			} else {
				n.ui.show();
				
				n.bubble(function (p) {
				    if (p.id === this.root.id) {
				        return false;
				    }
				    
				    p.ui.show();
				}, this);
			}
			
			return true;
		};
		
		startNode.cascade(f, this);	
		
		if (config.expandNodes !== false) {
		    startNode.expand(true, false);
		}
		
        if (config.remove) {
            for (var id in af) {
                if (typeof id != "function") {
                    var n = af[id];

                    if (n && n.parentNode) {
                        n.parentNode.removeChild(n);
                    }
                }
            } 
        }
	},
	
    clearFilter : function () {
        var af = this.filtered || {};
        
        for (var id in af) {
            if (typeof id != "function") {
                var n = af[id];
                
                if (n) {
                    n.ui.show();
                }
            }
        }
        
        this.filtered = {};
    },
    
    toggleChecked : function (startNode, value) {
        startNode = startNode || this.root;
 
        var f = function () {
            if (this.getUI().rendered) {
                this.getUI().toggleCheck(Ext.isDefined(value) ? value : !this.attribute.checked);
            } else {
                this.attributes.checked = Ext.isDefined(value) ? value : !this.attribute.checked;
            }
        };
        startNode.cascade(f);
    },
    
    clearChecked : function (startNode) {
        this.toggleChecked(startNode, false);
    },
    
    setAllChecked : function (startNode) {
        this.toggleChecked(startNode, true);
    },
    
    // cfg : (required)ids, (optional)value, (optional)keepExisting, (optional)silent
    setChecked : function (cfg) {
        cfg = cfg || {};
        
        if (cfg.silent) {
            this.suspendEvents();
        }
        
        if (cfg.keepExisting !== true) {
            this.clearChecked();
        }      
        
        cfg.value = Ext.isDefined(cfg.value) ? cfg.value : true;
        
        for (var i = 0, l = cfg.ids.length; i < l; i++) {
            var node = this.getNodeById(cfg.ids[i]);
            
            if (node.getUI().rendered) {
                node.getUI().toggleCheck(cfg.value);
            } else {
                node.attributes.checked = cfg.value;
            }
        } 
        
        if (cfg.silent) {
            this.resumeEvents();
        }
    }        
});

Ext.reg("nettreepanel", Ext.net.TreePanel);