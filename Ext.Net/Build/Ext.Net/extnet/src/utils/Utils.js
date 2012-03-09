
// @source core/utils/Utils.js

/**
 * Determines if the object is empty
 * @param {object} obj The object to test if empty.
 * @return {Boolean} Returns true|false
 */
Ext.isEmptyObj = function (obj) {
    if (typeof(obj) === "undefined" || obj === null) {
        return true;
    }
    
    if (!(!Ext.isEmpty(obj) && typeof obj == "object")) {
        return false;
    }

    for (var p in obj) {
        return false;
    }
    
    return true;
};

Ext.net.clone = function (o) {
    if (!o || "object" !== typeof o) {
        return o;
    }
    
    var c = "[object Array]" === Object.prototype.toString.call(o) ? [] : {},
        p, 
        v;
    
    for (p in o) {
        if (o.hasOwnProperty(p)) {
            v = o[p];
            c[p] = (v && "object" === typeof v) ? Ext.net.clone(v) : v;
        }
    }
    
    return c;
};

Ext.net.on = function (target, eventName, handler, scope, mode, cfg) {
    var el = target;
    
    if (typeof target == "string") {
        el = Ext.get(target);
    }

    if (!Ext.isEmpty(el)) {
        if (mode && mode == "client") {
            el.on(eventName, handler.fn, scope, handler);
        } else {
            el.on(eventName, handler, scope, cfg);
        }
    }
};

Ext.net.lazyInit = function (controls) {
    if (!Ext.isArray(controls)) { 
        return; 
    }
    
    var cmp, i;
    
    for (i = 0; i < controls.length; i++) {
        cmp = Ext.getCmp(controls[i]);
        
        if (!Ext.isEmpty(cmp)) {
            window[controls[i]] = cmp;
        }
    }
};

Ext.net.getEl = function (el, skipDeep) {
    if (Ext.isEmpty(el, false)) {
        return null;
    }
    
    if (el.isComposite) {
        return el;
    }
    
    if (el.getEl) {
        return el.getEl();
    }

    if (el.el) {
        return el.el;
    }

    var cmp = Ext.getCmp(el);
    
    if (!Ext.isEmpty(cmp)) {
        return cmp.getEl();
    }

    var tEl = Ext.get(el);
    
    if (Ext.isEmpty(tEl) && skipDeep !== true) {
        try {
            return Ext.net.getEl(eval("(" + el + ")"), true);
        } catch (e) {}
    }
    
    return tEl;
};

Ext.net.replaceContent = function (cmp, contentEl, html) {
    contentEl = Ext.net.getEl(contentEl);
    
    if (!Ext.isEmpty(contentEl)) {
        contentEl.remove();
    }
    
    var el = Ext.net.append(Ext.getBody(), html);
    
    el.removeCls(["x-hidden", "x-hide-display"]);
    cmp.getContentTarget().dom.appendChild(el.dom);        
};

Ext.net.replaceWith = function (config) {
    var id = Ext.String.format("el_{0}_container", config.id || ""),
        el = Ext.fly(id) || Ext.fly(config.id);
    
    if (!Ext.isEmpty(el)) {
        el.replaceWith({ 
            id  : id, 
            tag : "span" 
        }).update(config.html, true);
    }
};

Ext.net.addTo = function (container, items) {
    if (Ext.isString(container)) {
        var cmp = Ext.getCmp(container);

        if (!cmp) {
            cmp = Ext.net.ResourceMgr.getCmp(container);
        }

        container = cmp;
    }

    container.add(items);
};

Ext.net.renderTo = function (container, items) {
    if (Ext.isString(container)) {
        container = Ext.net.getEl(container);
    }

    Ext.each(items, function (item) {
        item.renderTo = container;

        Ext.ComponentManager.create(item);
    });
};

Ext.net.append = function (elTo, html) {
    html = html || "";

    var id = Ext.id(),
        dom = Ext.getDom(elTo);

    html += '<span id="' + id + '"></span>';

    var interval = setInterval(function () {
		if (!document.getElementById(id)) {
			return false;
		}
		clearInterval(interval);
        var DOC = document,
            hd = DOC.getElementsByTagName("head")[0],
            re = /(?:<script([^>]*)?>)((\n|\r|.)*?)(?:<\/script>)/ig,
            reStyle = /(?:<style([^>]*)?>)((\n|\r|.)*?)(?:<\/style>)/ig,
            reLink = /(?:<link([^>]*)?\/>)/ig,
            srcRe = /\ssrc=([\'\"])(.*?)\1/i,
            typeRe = /\stype=([\'\"])(.*?)\1/i,
            hrefRe = /\shref=([\'\"])(.*?)\1/i,
            match,
            attrs,
            hrefMatch,
            srcMatch,
            typeMatch,
            el,
            s;
            
        while ((match = reLink.exec(html))) {
            attrs = match[1];
            hrefMatch = attrs ? attrs.match(hrefRe) : false;
            
            if (hrefMatch && hrefMatch[2]) {
                s = DOC.createElement("link");
                s.href = hrefMatch[2];
                s.rel = "stylesheet";
                typeMatch = attrs.match(typeRe);
                
                if (typeMatch && typeMatch[2]) {
                    s.type = typeMatch[2];
                }
                
                hd.appendChild(s);
            }
        }
            
        while ((match = reStyle.exec(html))) {
            if (match[2] && match[2].length > 0) {
				Ext.net.ResourceMgr.registerCssClass("", match[2], false);        
            }
        }

        while ((match = re.exec(html))) {
            attrs = match[1];
            srcMatch = attrs ? attrs.match(srcRe) : false;
            
            if (srcMatch && srcMatch[2]) {
                s = DOC.createElement("script");
                s.src = srcMatch[2];
                typeMatch = attrs.match(typeRe);
               
                if (typeMatch && typeMatch[2]) {
                    s.type = typeMatch[2];
                }
               
                hd.appendChild(s);
            } else if (match[2] && match[2].length > 0) {
                if (window.execScript) {
                    window.execScript(match[2]);
                } else {
                    window.eval.call(window, match[2]);
                }
            }
        }
        el = DOC.getElementById(id);
        
        if (el) {
            Ext.removeNode(el);
        }
    }, 20);

    var createdEl = Ext.DomHelper.append(elTo, html.replace(/(?:<script.*?>)((\n|\r|.)*?)(?:<\/script>)/ig, "")
                                                   .replace(/(?:<style.*?>)((\n|\r|.)*?)(?:<\/style>)/ig, "")
                                                   .replace(/(?:<link([^>]*)?\/>)/ig, ""), true);
    if (createdEl.id == id) {
        createdEl = createdEl.prev();
    }
    
    return createdEl;
};

var __doPostBack = function (et, ea) {
    var form = Ext.net.ResourceMgr.getAspForm(true);
    
    if (form && (!form.onsubmit || (form.onsubmit() != false))) {
        form.__EVENTTARGET.value = et;
        form.__EVENTARGUMENT.value = ea;
        form.submit();
    }
};

if (typeof RegExp.escape !== "function") {
    RegExp.escape = function (s) {
        if ("string" !== typeof s) {
            return s;
        }
        
        return s.replace(/([.*+?\^=!:${}()|\[\]\/\\])/g, "\\$1");
    };
}