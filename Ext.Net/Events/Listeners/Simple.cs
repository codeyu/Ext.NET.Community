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

using System.Collections.Generic;
using System.ComponentModel;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class SimpleListener : BaseItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SimpleListener() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SimpleListener(string handler)
        {
            this.Handler = handler;
        }

        private string FnInternal
        {
            get
            {
                string handler = this.Handler;

                if (this.Fn.IsEmpty() && handler.IsNotEmpty())
                {
                    string parsedHandler = TokenUtils.ParseTokens(handler, this.Owner);

                    if (TokenUtils.IsRawToken(parsedHandler))
                    {
                        string temp = TokenUtils.ReplaceRawToken(parsedHandler);

                        if (!temp.StartsWith("Ext."))
                        {
                            return temp;
                        }
                    }

                    return string.Format(ResourceManager.FunctionTemplateWithParams, this.ArgumentList.Join(), TokenUtils.ReplaceRawToken(parsedHandler));
                }

                return (this.Fn.IsEmpty()) ? "" : TokenUtils.ReplaceRawToken(TokenUtils.ParseTokens(this.Fn, this.Owner));
            }
        }

        /// <summary>
        /// The raw JavaScript function to be called when this Listener fires.
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The raw JavaScript function to be called when this Listener fires.")]
        public virtual string Fn
        {
            get
            {
                return this.State.Get<string>("Fn", "");
            }
            set
            {
                this.State.Set("Fn", value);
            }
        }

        /// <summary>
        /// The JavaScript logic to be called when this Listener fires. The Handler will be automatically wrapped in a proper function(){} template and passed the correct arguments for this event.
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The JavaScript logic to be called when this Listener fires. The Handler will be automatically wrapped in a proper function(){} template and passed the correct arguments for this event.")]
        public virtual string Handler
        {
            get
            {
                return this.State.Get<string>("Handler", "");
            }
            set
            {
                this.State.Set("Handler", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool IsDefault
        {
            get
            {
                return this.FnInternal.IsEmpty();
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToString()
        {
            return this.FnInternal;
        }

        List<string> argumentList;

        /// <summary>
        /// List of Arguments passed to event handler.
        /// </summary>
        [Description("List of Arguments passed to event handler.")]
        internal List<string> ArgumentList
        {
            get
            {
                if (this.argumentList == null)
                {
                    this.argumentList = new List<string>();
                }

                return this.argumentList;
            }
        }
    }
}