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
using System.Collections.Generic;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public abstract partial class AbstractContainer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAbstractContainer"></typeparam>
        /// <typeparam name="TBuilder"></typeparam>
        new public abstract partial class Builder<TAbstractContainer, TBuilder> : ComponentBase.Builder<TAbstractContainer, TBuilder>
            where TAbstractContainer : AbstractContainer
            where TBuilder : Builder<TAbstractContainer, TBuilder>
        {
            //public virtual ItemsBuilder<TContainerBase, TBuilder> Items()
            //{
            //    return new ItemsBuilder<TContainerBase, TBuilder>(this.ToControl(), this as TBuilder);
            //}

            /// <summary>
            /// The layout type to be used in this container.
            /// </summary>
            public virtual TBuilder Layout(LayoutType layout)
            {
                this.ToComponent().Layout = layout.ToString();
                return this as TBuilder;
            }

            /// <summary>
            /// Items collection
            /// </summary>
            [Description("Items collection")]
            public virtual TBuilder Items(Action<ItemsBuilder<TAbstractContainer, TBuilder>> action)
            {
                action(new ItemsBuilder<TAbstractContainer, TBuilder>(this.ToComponent(), this as TBuilder));
                return this as TBuilder;
            }

            /// <summary>
            /// In layout pages, renders the content of a named section as items and specifies whether the section is required.
            /// </summary>
            /// <param name="page">Page instance</param>
            /// <param name="name">Section name to render as items</param>
            /// <param name="required">True to specify that the section is required</param>
            /// <returns></returns>
            public virtual TBuilder ItemsFromSection(System.Web.WebPages.WebPageBase page, string name, bool required)
            {
                BaseControl.SectionsStack.Push(new List<string>());
                var result = page.RenderSection(name, required);
                
                if (result != null)
                {
                    this.ToComponent().ItemsToRender = result.ToHtmlString();
                    this.ToComponent().IDSToRender = BaseControl.SectionsStack.Pop();
                }
                else
                {
                    BaseControl.SectionsStack.Pop();
                }

                return this as TBuilder;
            }            

            /// <summary>
            /// In layout pages, renders the content of a named section as items
            /// </summary>
            /// <param name="page">Page instance</param>
            /// <param name="name">Section name to render as items</param>
            /// <returns></returns>
            public virtual TBuilder ItemsFromSection(System.Web.WebPages.WebPageBase page, string name)
            {
                return this.ItemsFromSection(page, name, false);
            }

            /// <summary>
            /// Renders the content of one page within another page as items.
            /// </summary>
            /// <param name="page">Page instance</param>
            /// <param name="path">The path of the page to render.</param>
            /// <param name="data">(Optional) An array of data to pass to the page being rendered. In the rendered page, these parameters can be accessed by using the PageData property.</param>
            /// <returns></returns>
            public virtual TBuilder ItemsFromPage(System.Web.WebPages.WebPageBase page, string path, params object[] data)
            {
                BaseControl.SectionsStack.Push(new List<string>());
                var result = page.RenderPage(path, data);

                if (result != null)
                {
                    this.ToComponent().ItemsToRender = result.ToHtmlString();
                    this.ToComponent().IDSToRender = BaseControl.SectionsStack.Pop();
                }
                else
                {
                    BaseControl.SectionsStack.Pop();
                }

                return this as TBuilder;
            }        
        }
    }
}