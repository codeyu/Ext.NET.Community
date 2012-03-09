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
    public abstract partial class PickerField
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : TriggerFieldBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool matchFieldWidth = true;

			/// <summary>
			/// Whether the picker dropdown's width should be explicitly set to match the width of the field. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool MatchFieldWidth 
			{ 
				get
				{
					return this.matchFieldWidth;
				}
				set
				{
					this.matchFieldWidth = value;
				}
			}

			private string openCls = "";

			/// <summary>
			/// A class to be added to the field's bodyEl element when the picker is opened. Defaults to 'x-pickerfield-open'.
			/// </summary>
			[DefaultValue("")]
			public virtual string OpenCls 
			{ 
				get
				{
					return this.openCls;
				}
				set
				{
					this.openCls = value;
				}
			}

			private string pickerAlign = "tl-bl?";

			/// <summary>
			/// The alignment position with which to align the picker. Defaults to \"tl-bl?\"
			/// </summary>
			[DefaultValue("tl-bl?")]
			public virtual string PickerAlign 
			{ 
				get
				{
					return this.pickerAlign;
				}
				set
				{
					this.pickerAlign = value;
				}
			}

			private int[] pickerOffset = null;

			/// <summary>
			/// An offset [x,y] to use in addition to the pickerAlign when positioning the picker. Defaults to undefined.
			/// </summary>
			[DefaultValue(null)]
			public virtual int[] PickerOffset 
			{ 
				get
				{
					return this.pickerOffset;
				}
				set
				{
					this.pickerOffset = value;
				}
			}

			private PickerAutoPostBackEvent autoPostBackEvent = PickerAutoPostBackEvent.Select;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(PickerAutoPostBackEvent.Select)]
			public virtual PickerAutoPostBackEvent AutoPostBackEvent 
			{ 
				get
				{
					return this.autoPostBackEvent;
				}
				set
				{
					this.autoPostBackEvent = value;
				}
			}

        }
    }
}