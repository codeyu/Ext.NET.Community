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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : TextFieldBase.Builder<FileUploadField, FileUploadField.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new FileUploadField()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FileUploadField component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FileUploadField.Config config) : base(new FileUploadField(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(FileUploadField component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A standard Ext.button.Button config object.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of FileUploadField.Builder</returns>
            public virtual FileUploadField.Builder Button(Action<Button> action)
            {
                action(this.ToComponent().Button);
                return this as FileUploadField.Builder;
            }
			 
 			/// <summary>
			/// The button text to display on the upload button (defaults to 'Browse...'). Note that if you supply a value for buttonConfig, the buttonConfig.text value will be used instead if available.
			/// </summary>
            public virtual FileUploadField.Builder ButtonText(string buttonText)
            {
                this.ToComponent().ButtonText = buttonText;
                return this as FileUploadField.Builder;
            }
             
 			/// <summary>
			/// True to display the file upload field as a button with no visible text field (defaults to false). If true, all inherited Text members will still be available.
			/// </summary>
            public virtual FileUploadField.Builder ButtonOnly(bool buttonOnly)
            {
                this.ToComponent().ButtonOnly = buttonOnly;
                return this as FileUploadField.Builder;
            }
             
 			/// <summary>
			/// The number of pixels of space reserved between the button and the text field (defaults to 3). Note that this only applies if buttonOnly = false.
			/// </summary>
            public virtual FileUploadField.Builder ButtonMargin(int buttonMargin)
            {
                this.ToComponent().ButtonMargin = buttonMargin;
                return this as FileUploadField.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of FileUploadField.Builder</returns>
            public virtual FileUploadField.Builder Listeners(Action<FileUploadFieldListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as FileUploadField.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of FileUploadField.Builder</returns>
            public virtual FileUploadField.Builder DirectEvents(Action<FileUploadFieldDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as FileUploadField.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public FileUploadField.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.FileUploadField(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public FileUploadField.Builder FileUploadField()
        {
            return this.FileUploadField(new FileUploadField());
        }

        /// <summary>
        /// 
        /// </summary>
        public FileUploadField.Builder FileUploadField(FileUploadField component)
        {
            return new FileUploadField.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public FileUploadField.Builder FileUploadField(FileUploadField.Config config)
        {
            return new FileUploadField.Builder(new FileUploadField(config));
        }
    }
}