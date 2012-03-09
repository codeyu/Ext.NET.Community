
// @source core/layout/Field.js

Ext.layout.component.field.Field.prototype.finishedLayout = Ext.Function.createInterceptor(Ext.layout.component.field.Field.prototype.finishedLayout, function (ownerContext) {
    if (!this.owner.indicatorEl) {        
        return;
    }

    var errorSide = this.owner.msgTarget == "side" && this.owner.hasActiveError(),
        w;
    
    if (errorSide) {
        this.owner.hideIndicator(true);
        this.owner.errorSideHide = true;
        w = 0;
    } else {    
        if (this.owner.errorSideHide) {
            this.owner.showIndicator(true);
        }

        this.owner.indicatorEl.setStyle("padding-left", this.owner.indicatorIconCls ? "18px" : "0px");
        
        if (this.owner.autoFitIndicator) {
           w = this.owner.isIndicatorEmpty() ? (this.owner.preserveIndicatorIcon ? 18 : 0) : this.owner.indicatorEl.getWidth();
           this.owner.indicatorEl.parent("td").setStyle("width", w + "px");
           this.owner.indicatorEl.parent().setStyle("width", w + "px");
           this.owner.indicatorEl.parent().setStyle("height", this.owner.inputEl ? (this.owner.inputEl.getHeight() +"px") : "22px");
           this.owner.indicatorEl.setStyle("width", w+"px");
        }
        else {
            w = this.owner.indicatorEl.getWidth();
        }
    }    

    this.owner.getErrorStub().setDisplayed(errorSide);
    this.owner.getIndicatorStub().setDisplayed(!this.owner.indicatorHidden);
    this.owner.getIndicatorStub().setStyle("width", w + "px");

    if (Ext.isGecko && this.owner.bodyEl) {         
        this.owner.bodyEl.setStyle("display", this.owner.repaintFix);
        this.owner.repaintFix = this.owner.repaintFix == "block" ? "" : "block";
    }
});