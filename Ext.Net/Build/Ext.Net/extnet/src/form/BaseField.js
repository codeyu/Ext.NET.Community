
// @source core/form/Field.js

Ext.form.field.Base.override({    
    isRemoteValidation      : false,        
    remoteValidatingMessage : "Validating...",     

    onRender : Ext.Function.createSequence(Ext.form.field.Base.prototype.onRender, function (el) {        
        if (this.inputEl && this.submitValue === false) {
            this.inputEl.dom.removeAttribute('name');
        }
    }),

    afterRender : function () {
        return Ext.form.field.Base.superclass.afterRender.call(this, arguments);

        if (this.inputEl) {
            this.inputEl.selectable();
        }
    },

    onBlur : function () {
        if (this.inEditor && this.surpressBlur) {
            return;
        }

        this.callParent(arguments);
    },
    
    /***Remote validation**********/
    
    activateRemoteValidation : function () {
        this.originalIsValid = this.isValid;
        this.originalValidate = this.validate;
        
        this.isValid = this.rv_isValid;
        this.validate = this.rv_validate;
        
        this.rvConfig = Ext.apply({
            remoteValidated  : false,
            remoteValid      : false,
            validationEvent  : "keyup",
            eventOwner       : "input",
            validationBuffer : 500,
            showBusy         : true,
            busyIconCls      : "x-loading-indicator",
            busyTip          : "Validating...",
            initValueValidation : "valid",
            responseFields   : {
                success      : "valid",
                message      : "message",
                returnValue  : "value"
            }            
        }, this.remoteValidationOptions || {});
        
        var fn = function () {
            this.rvTask = new Ext.util.DelayedTask(this.remoteValidate, this);
            (this.rvConfig.eventOwner == "input" ? this.inputEl : this).on(this.rvConfig.validationEvent, this.performRemoteValidation, this);
        };
        
        if (this.rendered) {
            fn();
        } else {
            this.on("render", fn);
            
            this.on("afterrender", function () {
                if (this.value !== undefined) {
                    switch (this.rvConfig.initValueValidation) {
                        case "valid":
                            this.markAsValid();
                            break;
                        case "invalid":
                            // do nothing
                            break;
                        case "validate":
                            this.remoteValidate();
                            break;
                    }
                }
            });
        }
    },

    // private, does not work for all fields
    append : function (v) {
        this.setValue([this.getValue(), v].join(''));
    },
    
    deactivateRemoteValidation : function () {
        this.isValid = this.originalIsValid;
        this.validate = this.originalValidate;
        
        if (this.rvTask) {
            this.rvTask.cancel();
        }
        
        (this.rvConfig.eventOwner == "input" ? this.el : this).un(this.rvConfig.validationEvent, this.performRemoteValidation, this);
        
        delete this.originalIsValid;
        delete this.originalValidate;
    },
    
    // this method is used with remote validation only
    markAsValid : function (abortRequest) {        
        if (!this.isRemoteValidation) {
            return;
        }
        
        this.rvConfig.validating = false;
        this.rvConfig.remoteValidated = true;
        this.rvConfig.remoteValid = true;
        
        if (this.validationId && abortRequest !== false) {
            Ext.net.DirectEvent.abort(this.validationId);
        }    
    },
    
    rv_isValid : function () {
        if (this.disabled) {
            return true;
        }
        
        if (this.rvConfig.validating) {
            preventMark = true;
        }
        
        return this.originalIsValid.call(this) && !this.rvConfig.validating && this.rvConfig.remoteValidated && this.rvConfig.remoteValid;
    },

    localValidate : function () {
        var me = this,
            isValid = me.originalIsValid.call(me);

        if (isValid !== me.wasValid) {
            me.wasValid = isValid;
            me.fireEvent('validitychange', me, isValid);
        }

        return isValid;
    },

    rv_validate : function () {
        var clientValid = this.localValidate(),
            orgPrevent;

        if (!this.disabled && !clientValid) {
            return false;
        }
        
        if (this.rvConfig.validating) {
            orgPrevent = this.preventMark;
            this.preventMark = true;            
            this.markInvalid(this.remoteValidatingMessage);
            this.preventMark = orgPrevent;
            this.wasValid = false;
            this.fireEvent('validitychange', this, false); 
            return false;            
        }

        if (this.disabled || (clientValid && (!this.rvConfig.remoteValidated || this.rvConfig.remoteValid))) {
            if (this.rvConfig.lastValue === this.getValue() && this.rvConfig.remoteValid === false) {
                this.markInvalid(this.rv_response.message || "Invalid");
                this.wasValid = false;
                this.fireEvent('validitychange', this, false); 
            } else {
                this.clearInvalid();
                this.wasValid = true;
                this.fireEvent('validitychange', this, true); 
            }

            return this.rvConfig.remoteValid;
        }

        if (this.rvConfig.remoteValidated && !this.rvConfig.remoteValid) {
            orgPrevent = this.preventMark;
            this.preventMark = this.rvConfig.validating;
            this.markInvalid(this.rv_response.message || "Invalid");
            this.preventMark = orgPrevent;
            this.wasValid = this.rvConfig.validating;
            this.fireEvent('validitychange', this, this.rvConfig.validating); 
            return false;
        }

        return false;
    },   
    
    performRemoteValidation : function (e) {        
        var orgPrevent = this.preventMark;
        this.preventMark = true;

        if (this.rvConfig.lastValue === this.getValue() || !this.originalIsValid(true)) {
            this.preventMark = orgPrevent;
            this.rvTask.cancel();
            return;
        }

        this.preventMark = orgPrevent;

        if (!e || !e.isNavKeyPress || (e && e.isNavKeyPress && !e.isNavKeyPress())) {
            if (e && e.normalizeKey) {
                var k = e.normalizeKey(e.keyCode); 
                 
			    if (k >= 16 && k <= 20) {
                    return;
                }
            }
			
            this.rvTask.delay(this.rvConfig.validationBuffer);
        }
    },
    
    remoteValidate : function () {
        this.rvConfig.remoteValid = false;
	    this.rvConfig.remoteValidated = false;
			
        var dc = Ext.apply({}, this.remoteValidationOptions),
		    options = {params : {}};
		
		if (this.fireEvent("beforeremotevalidation", this, options) !== false) {		    
		    dc.userSuccess = this.remoteValidationSuccess;
            dc.userFailure = this.remoteValidationFailure;
            dc.extraParams = Ext.apply(dc.extraParams || {}, options.params);
            dc.control = this;
            dc.eventType = "postback";
            dc.action = "remotevalidation";
            
            var o = {
                id : this.id,
                name : this.name,
                value : this.getValue()
            };
            
            dc.serviceParams = Ext.encode(o);
            
            if (dc.url) {
		        dc.cleanRequest = true;

		        if (dc.json && Ext.isEmpty(dc.method, false)) {
	                dc.method = "POST";
	            }

	            dc.extraParams = Ext.apply(dc.extraParams, o);
                dc.type = "load";
		    }
		    
		    if (this.rvConfig.showBusy) {
		        this.setIndicatorIconCls(this.rvConfig.busyIconCls, true);
		        this.showIndicator();
		        
				if (this.rvConfig.busyTip) {
		            this.setIndicatorTip(this.rvConfig.busyTip);
		        }
		    }
		    
            this.rvConfig.remoteValidated = false;
            this.rvConfig.validating = true;
            this.rvConfig.lastValue = o.value;

            this.wasValid = false;
            this.fireEvent('validitychange', false); 

            if (this.validationId) {
                this.validationId.abortedByEvent = true;

                try{
                    Ext.net.DirectEvent.abort(this.validationId);
                } catch(e) { }
            }

            this.validationId = Ext.net.DirectEvent.request(dc);
        }        
    },
    
    remoteValidationSuccess : function (response, result, context, type, action, extraParams, o) {
        var isException = false,
            responseObj;
        
        this.rvConfig.validating = false;
        this.validationId = null;
        
        if (this.rvConfig.showBusy) {
	        this.clearIndicator();	        
	    }
        
        try {
		    responseObj = result.serviceResponse || result.d || result;
		    
            result = { 
                success : responseObj[this.rvConfig.responseFields.success], 
                message : responseObj[this.rvConfig.responseFields.message],
                value   : responseObj[this.rvConfig.responseFields.returnValue]
            };            
	    } catch (ex) {
		    result = {
		        success : false,
		        message : ex.message
		    };
		    
		    isException = true;
		    
		    this.rvConfig.remoteValidated = true;
            this.rvConfig.remoteValid = false;
		    
		    this.fireEvent("remotevalidationinvalid", this, response, responseObj, ex, o);
			
		    if (o.cancelWarningFailure !== true && 
	          (this.remoteValidationOptions || {}).showWarningFailure !== false &&
	          !this.hasListener("remotevalidationinvalid")) {
	            Ext.net.DirectEvent.showFailure(response, response.responseText);
	        }
			
            return;
	    }
	    
	    if (!isException && result.success !== true) {
		    this.fireEvent("remotevalidationinvalid", this, response, responseObj, result, o);		    
	    }
	    
	    if (result.success === true) {
	        this.fireEvent("remotevalidationvalid", this, response, responseObj, result, o);
	    }
	    
	    if (result.value !== null && Ext.isDefined(result.value)) {
	        this.setValue(result.value);		    
	    }
	
        this.rvConfig.remoteValidated = true;
        this.rvConfig.remoteValid = result.success;
        this.rv_response = result;
        this.validate();
    }, 
    
    remoteValidationFailure : function (response, result, context, type, action, extraParams, o) {
        if (response.request.abortedByEvent) {
            return;
        }
        
        this.validationId = null;
        
        if (this.rvConfig.showBusy) {
	        this.clearIndicator();	        
	    }
        
        this.fireEvent("remotevalidationfailure", this, response, {message: response.statusText}, o);
        
        this.rvConfig.validating = false;
        this.rvConfig.remoteValidated = true;
        this.rvConfig.remoteValid = false;
        this.rv_response = {
			success : false, 
			message : response.responseText
		};

        this.wasValid = false;
        this.fireEvent('validitychange', false); 
		
		if (o.cancelWarningFailure !== true && 
		    (this.remoteValidationOptions || {}).showWarningFailure !== false &&
		    !this.hasListener("remotevalidationfailure")) {
		    Ext.net.DirectEvent.showFailure(response, response.responseText);
		}    
    }
    
    /***End of Remote validation***/
});

Ext.form.field.Base.prototype.initComponent = Ext.Function.createSequence(Ext.form.field.Base.prototype.initComponent, function () {    
    this.addEvents({        
        "remotevalidationfailure"   : true,
        "remotevalidationinvalid"   : true,
        "remotevalidationvalid"     : true,
        "beforeremotevalidation"    : true,
        "indicatoriconclick"        : true            
    });
    
    this.remoteValidationSuccess = Ext.Function.bind(this.remoteValidationSuccess, this);
    this.remoteValidationFailure = Ext.Function.bind(this.remoteValidationFailure, this);
    
    if (this.isRemoteValidation) {
        this.activateRemoteValidation();
    }
});