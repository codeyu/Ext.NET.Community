
// @source core/slider/Multi.js

Ext.slider.Multi.override({    
    useHiddenField : true,
    includeHiddenStateToSubmitData : false,

    getHiddenStateName : function () {
        return this.getName();
    }
});