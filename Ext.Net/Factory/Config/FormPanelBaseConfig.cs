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
        new public abstract partial class Config : AbstractPanel.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int pollInterval = 500;

			/// <summary>
			/// Interval in milliseconds at which the form's fields are checked for value changes. Only used if the pollForChanges option is set to true. Defaults to 500 milliseconds.
			/// </summary>
			[DefaultValue(500)]
			public virtual int PollInterval 
			{ 
				get
				{
					return this.pollInterval;
				}
				set
				{
					this.pollInterval = value;
				}
			}

			private bool pollForChanges = false;

			/// <summary>
			/// If set to true, sets up an interval task (using the pollInterval) in which the panel's fields are repeatedly checked for changes in their values. This is in addition to the normal detection each field does on its own input element, and is not needed in most cases. It does, however, provide a means to absolutely guarantee detection of all changes including some edge cases in some browsers which do not fire native events. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PollForChanges 
			{ 
				get
				{
					return this.pollForChanges;
				}
				set
				{
					this.pollForChanges = value;
				}
			}
        
			private ParameterCollection baseParams = null;

			/// <summary>
			/// Parameters to pass with all requests. e.g. baseParams: {id: '123', foo: 'bar'}.
			/// </summary>
			public ParameterCollection BaseParams
			{
				get
				{
					if (this.baseParams == null)
					{
						this.baseParams = new ParameterCollection();
					}
			
					return this.baseParams;
				}
			}
			        
			private ReaderCollection errorReader = null;

			/// <summary>
			/// An Ext.data.DataReader (e.g. Ext.data.reader.Xml) to be used to read field error messages returned from 'submit' actions. This is optional as there is built-in support for processing JSON responses.
			/// </summary>
			public ReaderCollection ErrorReader
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
			
			private HttpMethod method = HttpMethod.Default;

			/// <summary>
			/// The request method to use (GET or POST) for form actions if one isn't supplied in the action options.
			/// </summary>
			[DefaultValue(HttpMethod.Default)]
			public virtual HttpMethod Method 
			{ 
				get
				{
					return this.method;
				}
				set
				{
					this.method = value;
				}
			}
        
			private ReaderCollection reader = null;

			/// <summary>
			/// An Ext.data.DataReader (e.g. Ext.data.reader.Xml) to be used to read data when executing 'load' actions. This is optional as there is built-in support for processing JSON responses.
			/// </summary>
			public ReaderCollection Reader
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
			
			private bool standardSubmit = false;

			/// <summary>
			/// If set to true, a standard HTML form submit is used instead of a XHR (Ajax) style form submission. All of the field values, plus any additional params configured via baseParams and/or the options to submit, will be included in the values submitted in the form.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool StandardSubmit 
			{ 
				get
				{
					return this.standardSubmit;
				}
				set
				{
					this.standardSubmit = value;
				}
			}

			private int timeout = 30;

			/// <summary>
			/// Timeout for form actions in seconds (default is 30 seconds).
			/// </summary>
			[DefaultValue(30)]
			public virtual int Timeout 
			{ 
				get
				{
					return this.timeout;
				}
				set
				{
					this.timeout = value;
				}
			}

			private bool trackResetOnLoad = false;

			/// <summary>
			/// If set to true, reset() resets to the last loaded or setValues() data instead of when the form was first created.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool TrackResetOnLoad 
			{ 
				get
				{
					return this.trackResetOnLoad;
				}
				set
				{
					this.trackResetOnLoad = value;
				}
			}

			private string url = "";

			/// <summary>
			/// The URL to use for form actions if one isn't supplied in the doAction options.
			/// </summary>
			[DefaultValue("")]
			public virtual string Url 
			{ 
				get
				{
					return this.url;
				}
				set
				{
					this.url = value;
				}
			}

			private string waitMsgTarget = "";

			/// <summary>
			/// By default wait messages are displayed with Ext.MessageBox.wait. You can target a specific element by passing it or its id or mask the form itself by passing in true.
			/// </summary>
			[DefaultValue("")]
			public virtual string WaitMsgTarget 
			{ 
				get
				{
					return this.waitMsgTarget;
				}
				set
				{
					this.waitMsgTarget = value;
				}
			}

			private string waitTitle = "";

			/// <summary>
			/// The default title to show for the waiting message box
			/// </summary>
			[DefaultValue("")]
			public virtual string WaitTitle 
			{ 
				get
				{
					return this.waitTitle;
				}
				set
				{
					this.waitTitle = value;
				}
			}
        
			private Labelable fieldDefaults = null;

			/// <summary>
			/// If specified, the properties in this object are used as default config values for each Ext.form.Labelable instance (e.g. Ext.form.field.Base or Ext.form.FieldContainer) that is added as a descendant of this container. Corresponding values specified in an individual field's own configuration, or from the defaults config of its parent container, will take precedence. See the documentation for Ext.form.Labelable to see what config options may be specified in the fieldDefaults.
			/// </summary>
			public Labelable FieldDefaults
			{
				get
				{
					if (this.fieldDefaults == null)
					{
						this.fieldDefaults = new Labelable();
					}
			
					return this.fieldDefaults;
				}
			}
			
        }
    }
}