/********
 * This file is part of Ext.NET.
 *     
 * Ext.NET is free software: you can redistribute it and/or modify
 * it under the terms of the GNU AFFERO GENERAL PUBLIC LICENSE as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Ext.NET is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU AFFERO GENERAL PUBLIC LICENSE for more details.
 * 
 * You should have received a copy of the GNU AFFERO GENERAL PUBLIC LICENSE
 * along with Ext.NET.  If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * @version   : 2.0.0.beta - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-03-07
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// FormPanel provides a standard container for forms. It is essentially a standard Ext.panel.Panel which automatically creates a BasicForm for managing any Ext.form.field.Field objects that are added as descendants of the panel. It also includes conveniences for configuring and working with the BasicForm and the collection of Fields.
    /// 
    /// Layout
    /// 
    /// By default, FormPanel is configured with layout:'anchor' for the layout of its immediate child items. This can be changed to any of the supported container layouts. The layout of sub-containers is configured in the standard way.
    /// 
    /// BasicForm
    /// 
    /// Although not listed as configuration options of FormPanel, the FormPanel class accepts all of the config options supported by the Ext.form.Basic class, and will pass them along to the internal BasicForm when it is created.
    /// 
    /// Note: If subclassing FormPanel, any configuration options for the BasicForm must be applied to the initialConfig property of the FormPanel. Applying BasicForm configuration settings to this will not affect the BasicForm's configuration.
    /// 
    /// The following events fired by the BasicForm will be re-fired by the FormPanel and can therefore be listened for on the FormPanel itself:
    /// 
    /// beforeaction
    /// actionfailed
    /// actioncomplete
    /// validitychange
    /// dirtychange
    /// Field Defaults
    ///
    /// The fieldDefaults config option conveniently allows centralized configuration of default values for all fields added as descendants of the FormPanel. Any config option recognized by implementations of Ext.form.Labelable may be included in this object. See the fieldDefaults documentation for details of how the defaults are applied.
    /// 
    /// Form Validation
    /// 
    /// With the default configuration, form fields are validated on-the-fly while the user edits their values. This can be controlled on a per-field basis (or via the fieldDefaults config) with the field config properties Ext.form.field.Field.validateOnChange and Ext.form.field.Base.checkChangeEvents, and the FormPanel's config properties pollForChanges and pollInterval.
    /// 
    /// Any component within the FormPanel can be configured with formBind: true. This will cause that component to be automatically disabled when the form is invalid, and enabled when it is valid. This is most commonly used for Button components to prevent submitting the form in an invalid state, but can be used on any component type.
    /// 
    /// For more information on form validation see the following:
    /// 
    /// Ext.form.field.Field.validateOnChange
    /// pollForChanges and pollInterval
    /// Ext.form.field.VTypes
    /// BasicForm.doAction clientValidation notes
    /// Form Submission
    /// 
    /// By default, Ext Forms are submitted through Ajax, using Ext.form.action.Action. See the documentation for Ext.form.Basic for details.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:FormPanel runat=\"server\" Title=\"Title\" Padding=\"5\" ButtonAlign=\"Right\" Height=\"185\" Width=\"300\"><Items><{0}:TextField runat=\"server\" FieldLabel=\"Label\" AnchorHorizontal=\"100%\" /></Items><Buttons><{0}:Button runat=\"server\" Icon=\"Disk\" Text=\"Submit\" /></Buttons></ext:FormPanel>")]
    [ToolboxBitmap(typeof(FormPanel), "Build.ToolboxIcons.FormPanel.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("Standard form container.")]
    public partial class FormPanel : FormPanelBase
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FormPanel() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "form";
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.form.Panel";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.BaseParams.Count > 0)
            {
                if (this.Listeners.BeforeAction.IsDefault)
                {
                    this.Listeners.BeforeAction.Fn = this.BuildParams(this.BaseParams, null, true);
                }
                else
                {
                    if (this.Listeners.BeforeAction.Fn.IsNotEmpty())
                    {
                        this.Listeners.BeforeAction.Fn = this.BuildParams(this.BaseParams, this.Listeners.BeforeAction.Fn, true);
                    }
                    else
                    {
                        this.Listeners.BeforeAction.Fn = this.BuildParams(this.BaseParams, this.Listeners.BeforeAction.Handler, false);
                    }
                }
            }
        }

        private string BuildParams(ParameterCollection parameters, string userHandler, bool isFn)
        {
            StringBuilder sb = new StringBuilder("function(form,action){if (!form.baseParams){form.baseParams={};};");

            sb.AppendFormat("Ext.apply(form.baseParams,{0});", parameters.ToJson());

            if (userHandler.IsNotEmpty())
            {
                sb.Append(userHandler);

                if (isFn)
                {
                    sb.Append("(form,action);");
                }
            }
            sb.Append("}");

            return sb.ToString();
        }

        private FormPanelListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]        
        [Description("Client-side JavaScript Event Handlers")]
        public FormPanelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new FormPanelListeners();
                }

                return this.listeners;
            }
        }

        private FormPanelDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]        
        [Description("Server-side Ajax Event Handlers")]
        public FormPanelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new FormPanelDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }
}