
// @source core/form/FileUploadField.js

Ext.form.FileUploadField.override({
    stripPath : true,

    isIconIgnore : function () {
        return true;
    },

    onFileChange : function () {
        this.lastValue = null;

        if (this.stripPath === false) {
            Ext.form.field.File.superclass.setValue.call(this, this.fileInputEl.dom.value);
            return;
        }

        var v = this.fileInputEl.dom.value,                
            fileNameRegex = /[^\\]*$/im,
            match = fileNameRegex.exec(v);
                    
        if (match !== null) {
	        v = match[0];
        }

        Ext.form.field.File.superclass.setValue.call(this, v);
    }
});