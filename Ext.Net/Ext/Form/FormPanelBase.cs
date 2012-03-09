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
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class FormPanelBase : AbstractPanel
    {
        /// <summary>
        /// Interval in milliseconds at which the form's fields are checked for value changes. Only used if the pollForChanges option is set to true. Defaults to 500 milliseconds.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. FormPanel")]
        [DefaultValue(500)]
        [NotifyParentProperty(true)]
        [Description("Interval in milliseconds at which the form's fields are checked for value changes. Only used if the pollForChanges option is set to true. Defaults to 500 milliseconds.")]
        public virtual int PollInterval
        {
            get
            {
                return this.State.Get<int>("PollInterval", 500);
            }
            set
            {
                this.State.Set("PollInterval", value);
            }
        }

        /// <summary>
        /// If set to true, sets up an interval task (using the pollInterval) in which the panel's fields are repeatedly checked for changes in their values. This is in addition to the normal detection each field does on its own input element, and is not needed in most cases. It does, however, provide a means to absolutely guarantee detection of all changes including some edge cases in some browsers which do not fire native events. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. FormPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If set to true, sets up an interval task (using the pollInterval) in which the panel's fields are repeatedly checked for changes in their values. This is in addition to the normal detection each field does on its own input element, and is not needed in most cases. It does, however, provide a means to absolutely guarantee detection of all changes including some edge cases in some browsers which do not fire native events. Defaults to false.")]
        public virtual bool PollForChanges
        {
            get
            {
                return this.State.Get<bool>("PollForChanges", false);
            }
            set
            {
                this.State.Set("PollForChanges", value);
            }
        }

        /// <summary>
        /// The Ext.container.Container.layout for the form panel's immediate child items. Defaults to 'anchor'.
        /// </summary>
        [Category("5. Container")]
        [DefaultValue("anchor")]
        [TypeConverter(typeof(LayoutConverter))]
        [Description("The Ext.container.Container.layout for the form panel's immediate child items. Defaults to 'anchor'.")]
        public override string Layout
        {
            get
            {
                return this.State.Get<string>("Layout", "anchor");
            }
            set
            {
                this.State.Set("Layout", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string DefaultLayout
        {
            get
            {
                return "anchor";
            }
        }

        #region /*---- BasicForm properties -------*/

        private ParameterCollection baseParams;

        /// <summary>
        /// Parameters to pass with all requests. e.g. baseParams: {id: '123', foo: 'bar'}.
        /// Parameters are encoded as standard HTTP parameters using Ext.Object.toQueryString.
        /// </summary>
        [Meta]
        [Category("6. FormPanel")]        
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Parameters to pass with all requests. e.g. baseParams: {id: '123', foo: 'bar'}.")]
        public virtual ParameterCollection BaseParams
        {
            get
            {
                if (this.baseParams == null)
                {
                    this.baseParams = new ParameterCollection();
                    this.baseParams.Owner = this;
                }

                return this.baseParams;
            }
        }

        private ReaderCollection errorReader;

        /// <summary>
        /// An Ext.data.DataReader (e.g. Ext.data.reader.Xml) to be used to read field error messages returned from 'submit' actions. This is optional as there is built-in support for processing JSON responses.
        /// The Records which provide messages for the invalid Fields must use the Field name (or id) as the Record ID, and must contain a field called 'msg' which contains the error message.
        /// The errorReader does not have to be a full-blown implementation of a Reader. It simply needs to implement a read(xhr) function which returns an Array of Records in an object with the following structure:
        /// </summary>
        [Meta]
        [ConfigOption("reader>Reader")]
        [Category("6. FormPanel")]        
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An Ext.data.DataReader (e.g. Ext.data.reader.Xml) to be used to read field error messages returned from 'submit' actions. This is optional as there is built-in support for processing JSON responses.")]
        public virtual ReaderCollection ErrorReader
        {
            get
            {
                if (this.errorReader == null)
                {
                    this.errorReader = new ReaderCollection();
                }

                return this.errorReader;
            }
        }

        /// <summary>
        /// The request method to use (GET or POST) for form actions if one isn't supplied in the action options.
        /// </summary>
        [Meta]
        [ConfigOption("method")]
        [DefaultValue(HttpMethod.Default)]
        [NotifyParentProperty(true)]
        [Description("The request method to use (GET or POST) for form actions if one isn't supplied in the action options.")]
        public virtual HttpMethod Method
        {
            get
            {
                return this.State.Get<HttpMethod>("Method", HttpMethod.Default);
            }
            set
            {
                this.State.Set("Method", value);
            }
        }

        private ReaderCollection reader;

        /// <summary>
        /// An Ext.data.DataReader (e.g. Ext.data.reader.Xml) to be used to read data when executing 'load' actions. This is optional as there is built-in support for processing JSON responses.
        /// </summary>
        [Meta]
        [ConfigOption("reader>Reader")]
        [Category("6. FormPanel")]        
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An Ext.data.DataReader (e.g. Ext.data.reader.Xml) to be used to read data when executing 'load' actions. This is optional as there is built-in support for processing JSON responses.")]
        public virtual ReaderCollection Reader
        {
            get
            {
                if (this.reader == null)
                {
                    this.reader = new ReaderCollection();
                }

                return this.reader;
            }
        }

        /// <summary>
        /// If set to true, a standard HTML form submit is used instead of a XHR (Ajax) style form submission. All of the field values, plus any additional params configured via baseParams and/or the options to submit, will be included in the values submitted in the form.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. FormPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If set to true, a standard HTML form submit is used instead of a XHR (Ajax) style form submission. All of the field values, plus any additional params configured via baseParams and/or the options to submit, will be included in the values submitted in the form.")]
        public virtual bool StandardSubmit
        {
            get
            {
                return this.State.Get<bool>("StandardSubmit", false);
            }
            set
            {
                this.State.Set("StandardSubmit", value);
            }
        }

        /// <summary>
        /// Timeout for form actions in seconds (default is 30 seconds).
        /// </summary>
        [Meta]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [DefaultValue(30)]
        [Description("Timeout for form actions in seconds (default is 30 seconds).")]
        public virtual int Timeout
        {
            get
            {
                return this.State.Get<int>("Timeout", 30);
            }
            set
            {
                this.State.Set("Timeout", value);
            }
        }

        /// <summary>
        /// If set to true, reset() resets to the last loaded or setValues() data instead of when the form was first created.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. FormPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If set to true, reset() resets to the last loaded or setValues() data instead of when the form was first created.")]
        public virtual bool TrackResetOnLoad
        {
            get
            {
                return this.State.Get<bool>("TrackResetOnLoad", false);
            }
            set
            {
                this.State.Set("TrackResetOnLoad", value);
            }
        }

        /// <summary>
        /// The URL to use for form actions if one isn't supplied in the doAction options.
        /// </summary>
        [Meta]
        [Category("6. FormPanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The URL to use for form actions if one isn't supplied in the doAction options.")]
        public virtual string Url
        {
            get
            {
                return this.State.Get<string>("Url", "");
            }
            set
            {
                this.State.Set("Url", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("url")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string UrlProxy
        {
            get
            {
                if (this.Url.IsEmpty())
                {
                    if (HttpContext.Current != null && HttpContext.Current.Request.RawUrl.IsNotEmpty())
                    {
                        return HttpContext.Current.Request.RawUrl;
                    }
                    
                    return "";
                }

                return this.ResolveClientUrl(this.Url);
            }
        }

        /// <summary>
        /// By default wait messages are displayed with Ext.MessageBox.wait. You can target a specific element by passing it or its id or mask the form itself by passing in true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. FormPanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("By default wait messages are displayed with Ext.MessageBox.wait. You can target a specific element by passing it or its id or mask the form itself by passing in true.")]
        public virtual string WaitMsgTarget
        {
            get
            {
                return this.State.Get<string>("WaitMsgTarget", "");
            }
            set
            {
                this.State.Set("WaitMsgTarget", value);
            }
        }

        /// <summary>
        /// The default title to show for the waiting message box
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. FormPanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The default title to show for the waiting message box")]
        public virtual string WaitTitle
        {
            get
            {
                return this.State.Get<string>("WaitTitle", "");
            }
            set
            {
                this.State.Set("WaitTitle", value);
            }
        }

        #endregion

        private Labelable fieldDefaults;

        /// <summary>
        /// If specified, the properties in this object are used as default config values for each Ext.form.Labelable instance (e.g. Ext.form.field.Base or Ext.form.FieldContainer) that is added as a descendant of this container. Corresponding values specified in an individual field's own configuration, or from the defaults config of its parent container, will take precedence. See the documentation for Ext.form.Labelable to see what config options may be specified in the fieldDefaults.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [Category("6. FormPanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("If specified, the properties in this object are used as default config values for each Ext.form.Labelable instance (e.g. Ext.form.field.Base or Ext.form.FieldContainer) that is added as a descendant of this container. Corresponding values specified in an individual field's own configuration, or from the defaults config of its parent container, will take precedence. See the documentation for Ext.form.Labelable to see what config options may be specified in the fieldDefaults.")]
        public virtual Labelable FieldDefaults
        {
            get
            {
                if (this.fieldDefaults == null)
                {
                    this.fieldDefaults = new Labelable(this);
                }

                return this.fieldDefaults;
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void CallForm(string name, params object[] args)
        {
            this.CallTemplate("{0}.getForm().{1}({2});", name, args);
        }

        /// <summary>
        /// Forces each field within the form panel to check if its value has changed.
        /// </summary>
        public void CheckChange()
        {
            this.Call("checkChange");
        }

        /// <summary>
        /// Start an interval task to continuously poll all the fields in the form for changes in their values. This is normally started automatically by setting the pollForChanges config.
        /// </summary>
        /// <param name="interval">The interval in milliseconds at which the check should run.</param>
        public void StartPolling(int interval)
        {
            this.Call("startPolling", interval);
        }

        /// <summary>
        /// Stop a running interval task that was started by startPolling.
        /// </summary>
        public void StopPolling()
        {
            this.Call("stopPolling");
        }

        /// <summary>
        /// Calls Ext.apply for all fields in this form with the passed object.
        /// </summary>
        [Meta]
        [Description("Calls Ext.apply for all fields in this form with the passed object.")]
        public virtual void ApplyToFields(object values)
        {
            this.CallForm("applyToFields", values);
        }

        /// <summary>
        /// Calls Ext.applyIf for all fields in this form with the passed object.
        /// </summary>
        [Meta]
        [Description("Calls Ext.applyIf for all fields in this form with the passed object.")]
        public virtual void ApplyIfToFields(object values)
        {
            this.CallForm("applyIfToFields", values);
        }

        /// <summary>
        /// Check whether the dirty state of the entire form has changed since it was last checked, and if so fire the dirtychange event. This is automatically invoked when an individual field's dirty state changes.
        /// </summary>
        public virtual void CheckDirty()
        {
            this.CallForm("checkDirty");
        }

        /// <summary>
        /// Check whether the validity of the entire form has changed since it was last checked, and if so fire the validitychange event. This is automatically invoked when an individual field's validity changes.
        /// </summary>
        public virtual void CheckValidity()
        {
            this.CallForm("checkValidity");
        }

        /// <summary>
        /// Clears all invalid field messages in this form.
        /// </summary>
        [Meta]
        [Description("Clears all invalid field messages in this form.")]
        public virtual void ClearInvalid()
        {
            this.CallForm("clearInvalid");
        }

        /// <summary>
        /// Mark fields in this form invalid in bulk.
        /// </summary>
        /// <param name="errors">Either an array in the form [{id:'fieldId', msg:'The message'}, ...], an object hash of {id: msg, id2: msg2}, or a Ext.data.Errors object.</param>
        [Meta]
        [Description("Mark fields in this form invalid in bulk.")]
        public virtual void MarkInvalid(object errors)
        {
            this.CallForm("markInvalid", errors);
        }

        /// <summary>
        /// Resets all fields in this form.
        /// </summary>
        [Meta]
        [Description("Resets this form.")]
        public virtual void Reset()
        {
            this.CallForm("reset");
        }

        /// <summary>
        /// Set values for fields in this form in bulk.
        /// </summary>
        /// <param name="values">Either an array in the form: [{id:'clientName', value:'Fred. Olsen Lines'}, {id:'portOfLoading', value:'FXT'}] or an object hash of the form: {clientName: 'Fred. Olsen Lines', portOfLoading: 'FXT'}</param>
        [Meta]
        [Description("Set values for fields in this form in bulk.")]
        public virtual void SetValues(object values)
        {
            this.CallForm("setValues", values);
        }

        /// <summary>
        /// Persists the values in this form into the passed Ext.data.Model object in a beginEdit/endEdit block.
        /// </summary>
        public virtual void UpdateRecord()
        {
            this.CallForm("updateRecord");
        }

        /// <summary>
        /// Persists the values in this form into the passed Ext.data.Model object in a beginEdit/endEdit block.
        /// </summary>
        /// <param name="model">The record to edit</param>
        public virtual void UpdateRecord(ModelProxy model)
        {
            this.CallForm("updateRecord", new JRawValue(model.ModelInstance));
        }

        /// <summary>
        /// Loads an Ext.data.Model into this form by calling setValues with the record data. See also trackResetOnLoad.
        /// </summary>
        /// <param name="model">The record to load</param>
        public virtual void LoadRecord(ModelProxy model)
        {
            this.CallForm("loadRecord", new JRawValue(model.ModelInstance));
        }
    }
}