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
    public partial class ToolTip
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Tip.Builder<ToolTip, ToolTip.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ToolTip()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ToolTip component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ToolTip.Config config) : base(new ToolTip(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ToolTip component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual ToolTip.Builder ForceRendering(bool forceRendering)
            {
                this.ToComponent().ForceRendering = forceRendering;
                return this as ToolTip.Builder;
            }
             
 			/// <summary>
			/// If specified, indicates that the tip should be anchored to a particular side of the target element or mouse pointer (\"top\", \"right\", \"bottom\", or \"left\"), with an arrow pointing back at the target or mouse pointer. If constrainPosition is enabled, this will be used as a preferred value only and may be flipped as needed.
			/// </summary>
            public virtual ToolTip.Builder Anchor(string anchor)
            {
                this.ToComponent().Anchor = anchor;
                return this as ToolTip.Builder;
            }
             
 			/// <summary>
			/// A numeric pixel value used to offset the default position of the anchor arrow. When the anchor position is on the top or bottom of the tooltip, anchorOffset will be used as a horizontal offset. Likewise, when the anchor position is on the left or right side, anchorOffset will be used as a vertical offset. Defaults to: 0
			/// </summary>
            public virtual ToolTip.Builder AnchorOffset(int anchorOffset)
            {
                this.ToComponent().AnchorOffset = anchorOffset;
                return this as ToolTip.Builder;
            }
             
 			/// <summary>
			/// True to anchor the tooltip to the target element, false to anchor it relative to the mouse coordinates. When anchorToTarget is true, use defaultAlign to control tooltip alignment to the target element. When anchorToTarget is false, use anchor instead to control alignment. Defaults to: true
			/// </summary>
            public virtual ToolTip.Builder AnchorToTarget(bool anchorToTarget)
            {
                this.ToComponent().AnchorToTarget = anchorToTarget;
                return this as ToolTip.Builder;
            }
             
 			/// <summary>
			/// True to automatically hide the tooltip after the mouse exits the target element or after the dismissDelay has expired if set (defaults to true). If closable = true a close tool button will be rendered into the tooltip header.
			/// </summary>
            public virtual ToolTip.Builder AutoHide(bool autoHide)
            {
                this.ToComponent().AutoHide = autoHide;
                return this as ToolTip.Builder;
            }
             
 			/// <summary>
			/// A DomQuery selector which allows selection of individual elements within the target element to trigger showing and hiding the ToolTip as the mouse moves within the target.
			/// </summary>
            public virtual ToolTip.Builder Delegate(string _delegate)
            {
                this.ToComponent().Delegate = _delegate;
                return this as ToolTip.Builder;
            }
             
 			/// <summary>
			/// Delay in milliseconds before the tooltip automatically hides (defaults to 5000). To disable automatic hiding, set dismissDelay = 0.
			/// </summary>
            public virtual ToolTip.Builder DismissDelay(int dismissDelay)
            {
                this.ToComponent().DismissDelay = dismissDelay;
                return this as ToolTip.Builder;
            }
             
 			/// <summary>
			/// Delay in milliseconds after the mouse exits the target element but before the tooltip actually hides (defaults to 200). Set to 0 for the tooltip to hide immediately.
			/// </summary>
            public virtual ToolTip.Builder HideDelay(int hideDelay)
            {
                this.ToComponent().HideDelay = hideDelay;
                return this as ToolTip.Builder;
            }
             
 			/// <summary>
			/// An XY offset from the mouse position where the tooltip should be shown (defaults to [15,18]).
			/// </summary>
            public virtual ToolTip.Builder MouseOffset(int[] mouseOffset)
            {
                this.ToComponent().MouseOffset = mouseOffset;
                return this as ToolTip.Builder;
            }
             
 			/// <summary>
			/// Delay in milliseconds before the tooltip displays after the mouse enters the target element (defaults to 500).
			/// </summary>
            public virtual ToolTip.Builder ShowDelay(int showDelay)
            {
                this.ToComponent().ShowDelay = showDelay;
                return this as ToolTip.Builder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ToolTip.Builder</returns>
            public virtual ToolTip.Builder TargetControl(Action<Control> action)
            {
                action(this.ToComponent().TargetControl);
                return this as ToolTip.Builder;
            }
			 
 			/// <summary>
			/// The target id to associate with this tooltip.
			/// </summary>
            public virtual ToolTip.Builder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as ToolTip.Builder;
            }
             
 			/// <summary>
			/// True to have the tooltip follow the mouse as it moves over the target element (defaults to false).
			/// </summary>
            public virtual ToolTip.Builder TrackMouse(bool trackMouse)
            {
                this.ToComponent().TrackMouse = trackMouse;
                return this as ToolTip.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ToolTip.Builder</returns>
            public virtual ToolTip.Builder Listeners(Action<PanelListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as ToolTip.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of ToolTip.Builder</returns>
            public virtual ToolTip.Builder DirectEvents(Action<PanelDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as ToolTip.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ToolTip.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ToolTip(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ToolTip.Builder ToolTip()
        {
            return this.ToolTip(new ToolTip());
        }

        /// <summary>
        /// 
        /// </summary>
        public ToolTip.Builder ToolTip(ToolTip component)
        {
            return new ToolTip.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ToolTip.Builder ToolTip(ToolTip.Config config)
        {
            return new ToolTip.Builder(new ToolTip(config));
        }
    }
}