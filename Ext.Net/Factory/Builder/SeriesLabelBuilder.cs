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
    public partial class SeriesLabel
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : SpriteAttributes.Builder<SeriesLabel, SeriesLabel.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new SeriesLabel()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SeriesLabel component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SeriesLabel.Config config) : base(new SeriesLabel(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(SeriesLabel component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Specifies the presence and position of labels for each pie slice.
			/// </summary>
            public virtual SeriesLabel.Builder Display(SeriesLabelDisplay display)
            {
                this.ToComponent().Display = display;
                return this as SeriesLabel.Builder;
            }
             
 			/// <summary>
			/// The color of the label text. Default value: '#000' (black).
			/// </summary>
            public virtual SeriesLabel.Builder Color(string color)
            {
                this.ToComponent().Color = color;
                return this as SeriesLabel.Builder;
            }
             
 			/// <summary>
			/// True to render the label in contrasting color with the backround. Default value: false.
			/// </summary>
            public virtual SeriesLabel.Builder Contrast(bool contrast)
            {
                this.ToComponent().Contrast = contrast;
                return this as SeriesLabel.Builder;
            }
             
 			/// <summary>
			/// The name of the field to be displayed in the label. Default value: 'name'.
			/// </summary>
            public virtual SeriesLabel.Builder Field(string field)
            {
                this.ToComponent().Field = field;
                return this as SeriesLabel.Builder;
            }
             
 			/// <summary>
			/// Specifies the minimum distance from a label to the origin of the visualization. This parameter is useful when using PieSeries width variable pie slice lengths. Default value: 50.
			/// </summary>
            public virtual SeriesLabel.Builder MinMargin(int minMargin)
            {
                this.ToComponent().MinMargin = minMargin;
                return this as SeriesLabel.Builder;
            }
             
 			/// <summary>
			/// The font used for the labels. Default value: \"11px Helvetica, sans-serif\".
			/// </summary>
            public virtual SeriesLabel.Builder Font(string font)
            {
                this.ToComponent().Font = font;
                return this as SeriesLabel.Builder;
            }
             
 			/// <summary>
			/// Either \"horizontal\" or \"vertical\". Dafault value: \"horizontal\".
			/// </summary>
            public virtual SeriesLabel.Builder Orientation(Orientation orientation)
            {
                this.ToComponent().Orientation = orientation;
                return this as SeriesLabel.Builder;
            }
             
 			/// <summary>
			/// Optional function for formatting the label into a displayable value. Default value: function(value) { return value; }
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of SeriesLabel.Builder</returns>
            public virtual SeriesLabel.Builder Renderer(Action<JFunction> action)
            {
                action(this.ToComponent().Renderer);
                return this as SeriesLabel.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public SeriesLabel.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.SeriesLabel(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public SeriesLabel.Builder SeriesLabel()
        {
            return this.SeriesLabel(new SeriesLabel());
        }

        /// <summary>
        /// 
        /// </summary>
        public SeriesLabel.Builder SeriesLabel(SeriesLabel component)
        {
            return new SeriesLabel.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public SeriesLabel.Builder SeriesLabel(SeriesLabel.Config config)
        {
            return new SeriesLabel.Builder(new SeriesLabel(config));
        }
    }
}