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

using System.ComponentModel;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A Column definition class which renders a passed date according to the default locale, or a configured format.
    /// </summary>
    [Meta]
    [Description("")]
    public partial class DateColumn : CellCommandColumn
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DateColumn() { }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "datecolumn";
            }
        }

        /// <summary>
        /// A formatting string as used by Date.format to format a Date for this Column. This defaults to the default date from Ext.Date.defaultFormat which itself my be overridden in a locale file.
        /// </summary>
        [Meta]
        [Category("3. DateColumn")]
        [DefaultValue("")]
        [Description("A formatting string as used by Date.format to format a Date for this Column. This defaults to the default date from Ext.Date.defaultFormat which itself my be overridden in a locale file.")]
        public virtual string Format
        {
            get
            {
                return this.State.Get<string>("Format", "");
            }
            set
            {
                this.State.Set("Format", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("format")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string FormatProxy
        {
            get
            {
                return this.Format.IsEmpty() ? "" : DateTimeUtils.ConvertNetToPHP(this.Format, this.ResourceManager != null ? this.ResourceManager.CurrentLocale : null);
            }
        }
    }
}