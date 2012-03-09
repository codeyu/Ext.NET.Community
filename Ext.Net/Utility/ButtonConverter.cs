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

using System.Collections;
using System.ComponentModel;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ButtonConverter : ControlConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        protected override object[] GetControls(IContainer container)
        {
            ComponentCollection components = container.Components;
            ArrayList controls = new ArrayList();

            foreach (IComponent component in components)
            {
                if (component is System.Web.UI.Control)
                {
                    Control c = (Control)component;

                    var buttons = ControlUtils.FindControls<ButtonBase>(c);

                    if (buttons != null && buttons.Count > 0)
                    {
                        foreach (var btn in buttons)
                        {
                            if (btn.ID.IsNotEmpty() && !controls.Contains(btn.ID))
                            {
                                controls.Add(btn.ID);
                            }
                        }                        
                    }
                }
            }

            controls.Sort(Comparer.Default);

            return controls.ToArray();
        }
    }
}
