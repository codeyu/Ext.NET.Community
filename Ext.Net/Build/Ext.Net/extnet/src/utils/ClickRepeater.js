// @source core/utils/ClickRepeater.js

Ext.define("Ext.net.ClickRepeater", {
    extend : "Ext.util.ClickRepeater",
    ignoredButtons: [],
    btnEvents: {
        0 : "leftclick", 
        1 : "middleclick", 
        2 : "rightclick"
    },

    constructor : function (config) {
        this.addEvents(
            "leftclick",
            "rightclick",
            "middleclick"
        );

        this.callParent([config.el, config]);
    },
    
    enable : function () {
        if (this.disabled) {
            this.el.on("mousedown", this.handleMouseDown, this);
            if (Ext.isIE) {
                this.el.on('dblclick', this.handleDblClick, this);
            }
            if ((this.preventDefault || this.stopDefault) && !this.isButtonIgnored(0)) {
                this.el.on("click", this.eventOptions, this);
            }
            if ((this.preventDefault || this.stopDefault) && !this.isButtonIgnored(2)) {
                this.el.on("contextmenu", this.eventOptions, this);
            }
        }
        this.disabled = false;
    },
    
    isButtonIgnored : function (e) {
        var ignored = false;
        Ext.each(this.ignoredButtons, function (b) {
            if (b == (e.button || e)) {
                ignored = true;
                return false;
            }
        }, this);
        
        return ignored;
    },
    
    handleMouseDown : function (e) {
        clearTimeout(this.timer);
        this.el.blur();
        if (this.pressedCls) {
            this.el.addCls(this.pressedCls);
        }
        this.mousedownTime = new Date();

        Ext.getDoc().on("mouseup", this.handleMouseUp, this);
        this.el.on("mouseout", this.handleMouseOut, this);

        if (!this.isButtonIgnored(e)) {
            this.fireEvent("mousedown", this, e);
            this.fireClick(e);
        }

        if (this.accelerate) {
            this.delay = 400;
	    }
        e = new Ext.EventObjectImpl(e);
        this.timer = Ext.defer(this.click, this.delay || this.interval, this, [e]);
    },
    
    click : function (e) {
        if (!this.isButtonIgnored(e)) {
            this.fireClick(e);
        }
        this.timer =  Ext.defer(this.click, this.accelerate ?
            this.easeOutExpo(Ext.Date.getElapsed(this.mousedownTime),
                400,
                -390,
                12000) :
            this.interval, this, [e]);
    },
    
    fireClick : function (e) {        
        if (this.fireEvent("click", this, e) !== false) {
            this.fireEvent(this.btnEvents[e.button] || "click", this, e);
        }        
    },
    
    handleMouseReturn : function (e) {
        this.el.un("mouseover", this.handleMouseReturn, this);
        
        if (this.pressedCls) {
            this.el.addCls(this.pressedCls);
        }
        
        this.click(e);
    },
    
    handleMouseUp : function (e) {
        clearTimeout(this.timer);
        this.el.un("mouseover", this.handleMouseReturn, this);
        this.el.un("mouseout", this.handleMouseOut, this);
        Ext.getDoc().un("mouseup", this.handleMouseUp, this);
        if (this.pressedCls) {
            this.el.removeCls(this.pressedCls);
        }
        
        if (!this.isButtonIgnored(e)) {
            this.fireEvent("mouseup", this, e);
        }
    }
});