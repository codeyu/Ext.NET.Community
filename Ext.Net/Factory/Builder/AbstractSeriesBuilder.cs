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
    public abstract partial class AbstractSeries
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TAbstractSeries, TBuilder> : BaseItem.Builder<TAbstractSeries, TBuilder>
            where TAbstractSeries : AbstractSeries
            where TBuilder : Builder<TAbstractSeries, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TAbstractSeries component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SeriesID(string seriesID)
            {
                this.ToComponent().SeriesID = seriesID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If set to true it will highlight the markers or the series when hovering with the mouse. This parameter can also be an object with the same style properties you would apply to a Ext.draw.Sprite to apply custom styles to markers and series.
			/// </summary>
            public virtual TBuilder Highlight(bool highlight)
            {
                this.ToComponent().Highlight = highlight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder HighlightConfig(SpriteAttributes highlightConfig)
            {
                this.ToComponent().HighlightConfig = highlightConfig;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Label(SeriesLabel label)
            {
                this.ToComponent().Label = label;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A function that can be overridden to set custom styling properties to each rendered element. Passes in (sprite, record, attributes, index, store) to the function.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Renderer(Action<JFunction> action)
            {
                action(this.ToComponent().Renderer);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Whether to show this series in the legend. Defaults to: true
			/// </summary>
            public virtual TBuilder ShowInLegend(bool showInLegend)
            {
                this.ToComponent().ShowInLegend = showInLegend;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Add tooltips to the visualization's markers. The options for the tips are the same configuration used with Ext.tip.ToolTip.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Tips(Action<ChartTip> action)
            {
                action(this.ToComponent().Tips);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The human-readable name of the series.
			/// </summary>
            public virtual TBuilder Title(string title)
            {
                this.ToComponent().Title = title;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The field used to access the x axis value from the items from the data source.
			/// </summary>
            public virtual TBuilder XField(string[] xField)
            {
                this.ToComponent().XField = xField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The field used to access the y axis value from the items from the data source.
			/// </summary>
            public virtual TBuilder YField(string[] yField)
            {
                this.ToComponent().YField = yField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<SeriesListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder HideAll()
            {
                this.ToComponent().HideAll();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ShowAll()
            {
                this.ToComponent().ShowAll();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetTitle(string title)
            {
                this.ToComponent().SetTitle(title);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetTitle(int index, string title)
            {
                this.ToComponent().SetTitle(index, title);
                return this as TBuilder;
            }
            
        }        
    }
}