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
    public abstract partial class AbstractDrawComponent
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : ComponentBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoSize = false;

			/// <summary>
			/// Turn on autoSize support which will set the bounding div's size to the natural size of the contents. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoSize 
			{ 
				get
				{
					return this.autoSize;
				}
				set
				{
					this.autoSize = value;
				}
			}

			private string[] enginePriority = null;

			/// <summary>
			/// Defines the priority order for which Surface implementation to use. The first one supported by the current environment will be used. Defaults to: [\"Svg\", \"Vml\"]
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] EnginePriority 
			{ 
				get
				{
					return this.enginePriority;
				}
				set
				{
					this.enginePriority = value;
				}
			}
        
			private Gradients gradients = null;

			/// <summary>
			/// Define a set of gradients that can be used as fill property in sprites.
			/// </summary>
			public Gradients Gradients
			{
				get
				{
					if (this.gradients == null)
					{
						this.gradients = new Gradients();
					}
			
					return this.gradients;
				}
			}
			
			private bool viewBox = true;

			/// <summary>
			/// Turn on view box support which will scale and position items in the draw component to fit to the component while maintaining aspect ratio. Note that this scaling can override other sizing settings on yor items. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ViewBox 
			{ 
				get
				{
					return this.viewBox;
				}
				set
				{
					this.viewBox = value;
				}
			}

			private DrawBackground background = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual DrawBackground Background 
			{ 
				get
				{
					return this.background;
				}
				set
				{
					this.background = value;
				}
			}
        
			private SpriteCollection items = null;

			/// <summary>
			/// 
			/// </summary>
			public SpriteCollection Items
			{
				get
				{
					if (this.items == null)
					{
						this.items = new SpriteCollection();
					}
			
					return this.items;
				}
			}
			
        }
    }
}