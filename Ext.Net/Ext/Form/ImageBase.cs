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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class ImageBase : ComponentBase
    {
        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ImageBase() { }

        /// <summary>
        /// 
        /// </summary>
        protected override string ContainerStyle
        {
            get
            {
                return Const.DisplayInline;
            }
        }

        /// <summary>
        /// The height of this component in pixels (defaults to auto).
        /// </summary>
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetHeight")]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The height of this component in pixels (defaults to auto).")]
        public override Unit Height
        {
            get
            {
                return this.State.Get<Unit>("Height", Unit.Empty);
            }
            set
            {
                this.State.Set("Height", value);
            }
        }

        /// <summary>
        /// The width of this component in pixels (defaults to auto).
        /// </summary>
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetWidth")]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The width of this component in pixels (defaults to auto).")]
        public override Unit Width
        {
            get
            {
                return this.State.Get<Unit>("Width", Unit.Empty);
            }
            set
            {
                this.State.Set("Width", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Ignore)]
        [Category("5. Image")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetImageUrl")]
        public virtual string ImageUrl
        {
            get
            {
                return this.State.Get<string>("ImageUrl", "");
            }
            set
            {
                this.State.Set("ImageUrl", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("imageUrl")]
        [DefaultValue("")]
        protected virtual string ImageUrlProxy
        {
            get
            {
                return this.ResolveUrlLink(this.ImageUrl);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("altText")]
        [Category("5. Image")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetAltText")]
        public virtual string AlternateText
        {
            get
            {
                return this.State.Get<string>("AlternateText", "");
            }
            set
            {
                this.State.Set("AlternateText", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. Image")]
        [DefaultValue(ImageAlign.NotSet)]
        [DirectEventUpdate(MethodName = "SetAlign")]
        public ImageAlign Align
        {
            get
            {
                return this.State.Get<ImageAlign>("Align", ImageAlign.NotSet);
            }
            set
            {
                this.State.Set("Align", value);
            }
        }

        /// <summary>
        /// true to load image after rendering only
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Image")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("true to load image after rendering only")]
        public virtual bool LazyLoad
        {
            get
            {
                return this.State.Get<bool>("LazyLoad", false);
            }
            set
            {
                this.State.Set("LazyLoad", value);
            }
        }

        /// <summary>
        /// true to monitor complete state and fire Complete event
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Image")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("true to monitor complete state and fire Complete event")]
        public virtual bool MonitorComplete
        {
            get
            {
                return this.State.Get<bool>("MonitorComplete", true);
            }
            set
            {
                this.State.Set("MonitorComplete", value);
            }
        }

        /// <summary>
        /// true to allow scroll the image by mouse dragging
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Image")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("true to allow scroll the image by mouse dragging")]
        public virtual bool AllowPan
        {
            get
            {
                return this.State.Get<bool>("AllowPan", false);
            }
            set
            {
                this.State.Set("AllowPan", value);
            }
        }

        /// <summary>
        /// The milliseconds to poll complete state, ignored if MonitorComplete is not true (defaults to 200)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Image")]
        [DefaultValue(200)]
        [NotifyParentProperty(true)]
        [Description("The milliseconds to poll complete state, ignored if MonitorComplete is not true (defaults to 200)")]
        public virtual int MonitorPoll
        {
            get
            {
                return this.State.Get<int>("MonitorPoll", 200);
            }
            set
            {
                this.State.Set("MonitorPoll", value);
            }
        }

        /// <summary>
        /// X offset
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Image")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetXDelta")]
        [Description("X offset")]
        public virtual int XDelta
        {
            get
            {
                return this.State.Get<int>("XDelta", 0);
            }
            set
            {
                this.State.Set("XDelta", value);
            }
        }

        /// <summary>
        /// Y offset
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Image")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetYDelta")]
        [Description("Y offset")]
        public virtual int YDelta
        {
            get
            {
                return this.State.Get<int>("YDelta", 0);
            }
            set
            {
                this.State.Set("YDelta", value);
            }
        }        

        private LoadMask loadMask;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("loadMask", typeof(LoadMaskJsonConverter))]
        [Category("5. Image")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual LoadMask LoadMask
        {
            get
            {
                if (this.loadMask == null)
                {
                    this.loadMask = new LoadMask();
                    this.loadMask.TrackViewState();
                }

                return this.loadMask;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        protected virtual void SetImageUrl(string url)
        {
            this.Call("setImageUrl", this.ResolveUrlLink(url));
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetAltText(string altText)
        {
            this.Call("setAltText", altText);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetAlign(ImageAlign align)
        {
            this.Call("setAlign", align.ToString().ToLowerInvariant());
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Scroll(int xDelta, int yDelta)
        {
            this.Call("scroll", xDelta, yDelta);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void ScrollTo(int x, int y)
        {
            this.Call("scrollTo", x, y);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetXDelta(int delta)
        {
            this.Call("scroll", delta);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetYDelta(int delta)
        {
            this.Call("scroll", new JRawValue("undefined"), delta);
        }
    }
}
