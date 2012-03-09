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
    public partial class Editor
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ComponentBase.Builder<Editor, Editor.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Editor()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Editor component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Editor.Config config) : base(new Editor(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Editor component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Event name for activate the editor
			/// </summary>
            public virtual Editor.Builder ActivateEvent(string activateEvent)
            {
                this.ToComponent().ActivateEvent = activateEvent;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// The position to align to (see Ext.Element.alignTo for more details, defaults to \"c-c?\").
			/// </summary>
            public virtual Editor.Builder Alignment(string alignment)
            {
                this.ToComponent().Alignment = alignment;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// True for the editor to automatically adopt the size of the underlying field. Otherwise, an object can be passed to indicate where to get each dimension. The available properties are 'boundEl' and 'field'. If a dimension is not specified, it will use the underlying height/width specified on the editor object. 
			/// </summary>
            public virtual Editor.Builder AutoSize(bool autoSize)
            {
                this.ToComponent().AutoSize = autoSize;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// True to complete the editing process if in edit mode when the field is blurred. Defaults to true.
			/// </summary>
            public virtual Editor.Builder AllowBlur(bool allowBlur)
            {
                this.ToComponent().AllowBlur = allowBlur;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// True to cancel the edit when the blur event is fired (defaults to false)
			/// </summary>
            public virtual Editor.Builder CancelOnBlur(bool cancelOnBlur)
            {
                this.ToComponent().CancelOnBlur = cancelOnBlur;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// True to cancel the edit when the escape key is pressed. Defaults to: true
			/// </summary>
            public virtual Editor.Builder CancelOnEsc(bool cancelOnEsc)
            {
                this.ToComponent().CancelOnEsc = cancelOnEsc;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// True to complete the edit when the enter key is pressed (defaults to false)
			/// </summary>
            public virtual Editor.Builder CompleteOnEnter(bool completeOnEnter)
            {
                this.ToComponent().CompleteOnEnter = completeOnEnter;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// True to constrain the editor to the viewport. Defaults to: false
			/// </summary>
            public virtual Editor.Builder Constrain(bool constrain)
            {
                this.ToComponent().Constrain = constrain;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// False to keep the bound element visible while the editor is displayed. Defaults to: true
			/// </summary>
            public virtual Editor.Builder HideEl(bool hideEl)
            {
                this.ToComponent().HideEl = hideEl;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// The Field object (or descendant)
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Editor.Builder</returns>
            public virtual Editor.Builder Field(Action<ItemsCollection<Field>> action)
            {
                action(this.ToComponent().Field);
                return this as Editor.Builder;
            }
			 
 			/// <summary>
			/// True to skip the edit completion process (no save, no events fired) if the user completes an edit and the value has not changed. Applies only to string values - edits for other data types will never be ignored. Defaults to: false
			/// </summary>
            public virtual Editor.Builder IgnoreNoChange(bool ignoreNoChange)
            {
                this.ToComponent().IgnoreNoChange = ignoreNoChange;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// An element to render to. Defaults to the document.body.
			/// </summary>
            public virtual Editor.Builder ParentElement(string parentElement)
            {
                this.ToComponent().ParentElement = parentElement;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// True to automatically revert the field value and cancel the edit when the user completes an edit and the field validation fails (defaults to true)
			/// </summary>
            public virtual Editor.Builder RevertInvalid(bool revertInvalid)
            {
                this.ToComponent().RevertInvalid = revertInvalid;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// Handle the keydown/keypress events so they don't propagate (defaults to true)
			/// </summary>
            public virtual Editor.Builder SwallowKeys(bool swallowKeys)
            {
                this.ToComponent().SwallowKeys = swallowKeys;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// True to update the innerHTML of the bound element when the update completes (defaults to false)
			/// </summary>
            public virtual Editor.Builder UpdateEl(bool updateEl)
            {
                this.ToComponent().UpdateEl = updateEl;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// The data value of the underlying field (defaults to \"\")
			/// </summary>
            public virtual Editor.Builder Value(string value)
            {
                this.ToComponent().Value = value;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Editor.Builder</returns>
            public virtual Editor.Builder TargetControl(Action<Control> action)
            {
                action(this.ToComponent().TargetControl);
                return this as Editor.Builder;
            }
			 
 			/// <summary>
			/// The target id to associate with this tooltip.
			/// </summary>
            public virtual Editor.Builder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Editor.Builder</returns>
            public virtual Editor.Builder Listeners(Action<InlineEditorListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as Editor.Builder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of Editor.Builder</returns>
            public virtual Editor.Builder DirectEvents(Action<InlineEditorDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as Editor.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual Editor.Builder CancelEdit(bool remainVisible)
            {
                this.ToComponent().CancelEdit(remainVisible);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Editor.Builder CancelEdit()
            {
                this.ToComponent().CancelEdit();
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Editor.Builder CompleteEdit(bool remainVisible)
            {
                this.ToComponent().CompleteEdit(remainVisible);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Editor.Builder CompleteEdit()
            {
                this.ToComponent().CompleteEdit();
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Editor.Builder Realign()
            {
                this.ToComponent().Realign();
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual Editor.Builder Realign(bool autoSize)
            {
                this.ToComponent().Realign(autoSize);
                return this;
            }
            
 			/// <summary>
			/// Starts the editing process and shows the editor.
			/// </summary>
            public virtual Editor.Builder StartEdit(string el, string value)
            {
                this.ToComponent().StartEdit(el, value);
                return this;
            }
            
 			/// <summary>
			/// Starts the editing process and shows the editor.
			/// </summary>
            public virtual Editor.Builder StartEdit(string el)
            {
                this.ToComponent().StartEdit(el);
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public Editor.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Editor(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Editor.Builder Editor()
        {
            return this.Editor(new Editor());
        }

        /// <summary>
        /// 
        /// </summary>
        public Editor.Builder Editor(Editor component)
        {
            return new Editor.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Editor.Builder Editor(Editor.Config config)
        {
            return new Editor.Builder(new Editor(config));
        }
    }
}