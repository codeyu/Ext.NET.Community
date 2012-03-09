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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Web.Mvc;
using System.Xml.Serialization;
using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormPanelResult : ActionResult, IXObject
    {
        /// <summary>
        /// 
        /// </summary>
        public FormPanelResult() { }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        public string Script 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsUpload 
        { 
            get; 
            set; 
        }

        private bool success = true;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        public bool Success
        {
            get 
            { 
                return this.success; 
            }
            set 
            { 
                this.success = value; 
            }
        }

        private List<FieldError> errors;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.AlwaysArray)]
        public List<FieldError> Errors
        {
            get
            {
                if(this.errors == null)
                {
                    this.errors = new List<FieldError>();
                }

                return this.errors;
            }
        }

        private ParameterCollection extraParams;

        /// <summary>
        /// 
        /// </summary>
        public ParameterCollection ExtraParams
        {
            get
            {
                if (this.extraParams == null)
                {
                    this.extraParams = new ParameterCollection();
                }

                return this.extraParams;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("extraParams", JsonMode.Raw)]
        [DefaultValue("")]
        protected string ExtraParamsProxy
        {
            get
            {
                if (this.ExtraParams.Count > 0)
                {
                   return ExtraParams.ToJson();
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (this.IsUpload)
            {
                context.HttpContext.Response.Write("<textarea>{0}</textarea>".FormatWith(new ClientConfig().Serialize(this)));
            }
            else
            {
                CompressionUtils.GZipAndSend(new ClientConfig().Serialize(this));
            }
        }

        #region Члены IXObject

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [XmlIgnore]
        [JsonIgnore]
        public virtual ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = new ConfigOptionsCollection();

                list.Add("script", new ConfigOption("script", null, null, this.Script));
                list.Add("success", new ConfigOption("success", null, "", this.Success));
                list.Add("errors", new ConfigOption("errors", new SerializationOptions(JsonMode.AlwaysArray), null, this.Errors));
                list.Add("extraParamsProxy", new ConfigOption("extraParamsProxy", new SerializationOptions("extraParams", JsonMode.Raw), "", this.ExtraParamsProxy));

                return list;
            }
        }

        public ConfigOptionsExtraction ConfigOptionsExtraction
        {
            get 
            {
                return Ext.Net.ConfigOptionsExtraction.List;
            }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class FieldError: IXObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldID"></param>
        /// <param name="errorMessage"></param>
        public FieldError(string fieldID, string errorMessage)
        {
            if(string.IsNullOrEmpty(fieldID))
            {
                throw new ArgumentNullException("fieldID", "Field ID can not be empty");
            }

            if (string.IsNullOrEmpty(errorMessage))
            {
                throw new ArgumentNullException("errorMessage", "Error message can not be empty");
            }

            this.FieldID = fieldID;
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("id")]
        [DefaultValue("")]
        public string FieldID 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("msg")]
        [DefaultValue("")]
        public string ErrorMessage 
        { 
            get; 
            set; 
        }

        #region Члены IXObject

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [XmlIgnore]
        [JsonIgnore]
        public virtual ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = new ConfigOptionsCollection();

                list.Add("fieldID", new ConfigOption("fieldID", new SerializationOptions("id"), "", this.FieldID));
                list.Add("errorMessage", new ConfigOption("errorMessage", new SerializationOptions("msg"), "", this.ErrorMessage));

                return list;
            }
        }

        public ConfigOptionsExtraction ConfigOptionsExtraction
        {
            get 
            {
                return Ext.Net.ConfigOptionsExtraction.List;
            }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class FieldErrors : Collection<FieldError> { }
}
