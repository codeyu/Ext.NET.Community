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

namespace Ext.Net
{
    /// <summary>
    /// A Column definition class which renders boolean data fields. 
    /// </summary>
    [Meta]
    public partial class BooleanColumn : CellCommandColumn
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public BooleanColumn() { }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "booleancolumn";
            }
        }

        /// <summary>
        /// The string returned by the renderer when the column value is falsey (but not undefined) (defaults to 'false').
        /// </summary>
        [ConfigOption]
        [Category("3. BooleanColumn")]
        [DefaultValue("false")]
        [Description("The string returned by the renderer when the column value is falsey (but not undefined) (defaults to 'false').")]
        public virtual string FalseText
        {
            get
            {
                return this.State.Get<string>("FalseText", "false");
            }
            set
            {
                this.State.Set("FalseText", value);
            }
        }

        /// <summary>
        /// The string returned by the renderer when the column value is not falsey (defaults to 'true').
        /// </summary>
        [ConfigOption]
        [Category("3. BooleanColumn")]
        [DefaultValue("true")]
        [Description("The string returned by the renderer when the column value is not falsey (defaults to 'true').")]
        public virtual string TrueText
        {
            get
            {
                return this.State.Get<string>("TrueText", "true");
            }
            set
            {
                this.State.Set("TrueText", value);
            }
        }

        /// <summary>
        /// The string returned by the renderer when the column value is undefined (defaults to ' ').
        /// </summary>
        [ConfigOption]
        [Category("3. BooleanColumn")]
        [DefaultValue("&#160;")]
        [Description("The string returned by the renderer when the column value is undefined (defaults to ' ').")]
        public virtual string UndefinedText
        {
            get
            {
                return this.State.Get<string>("UndefinedText", "&#160;");
            }
            set
            {
                this.State.Set("UndefinedText", value);
            }
        }
    }
}