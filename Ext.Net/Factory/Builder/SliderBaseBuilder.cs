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
    public abstract partial class SliderBase
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TSliderBase, TBuilder> : Field.Builder<TSliderBase, TBuilder>
            where TSliderBase : SliderBase
            where TBuilder : Builder<TSliderBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TSliderBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True for single thumb slider
			/// </summary>
            public virtual TBuilder Single(bool single)
            {
                this.ToComponent().Single = single;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Thumbs value
			/// </summary>
            public virtual TBuilder Number(double? number)
            {
                this.ToComponent().Number = number;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Turn on or off animation. Defaults to true
			/// </summary>
            public virtual TBuilder Animate(bool animate)
            {
                this.ToComponent().Animate = animate;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Determines whether or not clicking on the Slider axis will change the slider. Defaults to true
			/// </summary>
            public virtual TBuilder ClickToChange(bool clickToChange)
            {
                this.ToComponent().ClickToChange = clickToChange;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to disallow thumbs from overlapping one another. Defaults to true
			/// </summary>
            public virtual TBuilder ConstrainThumbs(bool constrainThumbs)
            {
                this.ToComponent().ConstrainThumbs = constrainThumbs;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The number of decimal places to which to round the Slider's value. Defaults to 0.
			/// </summary>
            public virtual TBuilder DecimalPrecision(int decimalPrecision)
            {
                this.ToComponent().DecimalPrecision = decimalPrecision;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// How many units to change the slider when adjusting by drag and drop. Use this option to enable 'snapping'.
			/// </summary>
            public virtual TBuilder Increment(int increment)
            {
                this.ToComponent().Increment = increment;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// How many units to change the Slider when adjusting with keyboard navigation. Defaults to 1. If the increment config is larger, it will be used instead.
			/// </summary>
            public virtual TBuilder KeyIncrement(int keyIncrement)
            {
                this.ToComponent().KeyIncrement = keyIncrement;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum value for the Slider. Defaults to 100.
			/// </summary>
            public virtual TBuilder MaxValue(double maxValue)
            {
                this.ToComponent().MaxValue = maxValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum value for the Slider. Defaults to 0.
			/// </summary>
            public virtual TBuilder MinValue(double minValue)
            {
                this.ToComponent().MinValue = minValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Orient the Slider vertically rather than horizontally, defaults to false.
			/// </summary>
            public virtual TBuilder Vertical(bool vertical)
            {
                this.ToComponent().Vertical = vertical;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to use an Ext.slider.Tip to display tips for the value. Defaults to: true
			/// </summary>
            public virtual TBuilder UseTips(bool useTips)
            {
                this.ToComponent().UseTips = useTips;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A value to initialize this field with.
			/// </summary>
            public virtual TBuilder Value(object value)
            {
                this.ToComponent().Value = value;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Synchronizes the thumb position to the proper proportion of the total component width based on the current slider value. This will be called automatically when the Slider is resized by a layout, but if it is rendered auto width, this method can be called from another resize handler to sync the Slider if necessary.
			/// </summary>
            public virtual TBuilder SyncThumb()
            {
                this.ToComponent().SyncThumb();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Creates a new thumb and adds it to the slider
			/// </summary>
            public virtual TBuilder AddThumb(int value)
            {
                this.ToComponent().AddThumb(value);
                return this as TBuilder;
            }
            
        }        
    }
}