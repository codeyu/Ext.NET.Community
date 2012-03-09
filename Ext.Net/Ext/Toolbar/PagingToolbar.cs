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
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// As the number of records increases, the time required for the browser to render them increases. Paging is used to reduce the amount of data exchanged with the client. Note: if there are more records/rows than can be viewed in the available screen area, vertical scrollbars will be added.
    /// Paging is typically handled on the server side (see exception below). The client sends parameters to the server side, which the server needs to interpret and then respond with the appropriate data.
    /// Ext.toolbar.Paging is a specialized toolbar that is bound to a Ext.data.Store and provides automatic paging control. This Component loads blocks of data into the store by passing parameters used for paging criteria.
    /// </summary>
    [Meta]
    [ToolboxBitmap(typeof(PagingToolbar), "Build.ToolboxIcons.PagingToolbar.bmp")]
    [ToolboxData("<{0}:PagingToolbar runat=\"server\"></{0}:PagingToolbar>")]
    [Description("A specialized toolbar that is bound to a Ext.data.Store and provides automatic paging controls.")]
    public partial class PagingToolbar : ToolbarBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public PagingToolbar() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "pagingtoolbar";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.toolbar.Paging";
            }
        }

        /// <summary>
        /// True to display the displayMsg (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to display the displayMsg (defaults to false).")]
        public virtual bool DisplayInfo
        {
            get
            {
                return this.State.Get<bool>("DisplayInfo", true);
            }
            set
            {
                this.State.Set("DisplayInfo", value);
            }
        }

        /// <summary>
        /// The paging status message to display. Note that this string is formatted using the braced numbers {0}-{2} as tokens that are replaced by the values for start, end and total respectively. These tokens should be preserved when overriding this string if showing those values is desired. Defaults to: "Displaying {0} - {1} of {2}"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("Displaying {0} - {1} of {2}")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("The paging status message to display. Note that this string is formatted using the braced numbers {0}-{2} as tokens that are replaced by the values for start, end and total respectively. These tokens should be preserved when overriding this string if showing those values is desired. Defaults to: \"Displaying {0} - {1} of {2}\"")]
        public virtual string DisplayMsg
        {
            get
            {
                return this.State.Get<string>("DisplayMsg", "Displaying {0} - {1} of {2}");
            }
            set
            {
                this.State.Set("DisplayMsg", value);
            }
        }

        /// <summary>
        /// The message to display when no records are found. Defaults to: "No data to display"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("No data to display")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("The message to display when no records are found (defaults to 'No data to display').")]
        public virtual string EmptyMsg
        {
            get
            {
                return this.State.Get<string>("EmptyMsg", "No data to display");
            }
            set
            {
                this.State.Set("EmptyMsg", value);
            }
        }

        /// <summary>
        /// The Ext.data.Store the paging toolbar should use as its data source.
        /// </summary>
        [Meta]
        [Category("7. PagingToolbar")]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(Store))]
        [NotifyParentProperty(true)]
        [Description("The Ext.data.Store the paging toolbar should use as its data source.")]
        public virtual string StoreID
        {
            get
            {
                return (string)State["StoreID"] ?? "";
            }
            set
            {
                this.State.Set("StoreID", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("store")]
        [DefaultValue("")]
        protected virtual string StoreProxy
        {
            get
            {
                if (this.StoreID.IsNotEmpty())
                {
                    var store = this.Page.FindControl(this.StoreID);
                    if (store != null)
                    {
                        return ((AbstractStore)store).ConfigID;    
                    }                    
                }

                var cmp = this.ParentComponent as IStore<Store>;
                if (cmp != null)
                {
                    if(cmp.Store.Primary != null)
                    {
                        return cmp.Store.Primary.ConfigID;
                    }

                    var store = this.Page.FindControl(cmp.StoreID);
                    if (store != null)
                    {
                        return ((AbstractStore)store).ConfigID;   
                    }                     
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(System.EventArgs e)
        {
            base.OnPreRender(e);

            if (this.StoreID.IsNotEmpty())
            {
                var store = this.Page.FindControl(this.StoreID);
                if (store != null)
                {
                    ((StoreBase)store).IsPagingStore = true;
                }
            }
            else
            {
                var cmp = this.ParentComponent as IStore<Store>;
                if (cmp != null)
                {
                    if (cmp.Store.Primary != null)
                    {
                        cmp.Store.Primary.IsPagingStore = true;
                    }
                    else if (cmp.StoreID.IsNotEmpty())
                    {
                        var store = this.Page.FindControl(cmp.StoreID);
                        if (store != null)
                        {
                            ((StoreBase)store).IsPagingStore = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Customizable piece of the default paging text. Note that this string is formatted using {0} as a token that is replaced by the number of total pages. This token should be preserved when overriding this string if showing the total page count is desired. Defaults to: "of {0}"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("of {0}")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("Customizable piece of the default paging text. Note that this string is formatted using {0} as a token that is replaced by the number of total pages. This token should be preserved when overriding this string if showing the total page count is desired. Defaults to: \"of {0}\"")]
        public virtual string AfterPageText
        {
            get
            {
                return this.State.Get<string>("AfterPageText", "of {0}");
            }
            set
            {
                this.State.Set("AfterPageText", value);
            }
        }

        /// <summary>
        /// The text displayed before the input item. Defaults to: "Page"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("Page")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("The text displayed before the input item. Defaults to: \"Page\"")]
        public virtual string BeforePageText
        {
            get
            {
                return this.State.Get<string>("BeforePageText", "Page");
            }
            set
            {
                this.State.Set("BeforePageText", value);
            }
        }

        /// <summary>
        /// The quicktip text displayed for the first page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: "First Page"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("First Page")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("The quicktip text displayed for the first page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"First Page\"")]
        public virtual string FirstText
        {
            get
            {
                return this.State.Get<string>("FirstText", "First Page");
            }
            set
            {
                this.State.Set("FirstText", value);
            }
        }

        /// <summary>
        /// The width in pixels of the input field used to display and change the current page number. Defaults to: 30
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue(30)]
        [NotifyParentProperty(true)]
        [Description("The width in pixels of the input field used to display and change the current page number. Defaults to: 30")]
        public virtual int InputItemWidth
        {
            get
            {
                return this.State.Get<int>("InputItemWidth", 30);
            }
            set
            {
                this.State.Set("InputItemWidth", value);
            }
        }

        /// <summary>
        /// The quicktip text displayed for the last page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: "Last Page"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("Last Page")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("The quicktip text displayed for the last page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"Last Page\"")]
        public virtual string LastText
        {
            get
            {
                return this.State.Get<string>("LastText", "Last Page");
            }
            set
            {
                this.State.Set("LastText", value);
            }
        }

        /// <summary>
        /// The quicktip text displayed for the next page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: "Next Page"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("Next Page")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("The quicktip text displayed for the next page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"Next Page\"")]
        public virtual string NextText
        {
            get
            {
                return this.State.Get<string>("NextText", "Next Page");
            }
            set
            {
                this.State.Set("NextText", value);
            }
        }

        /// <summary>
        /// true to insert any configured items before the paging buttons. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("true to insert any configured items before the paging buttons. Defaults to: false")]
        public virtual bool PrependButtons
        {
            get
            {
                return this.State.Get<bool>("PrependButtons", false);
            }
            set
            {
                this.State.Set("PrependButtons", value);
            }
        }

        /// <summary>
        /// The quicktip text displayed for the previous page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: "Previous Page"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("Previous Page")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("The quicktip text displayed for the previous page button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"Previous Page\"")]
        public virtual string PrevText
        {
            get
            {
                return this.State.Get<string>("PrevText", "Previous Page");
            }
            set
            {
                this.State.Set("PrevText", value);
            }
        }

        /// <summary>
        /// The quicktip text displayed for the Refresh button. Note: quick tips must be initialized for the quicktip to show. Defaults to: "Refresh"
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("Refresh")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("The quicktip text displayed for the Refresh button. Note: quick tips must be initialized for the quicktip to show. Defaults to: \"Refresh\"")]
        public virtual string RefreshText
        {
            get
            {
                return this.State.Get<string>("RefreshText", "Refresh");
            }
            set
            {
                this.State.Set("RefreshText", value);
            }
        }

        /// <summary>
        /// Hide refresh button
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetHideRefresh")]
        [Description("Hide refresh button")]
        public virtual bool HideRefresh
        {
            get
            {
                return this.State.Get<bool>("HideRefresh", false);
            }
            set
            {
                this.State.Set("HideRefresh", value);
            }
        }

        private PagingToolbarListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]        
        [Description("Client-side JavaScript Event Handlers")]
        public PagingToolbarListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new PagingToolbarListeners();
                }

                return this.listeners;
            }
        }


        private PagingToolbarDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]        
        [Description("Server-side DirectEventHandlers")]
        public PagingToolbarDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new PagingToolbarDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hide"></param>
        [Description("")]
        protected virtual void SetHideRefresh(bool hide)
        {
            if (hide)
            {
                this.Call("child('#refresh').hide");
            }
            else
            {
                this.Call("child('#refresh').show");
            }
        }

        /// <summary>
        /// Refresh the current page, has the same effect as clicking the 'refresh' button.
        /// </summary>
        public virtual void DoRefresh()
        {
            this.Call("doRefresh");
        }

        /// <summary>
        /// Move to the first page, has the same effect as clicking the 'first' button.
        /// </summary>
        public virtual void MoveFirst()
        {
            this.Call("moveFirst");
        }

        /// <summary>
        /// Move to the last page, has the same effect as clicking the 'last' button.
        /// </summary>
        public virtual void MoveLast()
        {
            this.Call("moveLast");
        }

        /// <summary>
        /// Move to the next page, has the same effect as clicking the 'next' button.
        /// </summary>
        public virtual void MoveNext()
        {
            this.Call("moveNext");
        }

        /// <summary>
        /// Move to the previous page, has the same effect as clicking the 'previous' button.
        /// </summary>
        public virtual void MovePrevious()
        {
            this.Call("movePrevious");
        }
    }
}
