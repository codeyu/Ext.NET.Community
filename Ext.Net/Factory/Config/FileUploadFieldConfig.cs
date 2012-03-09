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
    public partial class FileUploadField
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public FileUploadField(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit FileUploadField.Config Conversion to FileUploadField
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator FileUploadField(FileUploadField.Config config)
        {
            return new FileUploadField(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : TextFieldBase.Config 
        { 
			/*  Implicit FileUploadField.Config Conversion to FileUploadField.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator FileUploadField.Builder(FileUploadField.Config config)
			{
				return new FileUploadField.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private Button button = null;

			/// <summary>
			/// A standard Ext.button.Button config object.
			/// </summary>
			public Button Button
			{
				get
				{
					if (this.button == null)
					{
						this.button = new Button();
					}
			
					return this.button;
				}
			}
			
			private string buttonText = "Browse...";

			/// <summary>
			/// The button text to display on the upload button (defaults to 'Browse...'). Note that if you supply a value for buttonConfig, the buttonConfig.text value will be used instead if available.
			/// </summary>
			[DefaultValue("Browse...")]
			public virtual string ButtonText 
			{ 
				get
				{
					return this.buttonText;
				}
				set
				{
					this.buttonText = value;
				}
			}

			private bool buttonOnly = false;

			/// <summary>
			/// True to display the file upload field as a button with no visible text field (defaults to false). If true, all inherited Text members will still be available.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ButtonOnly 
			{ 
				get
				{
					return this.buttonOnly;
				}
				set
				{
					this.buttonOnly = value;
				}
			}

			private int buttonMargin = 3;

			/// <summary>
			/// The number of pixels of space reserved between the button and the text field (defaults to 3). Note that this only applies if buttonOnly = false.
			/// </summary>
			[DefaultValue(3)]
			public virtual int ButtonMargin 
			{ 
				get
				{
					return this.buttonMargin;
				}
				set
				{
					this.buttonMargin = value;
				}
			}
        
			private FileUploadFieldListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public FileUploadFieldListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new FileUploadFieldListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private FileUploadFieldDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public FileUploadFieldDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new FileUploadFieldDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}