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
using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class SliderBase : Field
    {
        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return this.Single ? "slider" : "multislider";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return this.Single ? "Ext.slider.Single" : "Ext.slider.Multi";
            }
        }

        /// <summary>
        /// True for single thumb slider
        /// </summary>
        [Meta]
        [Category("5. Slider")]
        [DefaultValue(false)]
        [Description("True for single thumb slider")]
        public virtual bool Single
        {
            get
            {
                return this.State.Get<bool>("Single", false);
            }
            set
            {
                this.State.Set("Single", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual double[] CheckRange(double[] numbers)
        {
            if (numbers == null)
            {
                return null;
            }

            double[] newNumbers = new double[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                double number = this.MinValue > numbers[i] ? this.MinValue : numbers[i];
                newNumbers[i] = this.MaxValue < number ? this.MaxValue : number;
            }

            return newNumbers;
        }

        /// <summary>
        /// Thumbs value
        /// </summary>
        [Meta]
        [Category("Appearance")]
        [DefaultValue(null)]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("Thumbs value")]
        public virtual double? Number
        {
            get
            {
                var numbers = this.Numbers;
                if (numbers != null && numbers.Length > 0)
                {
                    return this.Numbers[0];
                }
                return null;
            }
            set
            {
                if (value == null)
                {
                    this.Value = null;
                }
                else
                {
                    this.Numbers = new double[] { value.Value };
                }
            }
        }

        /// <summary>
        /// Thumbs values array
        /// </summary>
        [TypeConverter(typeof(DoubleArrayConverter))]
        [DefaultValue(null)]
        [Description("Thumbs values list")]
        public virtual double[] Numbers
        {
            get
            {
                return this.State.Get<double[]>("Value", null);                
            }
            set
            {
                this.State.Set("Value",this.CheckRange(value));
            }
        }
        
        /// <summary>
        /// Turn on or off animation. Defaults to true
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Turn on or off animation. Defaults to true")]
        public virtual bool Animate
        {
            get
            {
                return this.State.Get<bool>("Animate", true);
            }
            set
            {
                this.State.Set("Animate", value);
            }
        }

        /// <summary>
        /// Determines whether or not clicking on the Slider axis will change the slider. Defaults to true
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Determines whether or not clicking on the Slider axis will change the slider. Defaults to true")]
        public virtual bool ClickToChange
        {
            get
            {
                return this.State.Get<bool>("ClickToChange", true);
            }
            set
            {
                this.State.Set("ClickToChange", value);
            }
        }

        /// <summary>
        /// True to disallow thumbs from overlapping one another. Defaults to true
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to disallow thumbs from overlapping one another. Defaults to true")]
        public virtual bool ConstrainThumbs
        {
            get
            {
                return this.State.Get<bool>("ConstrainThumbs", true);
            }
            set
            {
                this.State.Set("ConstrainThumbs", value);
            }
        }

        /// <summary>
        /// The number of decimal places to which to round the Slider's value. Defaults to 0.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("The number of decimal places to which to round the Slider's value. Defaults to 0.")]
        public virtual int DecimalPrecision
        {
            get
            {
                return this.State.Get<int>("DecimalPrecision", 0);
            }
            set
            {
                this.State.Set("DecimalPrecision", value);
            }
        }

        /// <summary>
        /// How many units to change the slider when adjusting by drag and drop. Use this option to enable 'snapping'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("How many units to change the slider when adjusting by drag and drop. Use this option to enable 'snapping'.")]
        public virtual int Increment
        {
            get
            {
                return this.State.Get<int>("Increment", 0);
            }
            set
            {
                this.State.Set("Increment", value);
            }
        }

        /// <summary>
        /// How many units to change the Slider when adjusting with keyboard navigation. Defaults to 1. If the increment config is larger, it will be used instead.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(1)]
        [NotifyParentProperty(true)]
        [Description("How many units to change the Slider when adjusting with keyboard navigation. Defaults to 1. If the increment config is larger, it will be used instead.")]
        public virtual int KeyIncrement
        {
            get
            {
                return this.State.Get<int>("KeyIncrement", 1);
            }
            set
            {
                this.State.Set("KeyIncrement", value);
            }
        }

        /// <summary>
        /// The maximum value for the Slider. Defaults to 100.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(100d)]
        [DirectEventUpdate(MethodName = "SetMaxValue")]
        [NotifyParentProperty(true)]
        [Description("The maximum value for the Slider. Defaults to 100.")]
        public virtual double MaxValue
        {
            get
            {
                return this.State.Get<double>("MaxValue", 100d);
            }
            set
            {
                this.State.Set("MaxValue", value);
            }
        }

        /// <summary>
        /// The minimum value for the Slider. Defaults to 0.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(0d)]
        [DirectEventUpdate(MethodName = "SetMinValue")]
        [NotifyParentProperty(true)]
        [Description("The minimum value for the Slider. Defaults to 0.")]
        public virtual double MinValue
        {
            get
            {
                return this.State.Get<double>("MinValue", 0d);
            }
            set
            {
                this.State.Set("MinValue", value);
            }
        }

        /// <summary>
        /// Orient the Slider vertically rather than horizontally, defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Orient the Slider vertically rather than horizontally, defaults to false.")]
        public virtual bool Vertical
        {
            get
            {
                return this.State.Get<bool>("Vertical", false);
            }
            set
            {
                this.State.Set("Vertical", value);
            }
        }

        /// <summary>
        /// True to use an Ext.slider.Tip to display tips for the value. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to use an Ext.slider.Tip to display tips for the value. Defaults to: true")]
        public virtual bool UseTips
        {
            get
            {
                return this.State.Get<bool>("UseTips", true);
            }
            set
            {
                this.State.Set("UseTips", value);
            }
        }

        private JFunction tipText;

        /// <summary>
        /// A function used to display custom text for the slider tip. Defaults to null, which will use the default on the plugin.
        /// Parameters:
        ///     thumb : Thumbnail
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("5. Slider")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("A function used to display custom text for the slider tip. Defaults to null, which will use the default on the plugin.")]
        public virtual JFunction TipText
        {
            get
            {
                if (this.tipText == null)
                {
                    this.tipText = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.tipText.Args = new string[] { "thumb" };
                    }
                }

                return this.tipText;
            }
        }

        /// <summary>
        /// A value to initialize this field with.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetValueProxy")]
        [Category("5. Field")]
        [DefaultValue(null)]
        [Description("A value to initialize this field with.")]
        public override object Value
        {
            get
            {
                return this.State.Get<object>("Value", null);
            }
            set
            {
                if (value is double[])
                {
                    this.State.Set("Value", value);
                }
                else
                {
                    this.State.Set("Value", new double[] { Convert.ToDouble(value) });
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("values", JsonMode.Serialize)]
        [DefaultValue(null)]
        protected internal override object ValueProxy
        {
            get
            {
                if (!this.IsEmpty)
                {
                    return this.Value;
                }

                return null;
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Synchronizes the thumb position to the proper proportion of the total component width based on the current slider value. This will be called automatically when the Slider is resized by a layout, but if it is rendered auto width, this method can be called from another resize handler to sync the Slider if necessary.
        /// </summary>
        [Meta]
        [Description("Synchronizes the thumb position to the proper proportion of the total component width based on the current slider value. This will be called automatically when the Slider is resized by a layout, but if it is rendered auto width, this method can be called from another resize handler to sync the Slider if necessary.")]
        public virtual void SyncThumb()
        {
            this.Call("syncThumb");
        }

        /// <summary>
        /// Creates a new thumb and adds it to the slider
        /// </summary>
        [Meta]
        [Description("Creates a new thumb and adds it to the slider")]
        public virtual void AddThumb(int value)
        {
            this.Call("addThumb", value);
        }

        /// <summary>
        /// Sets the maximum value for the slider instance. If the current value is more than the maximum value, the current value will be changed.
        /// </summary>
        /// <param name="value">The maximum value</param>
        public virtual void SetMaxValue(Double value)
        {
            this.Call("setMaxValue", value);
        }

        /// <summary>
        /// Sets the minimum value for the slider instance. If the current value is less than the minimum value, the current value will be changed.
        /// </summary>
        /// <param name="value">The minimum value</param>
        public virtual void SetMinValue(Double value)
        {
            this.Call("setMinValue", value);
        }

        /// <summary>
        /// Sets a data value into the field and runs the change detection and validation. To set the value directly without these inspections see setRawValue.
        /// </summary>
        /// <param name="value">The value to set</param>
        protected override void SetValueProxy(object value)
        {
            if (value is double[])
            {
                var arr = (double[])value;
                for (int i = 0; i < arr.Length; i++)
                {
                    this.Call("setValue", i, arr[i]);    
                }
            }
            else
            {
                this.Call("setValue", value);
            }
        }

        /// <summary>
        /// Programmatically sets the value of the Slider. Ensures that the value is constrained within the minValue and maxValue.
        /// </summary>
        /// <param name="index">Index of the thumb to move</param>
        /// <param name="value">The value to set the slider to. (This will be constrained within minValue and maxValue)</param>
        /// <param name="animate">Turn on or off animation</param>
        public virtual void SetValue(int index, double value, bool animate)
        {
            this.Call("setValue", index, value, animate);    
        }

        /// <summary>
        /// Programmatically sets the value of the Slider. Ensures that the value is constrained within the minValue and maxValue.
        /// </summary>
        /// <param name="index">Index of the thumb to move</param>
        /// <param name="value">The value to set the slider to. (This will be constrained within minValue and maxValue)</param>
        public virtual void SetValue(int index, double value)
        {
            this.Call("setValue", index, value);
        }
    }
}