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
 ********/using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class AbstractComponent
    {
        new public abstract partial class Builder<TAbstractComponent, TBuilder> : Observable.Builder<TAbstractComponent, TBuilder>
            where TAbstractComponent : AbstractComponent
            where TBuilder : Builder<TAbstractComponent, TBuilder>
        {
            /// <summary>
            /// In layout pages, renders the content of a named section to content area of the widget
            /// </summary>
            /// <param name="page"></param>
            /// <param name="name"></param>
            /// <param name="required"></param>
            /// <returns></returns>
            public virtual TBuilder ContentFromSection(System.Web.WebPages.WebPageBase page, string name, bool required)
            {
                BaseControl.SectionsStack.Push(null);
                var result = page.RenderSection(name, required);
                if (result != null)
                {
                    this.ToComponent().ContentControls.Add(new LiteralControl(result.ToHtmlString()));
                }
                BaseControl.SectionsStack.Pop();
                return this as TBuilder;
            }

            /// <summary>
            /// In layout pages, renders the content of a named section to content area of the widget
            /// </summary>
            /// <param name="page"></param>
            /// <param name="name"></param>
            /// <returns></returns>
            public virtual TBuilder ContentFromSection(System.Web.WebPages.WebPageBase page, string name)
            {
                return this.ContentFromSection(page, name, false);
            }

            /// <summary>
            /// Renders the content of one page within another page to content area of the widget
            /// </summary>
            /// <param name="page"></param>
            /// <param name="path"></param>
            /// <param name="data"></param>
            /// <returns></returns>
            public virtual TBuilder ContentFromPage(System.Web.WebPages.WebPageBase page, string path, params object[] data)
            {
                BaseControl.SectionsStack.Push(null);
                var result = page.RenderPage(path, data);
                if (result != null)
                {
                    this.ToComponent().ContentControls.Add(new LiteralControl(result.ToHtmlString()));
                }
                BaseControl.SectionsStack.Pop();
                return this as TBuilder;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="content"></param>
            /// <returns></returns>
            public virtual TBuilder Content(Func<object, object> content)
            {
                BaseControl.SectionsStack.Push(null);
                var result = content(null);
                this.ToComponent().ContentControls.Add(new LiteralControl(result.ToString()));
                BaseControl.SectionsStack.Pop();
                return this as TBuilder;
            }

            /// <summary>
            /// The width of this component in pixels.
            /// </summary>
            public virtual TBuilder Width(int width)
            {
                this.ToComponent().Width = Unit.Pixel(width);
                return this as TBuilder;
            }

            /// <summary>
            /// The width of this component in pixels.
            /// </summary>
            public virtual TBuilder Height(int height)
            {
                this.ToComponent().Height = Unit.Pixel(height);
                return this as TBuilder;
            }

            /// <summary>
            /// The page level x coordinate for this component if contained within a positioning container.
            /// </summary>
            public virtual TBuilder PageX(int pageX)
            {
                this.ToComponent().PageX = Unit.Pixel(pageX);
                return this as TBuilder;
            }

            /// <summary>
            /// The page level y coordinate for this component if contained within a positioning container.
            /// </summary>
            public virtual TBuilder PageY(int pageY)
            {
                this.ToComponent().PageY = Unit.Pixel(pageY);
                return this as TBuilder;
            }
        }
    }
}