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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Base class for Numeric field.
    /// </summary>
    [Meta]   
    [Description("Base class for Numeric field.")]
    public abstract partial class NumberFieldBase : SpinnerFieldBase
    {
        /// <summary>
        /// The fields null value.
        /// </summary>
        [Category("5. Field")]
        [Description("The fields null value.")]
        public override object EmptyValue
        {
            get
            {
                return this.State.Get<object>("EmptyValue", double.MinValue);
            }
            set
            {
                this.State.Set("EmptyValue", value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [Browsable(false)]
        [DefaultValue(InputType.Text)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description()]
        public override InputType InputType
        {
            get
            {
                return InputType.Text;
            }
            set
            {
                base.InputType = value;
            }
        }

        /// <summary>
        /// The Text value to initialize this field with.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue("")]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("The Text value to initialize this field with.")]
        public override string Text
        {
            get
            {
                return !this.IsEmpty ? this.Number.ToString(NumberFormatInfo.InvariantInfo) : "";
            }
            set
            {
                this.Number = this.CheckRange(value);
            }
        }

        /// <summary>
        /// The Number (double) to initialize this field with.
        /// </summary>
        [Meta]
        [Category("Appearance")]
        [DefaultValue(double.MinValue)]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("The Number (double) to initialize this field with.")]
        public virtual double Number
        {
            get
            {
                return this.CheckRange(Convert.ToDouble(this.Value == null ? this.EmptyValue : this.Value));
            }
            set
            {
                this.Value = this.CheckRange(value);
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual double CheckRange(string value)
        {
            if (value.IsEmpty() || value == this.EmptyText || value == this.BlankText)
            {
                return double.MinValue;
            }
            
            Double number;

            try
            {
                if (this.DecimalSeparator.IsNotEmpty())
                {
                    NumberFormatInfo nf = new NumberFormatInfo();
                    nf.NumberDecimalSeparator = this.DecimalSeparator;
                    number = Double.Parse(value, nf);
                }
                else
                {
                    number = Double.Parse(value, NumberFormatInfo.InvariantInfo);
                }
                
            }
            catch (Exception exception)
            {
                throw new InvalidCastException("The Text value supplied is not a type of Double. " + exception.Message);
            }

            return this.CheckRange(number);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual double CheckRange(double number)
        {
            number = this.MinValue > number ? this.MinValue : number;

            return this.MaxValue < number ? this.MaxValue : number;
        }


        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        [Description("")]
        protected override void Render(HtmlTextWriter writer)
        {
            if (this.MinValue > this.MaxValue)
            {
                throw new ArgumentOutOfRangeException("MinValue", "The MinValue must be less then the MaxValue.");
            }

            base.Render(writer);
        }

        private static readonly object EventNumberChanged = new object();

        /// <summary>
        /// Fires when the Number property has been changed.
        /// </summary>
        [Category("Action")]
        [Description("Fires when the Text property has been changed.")]
        public event EventHandler NumberChanged
        {
            add
            {
                Events.AddHandler(EventNumberChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventNumberChanged, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnNumberChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventNumberChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void RaisePostDataChangedEvent()
        {
            base.RaisePostDataChangedEvent();
            this.OnNumberChanged(EventArgs.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.UniqueName];
            bool raise = false;

            double number = val.IsEmpty() ? Convert.ToDouble(this.EmptyValue) : this.CheckRange(val);

            this.SuspendScripting();
            this.RawValue = val;
            this.ResumeScripting();

            if (val != null && this.Number != number)
            {
                raise = true;
                this.SuspendScripting();
                try
                {
                    this.Number = number;
                }
                finally
                {
                    this.ResumeScripting();
                }
            }

            return raise;
        }


        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// False to disallow decimal values (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue(true)]
        [Description("False to disallow decimal values (defaults to true).")]
        public virtual bool AllowDecimals
        {
            get
            {
                return this.State.Get<bool>("AllowDecimals", true);
            }
            set
            {
                this.State.Set("AllowDecimals", value);
            }
        }

        /// <summary>
        /// True to automatically strip not allowed characters from the field. Defaults to false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue(false)]
        [Description("True to automatically strip not allowed characters from the field. Defaults to false")]
        public virtual bool AutoStripChars
        {
            get
            {
                return this.State.Get<bool>("AutoStripChars", false);
            }
            set
            {
                this.State.Set("AutoStripChars", value);
            }
        }

        /// <summary>
        /// The base set of characters to evaluate as valid numbers (defaults to '0123456789').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue("0123456789")]
        [Description("The base set of characters to evaluate as valid numbers (defaults to '0123456789').")]
        public virtual string BaseChars
        {
            get
            {
                return this.State.Get<string>("BaseChars", "0123456789");
            }
            set
            {
                this.State.Set("BaseChars", value);
            }
        }

        /// <summary>
        /// The maximum precision to display after the decimal separator (defaults to 2).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue(2)]
        [Description("The maximum precision to display after the decimal separator (defaults to 2).")]
        public virtual int DecimalPrecision
        {
            get
            {
                return this.State.Get<int>("DecimalPrecision", 2);
            }
            set
            {
                this.State.Set("DecimalPrecision", value);
            }
        }

        /// <summary>
        /// Character(s) to allow as the decimal separator (defaults to '.').
        /// </summary>
        [Meta]        
        [Category("7. NumberField")]
        [DefaultValue(".")]
        [Description("Character(s) to allow as the decimal separator (defaults to '.').")]
        public virtual string DecimalSeparator
        {
            get
            {
                string separator = this.State.Get<string>("DecimalSeparator", "");

                if (separator.IsNotEmpty())
                {
                    return separator;
                }

                ResourceManager rm = this.SafeResourceManager;

                if (rm != null)
                {
                    CultureInfo locale = rm.CurrentLocale;
                    return locale.NumberFormat.NumberDecimalSeparator;
                }

                return ".";
            }
            set
            {
                this.State.Set("DecimalSeparator", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("decimalSeparator")]
        [DefaultValue("")]
        protected virtual string DecimalSeparatorProxy
        {
            get
            {
                //ResourceManager rm = this.SafeResourceManager;
                string ds = this.DecimalSeparator;

                /*
                if (rm != null)
                {
                    CultureInfo locale = rm.CurrentLocale;
                    return locale.NumberFormat.NumberDecimalSeparator == ds ? "" : ds;                    
                }

                return ds == "." ? "" : ds;
                */

                // Temporary solution because ExtJS locales don't have always proper decimal separator
                return ds;
            }
        }

        /// <summary>
        /// Error text to display if the maximum value validation fails (defaults to 'The maximum value for this field is {maxValue}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue("The maximum value for this field is {maxValue}")]
        [Localizable(true)]
        [Description("Error text to display if the maximum value validation fails (defaults to 'The maximum value for this field is {maxValue}').")]
        public virtual string MaxText
        {
            get
            {
                return this.State.Get<string>("MaxText", "The maximum value for this field is {maxValue}");
            }
            set
            {
                this.State.Set("MaxText", value);
            }
        }

        /// <summary>
        /// The maximum allowed value (defaults to Number.MAX_VALUE). Will be used by the field's validation logic, and for enabling/disabling the up spinner button.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue(Double.MaxValue)]
        [DirectEventUpdate(MethodName = "SetMaxValue")]
        [Description("The maximum allowed value (defaults to Number.MAX_VALUE). Will be used by the field's validation logic, and for enabling/disabling the up spinner button.")]
        public virtual Double MaxValue
        {
            get
            {
                return this.State.Get<Double>("MaxValue", Double.MaxValue);
            }
            set
            {
                this.State.Set("MaxValue", value);
            }
        }

        /// <summary>
        /// Error text to display if the minimum value validation fails (defaults to 'The minimum value for this field is {minValue}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue("The minimum value for this field is {minValue}")]
        [Localizable(true)]
        [Description("Error text to display if the minimum value validation fails (defaults to 'The minimum value for this field is {minValue}').")]
        public virtual string MinText
        {
            get
            {
                return this.State.Get<string>("MinText", "The minimum value for this field is {minValue}");
            }
            set
            {
                this.State.Set("MinText", value);
            }
        }

        /// <summary>
        /// The minimum allowed value (defaults to Number.NEGATIVE_INFINITY). Will be used by the field's validation logic, and for enabling/disabling the down spinner button.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DirectEventUpdate(MethodName="SetMinValue")]
        [DefaultValue(Double.MinValue)]
        [Description("The minimum allowed value (defaults to Number.NEGATIVE_INFINITY). Will be used by the field's validation logic, and for enabling/disabling the down spinner button.")]
        public virtual Double MinValue
        {
            get
            {
                return this.State.Get<Double>("MinValue", Double.MinValue);
            }
            set
            {
                this.State.Set("MinValue", value);
            }
        }

        /// <summary>
        /// Error text to display if the value is not a valid number. For example, this can happen if a valid character like '.' or '-' is left in the field with no number (defaults to '{value} is not a valid number').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue("{value} is not a valid number")]
        [Localizable(true)]
        [Description("Error text to display if the value is not a valid number. For example, this can happen if a valid character like '.' or '-' is left in the field with no number (defaults to '{value} is not a valid number').")]
        public virtual string NanText
        {
            get
            {
                return this.State.Get<string>("NanText", "{value} is not a valid number");
            }
            set
            {
                this.State.Set("NanText", value);
            }
        }

        /// <summary>
        /// Error text to display if the value is negative and minValue is set to 0. This is used instead of the minText in that circumstance only.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Error text to display if the value is negative and minValue is set to 0. This is used instead of the minText in that circumstance only.")]
        public virtual string NegativeText
        {
            get
            {
                return this.State.Get<string>("NegativeText", "");
            }
            set
            {
                this.State.Set("NegativeText", value);
            }
        }

        /// <summary>
        /// Specifies a numeric interval by which the field's value will be incremented or decremented when the user invokes the spinner. Defaults to 1.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue(1.0)]
        [Description("Specifies a numeric interval by which the field's value will be incremented or decremented when the user invokes the spinner. Defaults to 1.")]
        public virtual double Step
        {
            get
            {
                return this.State.Get<double>("Step", 1.0);
            }
            set
            {
                this.State.Set("Step", value);
            }
        }

        /// <summary>
        /// False to disallow trim trailed zeros.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue(true)]
        [Description("False to disallow trim trailed zeros.")]
        public virtual bool TrimTrailedZeros
        {
            get
            {
                return this.State.Get<bool>("TrimTrailedZeros", true);
            }
            set
            {
                this.State.Set("TrimTrailedZeros", value);
            }
        }

        /// <summary>
        /// Replaces any existing maxValue with the new value.
        /// </summary>
        /// <param name="value">The maximum value</param>
        public virtual void SetMaxValue(Double value)
        {
            this.Call("setMaxValue", value);
        }

        /// <summary>
        /// Replaces any existing minValue with the new value.
        /// </summary>
        /// <param name="value">The minimum value</param>
        public virtual void SetMinValue(Double value)
        {
            this.Call("setMinValue", value);
        }
    }
}