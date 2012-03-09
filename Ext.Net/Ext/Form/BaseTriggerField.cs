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
using System.Web.UI;

namespace Ext.Net
{
    [Meta]
    [Description("")]
    public abstract partial class BaseTriggerField : TriggerFieldBase, IPostBackEventHandler
    {
        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("triggerclick")]
        [Description("")]
        public override string PostBackEvent
        {
            get
            {
                return this.State.Get<string>("PostBackEvent", "triggerclick");
            }
            set
            {
                this.State.Set("PostBackEvent", value);
            }
        }

        private static readonly object EventTriggerClicked = new object();

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public delegate void TriggerClickedHandler(object sender, TriggerEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("Fires when a trigger has been clicked")]
        public event TriggerClickedHandler TriggerClicked
        {
            add
            {
                Events.AddHandler(EventTriggerClicked, value);
            }
            remove
            {
                Events.RemoveHandler(EventTriggerClicked, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void OnTriggerClicked(TriggerEventArgs e)
        {
            TriggerClickedHandler handler = (TriggerClickedHandler)Events[EventTriggerClicked];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            int index;

            if (int.TryParse(eventArgument, out index))
            {
                this.OnTriggerClicked(new TriggerEventArgs(index));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            this.CheckTriggers();

            base.OnPreRender(e);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void CheckTriggers()
        {
            if (this.Triggers.Count == 0)
            {
                this.Triggers.Add(new FieldTrigger());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DefaultValue("")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override string TriggerCls
        {
            get
            {
                return base.TriggerCls;
            }
            set
            {
                base.TriggerCls = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class TriggerEventArgs : EventArgs
    {
        private readonly int index;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public TriggerEventArgs(int index)
        {
            this.index = index;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public int Index
        {
            get
            {
                return index;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class FieldTrigerCollection : BaseItemCollection<FieldTrigger> { }
}
