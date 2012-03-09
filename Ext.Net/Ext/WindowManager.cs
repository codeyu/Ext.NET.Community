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
	/// The default global floating Component group that is available automatically.
    ///
    /// This manages instances of floating Components which were rendered programatically without being added to a Container, and for floating Components which were added into non-floating Containers.
    ///
    /// Floating Containers create their own instance of ZIndexManager, and floating Components added at any depth below there are managed by that ZIndexManager.
	/// </summary>
	[Description("")]
    public partial class WindowManager : ScriptClass
    {
        /*  IScriptable
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.WindowMgr";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToScript()
        {
            return "";
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Brings the specified Component to the front of any other active Components in this ZIndexManager.
        /// </summary>
        /// <param name="compID">The id of the Component or a Ext.Component instance</param>
        public virtual void BringToFront(string compID)
        {
            this.Call("bringToFront", compID);
        }

        /// <summary>
        /// Brings the specified Component to the front of any other active Components in this ZIndexManager.
        /// </summary>
        /// <param name="comp">The id of the Component or a Ext.Component instance</param>
        public virtual void BringToFront(AbstractComponent comp)
        {
            this.BringToFront(comp.ClientID);
        }

        /// <summary>
        /// Executes the specified function once for every Component in this ZIndexManager, passing each Component as the only parameter. Returning false from the function will stop the iteration.
        /// </summary>
        /// <param name="fn">The function to execute for each item</param>
        public virtual void Each(JFunction fn)
        {
            this.Call("each", fn);
        }

        /// <summary>
        /// Executes the specified function once for every Component in this ZIndexManager, passing each Component as the only parameter. Returning false from the function will stop the iteration.
        /// </summary>
        /// <param name="fn">The function to execute for each item</param>
        /// <param name="scope">(optional) The scope (this reference) in which the function is executed. Defaults to the current Component in the iteration.</param>
        public virtual void Each(JFunction fn, string scope)
        {
            this.Call("each", fn, new JRawValue(scope));
        }

        /// <summary>
        /// Hides all Components managed by this ZIndexManager.
        /// </summary>
        public virtual void HideAll()
        {
            this.Call("hideAll");
        }

        /// <summary>
        /// Sends the specified Component to the back of other active Components in this ZIndexManager.
        /// </summary>
        /// <param name="compID">The id of the Component or a Ext.Component instance</param>
        public virtual void SendToBack(string compID)
        {
            this.Call("sendToBack", compID);
        }

        /// <summary>
        /// Sends the specified Component to the back of other active Components in this ZIndexManager.
        /// </summary>
        /// <param name="comp">The id of the Component or a Ext.Component instance</param>
        public virtual void SendToBack(AbstractComponent comp)
        {
            this.SendToBack(comp.ClientID);
        }
    }
}