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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class FormPanelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TFormPanelBase, TBuilder> : AbstractPanel.Builder<TFormPanelBase, TBuilder>
            where TFormPanelBase : FormPanelBase
            where TBuilder : Builder<TFormPanelBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TFormPanelBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Interval in milliseconds at which the form's fields are checked for value changes. Only used if the pollForChanges option is set to true. Defaults to 500 milliseconds.
			/// </summary>
            public virtual TBuilder PollInterval(int pollInterval)
            {
                this.ToComponent().PollInterval = pollInterval;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If set to true, sets up an interval task (using the pollInterval) in which the panel's fields are repeatedly checked for changes in their values. This is in addition to the normal detection each field does on its own input element, and is not needed in most cases. It does, however, provide a means to absolutely guarantee detection of all changes including some edge cases in some browsers which do not fire native events. Defaults to false.
			/// </summary>
            public virtual TBuilder PollForChanges(bool pollForChanges)
            {
                this.ToComponent().PollForChanges = pollForChanges;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Parameters to pass with all requests. e.g. baseParams: {id: '123', foo: 'bar'}.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder BaseParams(Action<ParameterCollection> action)
            {
                action(this.ToComponent().BaseParams);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// An Ext.data.DataReader (e.g. Ext.data.reader.Xml) to be used to read field error messages returned from 'submit' actions. This is optional as there is built-in support for processing JSON responses.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ErrorReader(Action<ReaderCollection> action)
            {
                action(this.ToComponent().ErrorReader);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The request method to use (GET or POST) for form actions if one isn't supplied in the action options.
			/// </summary>
            public virtual TBuilder Method(HttpMethod method)
            {
                this.ToComponent().Method = method;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An Ext.data.DataReader (e.g. Ext.data.reader.Xml) to be used to read data when executing 'load' actions. This is optional as there is built-in support for processing JSON responses.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Reader(Action<ReaderCollection> action)
            {
                action(this.ToComponent().Reader);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// If set to true, a standard HTML form submit is used instead of a XHR (Ajax) style form submission. All of the field values, plus any additional params configured via baseParams and/or the options to submit, will be included in the values submitted in the form.
			/// </summary>
            public virtual TBuilder StandardSubmit(bool standardSubmit)
            {
                this.ToComponent().StandardSubmit = standardSubmit;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Timeout for form actions in seconds (default is 30 seconds).
			/// </summary>
            public virtual TBuilder Timeout(int timeout)
            {
                this.ToComponent().Timeout = timeout;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If set to true, reset() resets to the last loaded or setValues() data instead of when the form was first created.
			/// </summary>
            public virtual TBuilder TrackResetOnLoad(bool trackResetOnLoad)
            {
                this.ToComponent().TrackResetOnLoad = trackResetOnLoad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The URL to use for form actions if one isn't supplied in the doAction options.
			/// </summary>
            public virtual TBuilder Url(string url)
            {
                this.ToComponent().Url = url;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// By default wait messages are displayed with Ext.MessageBox.wait. You can target a specific element by passing it or its id or mask the form itself by passing in true.
			/// </summary>
            public virtual TBuilder WaitMsgTarget(string waitMsgTarget)
            {
                this.ToComponent().WaitMsgTarget = waitMsgTarget;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default title to show for the waiting message box
			/// </summary>
            public virtual TBuilder WaitTitle(string waitTitle)
            {
                this.ToComponent().WaitTitle = waitTitle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If specified, the properties in this object are used as default config values for each Ext.form.Labelable instance (e.g. Ext.form.field.Base or Ext.form.FieldContainer) that is added as a descendant of this container. Corresponding values specified in an individual field's own configuration, or from the defaults config of its parent container, will take precedence. See the documentation for Ext.form.Labelable to see what config options may be specified in the fieldDefaults.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder FieldDefaults(Action<Labelable> action)
            {
                action(this.ToComponent().FieldDefaults);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Calls Ext.apply for all fields in this form with the passed object.
			/// </summary>
            public virtual TBuilder ApplyToFields(object values)
            {
                this.ToComponent().ApplyToFields(values);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Calls Ext.applyIf for all fields in this form with the passed object.
			/// </summary>
            public virtual TBuilder ApplyIfToFields(object values)
            {
                this.ToComponent().ApplyIfToFields(values);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Clears all invalid field messages in this form.
			/// </summary>
            public virtual TBuilder ClearInvalid()
            {
                this.ToComponent().ClearInvalid();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Mark fields in this form invalid in bulk.
			/// </summary>
            public virtual TBuilder MarkInvalid(object errors)
            {
                this.ToComponent().MarkInvalid(errors);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Resets this form.
			/// </summary>
            public virtual TBuilder Reset()
            {
                this.ToComponent().Reset();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Set values for fields in this form in bulk.
			/// </summary>
            public virtual TBuilder SetValues(object values)
            {
                this.ToComponent().SetValues(values);
                return this as TBuilder;
            }
            
        }        
    }
}