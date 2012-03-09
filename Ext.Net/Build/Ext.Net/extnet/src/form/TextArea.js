
// @source core/form/TextArea.js

Ext.override(Ext.form.TextArea, {
    initComponent : function () {
        Ext.form.TextArea.superclass.initComponent.call(this);
        
        if (this.maxLength !== Number.MAX_VALUE && this.truncate === true) {
            this.on("validitychange", function (f, isValid) {
                if (!isValid && this.getValue().length > this.maxLength) {
                    this.setValue(this.getValue().substr(0, this.maxLength));
                }
            });
        }
    },

    // Appends the specified string and a new line to the TextArea's value.
    // Options:
    //      text - a string to append.
    appendLine : function (text) {
        this.append(text + "\n");
    }
});