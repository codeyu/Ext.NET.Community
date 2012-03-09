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
    public partial class HtmlEditorButtonTips
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseItem.Builder<HtmlEditorButtonTips, HtmlEditorButtonTips.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new HtmlEditorButtonTips()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(HtmlEditorButtonTips component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(HtmlEditorButtonTips.Config config) : base(new HtmlEditorButtonTips(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(HtmlEditorButtonTips component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of HtmlEditorButtonTips.Builder</returns>
            public virtual HtmlEditorButtonTips.Builder Bold(Action<HtmlEditorButtonTip> action)
            {
                action(this.ToComponent().Bold);
                return this as HtmlEditorButtonTips.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of HtmlEditorButtonTips.Builder</returns>
            public virtual HtmlEditorButtonTips.Builder Italic(Action<HtmlEditorButtonTip> action)
            {
                action(this.ToComponent().Italic);
                return this as HtmlEditorButtonTips.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of HtmlEditorButtonTips.Builder</returns>
            public virtual HtmlEditorButtonTips.Builder Underline(Action<HtmlEditorButtonTip> action)
            {
                action(this.ToComponent().Underline);
                return this as HtmlEditorButtonTips.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of HtmlEditorButtonTips.Builder</returns>
            public virtual HtmlEditorButtonTips.Builder IncreaseFontSize(Action<HtmlEditorButtonTip> action)
            {
                action(this.ToComponent().IncreaseFontSize);
                return this as HtmlEditorButtonTips.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of HtmlEditorButtonTips.Builder</returns>
            public virtual HtmlEditorButtonTips.Builder DecreaseFontSize(Action<HtmlEditorButtonTip> action)
            {
                action(this.ToComponent().DecreaseFontSize);
                return this as HtmlEditorButtonTips.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of HtmlEditorButtonTips.Builder</returns>
            public virtual HtmlEditorButtonTips.Builder BackColor(Action<HtmlEditorButtonTip> action)
            {
                action(this.ToComponent().BackColor);
                return this as HtmlEditorButtonTips.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of HtmlEditorButtonTips.Builder</returns>
            public virtual HtmlEditorButtonTips.Builder ForeColor(Action<HtmlEditorButtonTip> action)
            {
                action(this.ToComponent().ForeColor);
                return this as HtmlEditorButtonTips.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of HtmlEditorButtonTips.Builder</returns>
            public virtual HtmlEditorButtonTips.Builder JustifyLeft(Action<HtmlEditorButtonTip> action)
            {
                action(this.ToComponent().JustifyLeft);
                return this as HtmlEditorButtonTips.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of HtmlEditorButtonTips.Builder</returns>
            public virtual HtmlEditorButtonTips.Builder JustifyCenter(Action<HtmlEditorButtonTip> action)
            {
                action(this.ToComponent().JustifyCenter);
                return this as HtmlEditorButtonTips.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of HtmlEditorButtonTips.Builder</returns>
            public virtual HtmlEditorButtonTips.Builder JustifyRight(Action<HtmlEditorButtonTip> action)
            {
                action(this.ToComponent().JustifyRight);
                return this as HtmlEditorButtonTips.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of HtmlEditorButtonTips.Builder</returns>
            public virtual HtmlEditorButtonTips.Builder InsertUnorderedList(Action<HtmlEditorButtonTip> action)
            {
                action(this.ToComponent().InsertUnorderedList);
                return this as HtmlEditorButtonTips.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of HtmlEditorButtonTips.Builder</returns>
            public virtual HtmlEditorButtonTips.Builder InsertOrderedList(Action<HtmlEditorButtonTip> action)
            {
                action(this.ToComponent().InsertOrderedList);
                return this as HtmlEditorButtonTips.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of HtmlEditorButtonTips.Builder</returns>
            public virtual HtmlEditorButtonTips.Builder CreateLink(Action<HtmlEditorButtonTip> action)
            {
                action(this.ToComponent().CreateLink);
                return this as HtmlEditorButtonTips.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of HtmlEditorButtonTips.Builder</returns>
            public virtual HtmlEditorButtonTips.Builder SourceEdit(Action<HtmlEditorButtonTip> action)
            {
                action(this.ToComponent().SourceEdit);
                return this as HtmlEditorButtonTips.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public HtmlEditorButtonTips.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.HtmlEditorButtonTips(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public HtmlEditorButtonTips.Builder HtmlEditorButtonTips()
        {
            return this.HtmlEditorButtonTips(new HtmlEditorButtonTips());
        }

        /// <summary>
        /// 
        /// </summary>
        public HtmlEditorButtonTips.Builder HtmlEditorButtonTips(HtmlEditorButtonTips component)
        {
            return new HtmlEditorButtonTips.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public HtmlEditorButtonTips.Builder HtmlEditorButtonTips(HtmlEditorButtonTips.Config config)
        {
            return new HtmlEditorButtonTips.Builder(new HtmlEditorButtonTips(config));
        }
    }
}