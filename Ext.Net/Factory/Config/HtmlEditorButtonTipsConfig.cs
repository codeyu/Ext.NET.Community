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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public HtmlEditorButtonTips(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit HtmlEditorButtonTips.Config Conversion to HtmlEditorButtonTips
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator HtmlEditorButtonTips(HtmlEditorButtonTips.Config config)
        {
            return new HtmlEditorButtonTips(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BaseItem.Config 
        { 
			/*  Implicit HtmlEditorButtonTips.Config Conversion to HtmlEditorButtonTips.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator HtmlEditorButtonTips.Builder(HtmlEditorButtonTips.Config config)
			{
				return new HtmlEditorButtonTips.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private HtmlEditorButtonTip bold = null;

			/// <summary>
			/// 
			/// </summary>
			public HtmlEditorButtonTip Bold
			{
				get
				{
					if (this.bold == null)
					{
						this.bold = new HtmlEditorButtonTip();
					}
			
					return this.bold;
				}
			}
			        
			private HtmlEditorButtonTip italic = null;

			/// <summary>
			/// 
			/// </summary>
			public HtmlEditorButtonTip Italic
			{
				get
				{
					if (this.italic == null)
					{
						this.italic = new HtmlEditorButtonTip();
					}
			
					return this.italic;
				}
			}
			        
			private HtmlEditorButtonTip underline = null;

			/// <summary>
			/// 
			/// </summary>
			public HtmlEditorButtonTip Underline
			{
				get
				{
					if (this.underline == null)
					{
						this.underline = new HtmlEditorButtonTip();
					}
			
					return this.underline;
				}
			}
			        
			private HtmlEditorButtonTip increaseFontSize = null;

			/// <summary>
			/// 
			/// </summary>
			public HtmlEditorButtonTip IncreaseFontSize
			{
				get
				{
					if (this.increaseFontSize == null)
					{
						this.increaseFontSize = new HtmlEditorButtonTip();
					}
			
					return this.increaseFontSize;
				}
			}
			        
			private HtmlEditorButtonTip decreaseFontSize = null;

			/// <summary>
			/// 
			/// </summary>
			public HtmlEditorButtonTip DecreaseFontSize
			{
				get
				{
					if (this.decreaseFontSize == null)
					{
						this.decreaseFontSize = new HtmlEditorButtonTip();
					}
			
					return this.decreaseFontSize;
				}
			}
			        
			private HtmlEditorButtonTip backColor = null;

			/// <summary>
			/// 
			/// </summary>
			public HtmlEditorButtonTip BackColor
			{
				get
				{
					if (this.backColor == null)
					{
						this.backColor = new HtmlEditorButtonTip();
					}
			
					return this.backColor;
				}
			}
			        
			private HtmlEditorButtonTip foreColor = null;

			/// <summary>
			/// 
			/// </summary>
			public HtmlEditorButtonTip ForeColor
			{
				get
				{
					if (this.foreColor == null)
					{
						this.foreColor = new HtmlEditorButtonTip();
					}
			
					return this.foreColor;
				}
			}
			        
			private HtmlEditorButtonTip justifyLeft = null;

			/// <summary>
			/// 
			/// </summary>
			public HtmlEditorButtonTip JustifyLeft
			{
				get
				{
					if (this.justifyLeft == null)
					{
						this.justifyLeft = new HtmlEditorButtonTip();
					}
			
					return this.justifyLeft;
				}
			}
			        
			private HtmlEditorButtonTip justifyCenter = null;

			/// <summary>
			/// 
			/// </summary>
			public HtmlEditorButtonTip JustifyCenter
			{
				get
				{
					if (this.justifyCenter == null)
					{
						this.justifyCenter = new HtmlEditorButtonTip();
					}
			
					return this.justifyCenter;
				}
			}
			        
			private HtmlEditorButtonTip justifyRight = null;

			/// <summary>
			/// 
			/// </summary>
			public HtmlEditorButtonTip JustifyRight
			{
				get
				{
					if (this.justifyRight == null)
					{
						this.justifyRight = new HtmlEditorButtonTip();
					}
			
					return this.justifyRight;
				}
			}
			        
			private HtmlEditorButtonTip insertUnorderedList = null;

			/// <summary>
			/// 
			/// </summary>
			public HtmlEditorButtonTip InsertUnorderedList
			{
				get
				{
					if (this.insertUnorderedList == null)
					{
						this.insertUnorderedList = new HtmlEditorButtonTip();
					}
			
					return this.insertUnorderedList;
				}
			}
			        
			private HtmlEditorButtonTip insertOrderedList = null;

			/// <summary>
			/// 
			/// </summary>
			public HtmlEditorButtonTip InsertOrderedList
			{
				get
				{
					if (this.insertOrderedList == null)
					{
						this.insertOrderedList = new HtmlEditorButtonTip();
					}
			
					return this.insertOrderedList;
				}
			}
			        
			private HtmlEditorButtonTip createLink = null;

			/// <summary>
			/// 
			/// </summary>
			public HtmlEditorButtonTip CreateLink
			{
				get
				{
					if (this.createLink == null)
					{
						this.createLink = new HtmlEditorButtonTip();
					}
			
					return this.createLink;
				}
			}
			        
			private HtmlEditorButtonTip sourceEdit = null;

			/// <summary>
			/// 
			/// </summary>
			public HtmlEditorButtonTip SourceEdit
			{
				get
				{
					if (this.sourceEdit == null)
					{
						this.sourceEdit = new HtmlEditorButtonTip();
					}
			
					return this.sourceEdit;
				}
			}
			
        }
    }
}