/********
 * @version   : 2.0.0.beta - Professional Edition (Ext.NET Professional License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2010-06-01
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/
Ext.define('Ext.ux.MouseDistanceSensor', {
    extend: 'Ext.util.Observable', 
    opacity    : true,
    minOpacity : 0,
    maxOpacity : 1,
    threshold  : 100,
    
    constructor : function (config) {
        Ext.apply(this, config);   
        this.initEvents();
        this.callParent(arguments);
    },
    
    init : function (component) {
        this.component = component;                
        
        if (component.rendered) {
            this.onAfterRender();
        } else {
            component.on("afterrender", this.onAfterRender, this, {single : true, delay : 1});                    
        }        
        
        this.component.on("show", this.startMonitoring, this);
        this.component.on("hide", this.stopMonitoring, this);
        this.onMouseMove = Ext.Function.createBuffered(this.onMouseMove, 50, this);
    },
    
    initEvents : function () {
        this.addEvents("near", "far", "distance");
    },
    
    getSensorEls : function () {
        return this.component.el;
    },
    
    getConstrainEls : Ext.emptyFn,
    
    onAfterRender : function () {        
        this.el = this.component.el;
        if (this.el.shadow) {
            this.shadow = this.el.shadow.el;
        }
        
        if (this.component.isVisible()) {
            this.startMonitoring();
        }
    },
    
    setDisabled : function (disable) {
        this[disable ? "disable" : "enable"]();
    },

    disable : function () {
        this.disabled = true;
        if (this.opacity) {
            this.el.setOpacity(1);
        }
    },

    enable : function () {
        this.disabled = false;
    },
    
    getDistance : function (xy) {
        var x = xy[0],
            y = xy[1],
            distance,
            el;            
        
        Ext.each(this.getSensorEls(), function (sensorEl) {                
            if (!sensorEl) {
                return true;
            }
            
            var box = sensorEl.getBox();
            
            if (x >= box.x && x <= box.right && y >= box.y && y <= box.bottom) {
                distance = 0;
                el = sensorEl;
                
                return false;
            } 
            
            if (y > box.bottom) {
                y = box.y - y + box.bottom;
            }
            
            if (x > box.right) {
                x = box.x - x + box.right;
            }
            
            if (x > box.x) {
                distance = Math.abs(box.y - y);
                
                if (distance <= this.threshold) {                            
                    el = sensorEl;
                    
                    return false;
                }
                
                return true;
            }
            
            if (y > box.y) {
                distance = Math.abs(box.x - x);
                
                if (distance <= this.threshold) {                            
                    el = sensorEl;
                    
                    return false;
                }
                
                return true;
            }
            
            distance = Math.abs(Math.round(Math.sqrt(Math.pow(box.y - y, 2) + Math.pow(box.x - x, 2))));
            
            if (distance <= this.threshold) {                            
                el = sensorEl;
                
                return false;
            }
            
            return true;
        }, this);
        
        return { distance : distance, sensorEl : el };
    },
    
    isOutConstrain : function (xy) {
        var cEls = this.getConstrainEls(),
            out = true,
            box,
            x = xy[0],
            y = xy[1];
        
        if (!cEls) {
            return false;
        }
        
        Ext.each(cEls, function (el) {
            if (!el) {
                return;
            }
            
            box = el.getBox();
            
            if (x >= box.x && x <= box.right && y >= box.y && y <= box.bottom) {                        
                out = false;
                
                return false;
            } 
            
            return true;
        }, this);                
        
        return out;
    },

    onMouseMove : function () {
        if (this.disabled) { 
            return;
        }
        
        if (this.isOutConstrain(this._xy)) {
            if (this.state !== "far") {
                this.state = "far";
                this.fireEvent("far", this);
            }

            return;
        }
        
        var dObj = this.getDistance(this._xy);
        
        if (dObj.distance > this.threshold) {
            if (this.state !== "far") {
                this.state = "far";
                this.fireEvent("far", this);
            }
        } else {                        
            if (this.state !== "near") {
                this.state = "near";
                this.fireEvent("near", this, dObj.sensorEl);
            }
            
            this.fireEvent("distance", this, dObj.distance, 1 - (dObj.distance / this.threshold), dObj.sensorEl);
        }

        if (this.opacity) {
            var opacity = this.maxOpacity;
                
            if (dObj.distance > this.threshold) {
                opacity = this.minOpacity;
                this.el.setOpacity(opacity);
            } else {                        
                if (!this.component.isVisible()) {
                    this.component.show();
                }
                
                opacity = 1 - (dObj.distance / this.threshold);
                opacity = Math.min(opacity, this.maxOpacity);
                opacity = Math.max(opacity, this.minOpacity);
                
                this.el.setOpacity(opacity);                
            }
            
            this.opacityFixer(opacity);
            
            if (this.shadow) {
                this.shadow.setOpacity(opacity);
            }
        }
    },   
    
    opacityFixer : function (opacity) {
        if (Ext.isIE && this.component instanceof Ext.Window && opacity > 0) {
            var resizeHandles = this.component.el.select(".x-resizable-handle.x-window-handle");

            resizeHandles.each(function (rh) {
                rh.setStyle("filter", "none");
                rh.setStyle("background", "none");
            });
        }
    },

    startMonitoring : function () {
        if (this.disabled || this.monitoring || !this.el) {                
            return;
        }
        
        if(this.opacity){            
            this.el.setOpacity(this.minOpacity);            
            this.opacityFixer(this.minOpacity);
        }
        
        Ext.getDoc().on("mousemove", this.bufMouseMove, this);
        this.monitoring = true;
    },

    bufMouseMove : function (e) {
        this._xy = e.getXY();
        this.onMouseMove();
    },

    stopMonitoring : function () {
        if (this.disabled || !this.monitoring || !this.el) {                
            return;
        }
        
        Ext.getDoc().un("mousemove", this.bufMouseMove, this);
        this.monitoring = false;
    }
});