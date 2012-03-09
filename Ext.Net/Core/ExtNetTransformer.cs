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
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;
using Transformer.NET;
using Transformer.NET.Html;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [CLSCompliant(true)]
    public class ExtNetTransformer : HtmlTransformer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public ExtNetTransformer(string text) : base(text)
        {
            this.InitSelectors();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="config"></param>
        public ExtNetTransformer(string text, TextTransformerConfig config)
            : base(text, config)
        {
            this.InitSelectors();
        }

        private static Regex warningRegex = new Regex("<Ext.Net.InitScript.Warning>.*?</Ext.Net.InitScript.Warning>", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline);
        private static Regex removeViewstateRegex = new Regex("<div>[\\r|\\t|\\s]*<input.*name=\"__EVENTVALIDATION\"[^>].*/>[\\r|\\t|\\s]*</div>|<input(?:[^>]*)name=\"__(VIEWSTATE|VIEWSTATEENCRYPTED)\".*?/>", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline);
        private static Regex inputsVSRegex = new Regex("<input(?:[^>]*)name=\"__(VIEWSTATE|VIEWSTATEENCRYPTED|EVENTTARGET|EVENTARGUMENT|LASTFOCUS|EVENTVALIDATION)\".*?/>", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline);
        private static Regex inputsRegex = new Regex("<input(?:[^>]*)name=\"__(EVENTTARGET|EVENTARGUMENT|LASTFOCUS)\".*?/>", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline);
        private static Regex postbackRegex = new Regex("<script(?:(?!</script>).)*function __doPostBack\\(eventTarget, eventArgument\\).*?</script>", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase);
        private static Regex removeInputsBlockRegex = new Regex("<div(?:(?!</div>).)*<input(?:[^>]*)name=\"__(EVENTTARGET|EVENTVALIDATION)\".*?</div>", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase);

        /// <summary>
        /// 
        /// </summary>
        protected virtual void InitSelectors()
        {
            Dictionary<string, TokenSelector> selectors = this.Selectors;
            selectors.Add("warning", new TokenSelector { Regex = warningRegex, Position = SelectorPosition.Replace});
            selectors.Add("viewstate", new TokenSelector { Regex = removeViewstateRegex, Position = SelectorPosition.Replace, Pseudo = "all" });
            selectors.Add("inputsVS", new TokenSelector { Regex = inputsVSRegex, Position = SelectorPosition.After, Pseudo = "all" });
            selectors.Add("inputs", new TokenSelector { Regex = inputsRegex, Position = SelectorPosition.After, Pseudo = "all" });
            selectors.Add("postback", new TokenSelector { Regex = postbackRegex, Position = SelectorPosition.Replace });
            selectors.Add("removeblocks", new TokenSelector { Regex = removeInputsBlockRegex, Position = SelectorPosition.Replace, Pseudo="all" });
        }

        /// <summary>
        /// 
        /// </summary>
        public override List<Type> StandardTokens
        {
            get
            {
                List<Type> tokens = base.StandardTokens;

                tokens.Add(typeof(InputFieldsTag));

                return tokens;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        new public static string Transform(string text)
        {
            return new ExtNetTransformer(ExtNetTransformer.PrepareText(text)).Transform();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        new public static string Transform(string text, TextTransformerConfig config)
        {
            return new ExtNetTransformer(ExtNetTransformer.PrepareText(text), config).Transform();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tokensType"></param>
        /// <returns></returns>
        new public static string Transform(string text, List<Type> tokensType)
        {
            return new ExtNetTransformer(ExtNetTransformer.PrepareText(text)).Transform(tokensType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="variables"></param>
        /// <returns></returns>
        new public static string Transform(string text, Dictionary<string, string> variables)
        {
            return new ExtNetTransformer(ExtNetTransformer.PrepareText(text)).Transform(variables);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tokensType"></param>
        /// <param name="variables"></param>
        /// <returns></returns>
        new public static string Transform(string text, List<Type> tokensType, Dictionary<string, string> variables)
        {
            return new ExtNetTransformer(ExtNetTransformer.PrepareText(text)).Transform(tokensType, variables);
        }

        private static string PrepareText(string text)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(text);

            var config = MVC.MvcResourceManager.SharedConfig;

            if (config.RenderStyles != ResourceLocationType.None)
            {
                ExtNetTransformer.ShareIcons(sb);
                ExtNetTransformer.ShareStyles(sb, config);
            }

            if (config.RenderScripts != ResourceLocationType.None)
            {
                ExtNetTransformer.ShareScripts(sb, config);
            }

            if(HttpContext.Current.Items.Contains("Ext.Net.GlobaResources"))
            {
                HttpContext.Current.Items.Remove("Ext.Net.GlobaResources");
            }

            return sb.ToString();
        }

        private static void ShareStyles(StringBuilder sb, MVC.MvcResourceManagerConfig config)
        {
            if (HttpContext.Current.Items["Ext.Net.GlobaResources"] != null)            
            {
                List<ResourceItem> styles = (List<ResourceItem>)HttpContext.Current.Items["Ext.Net.GlobalResources"];

                foreach (var item in styles)
                {
                    if (item is ClientStyleItem)
                    {
                        var styleItem = (ClientStyleItem)item;

                        switch (config.RenderStyles)
                        {                            
                            case ResourceLocationType.File:
                                sb.AppendFormat(ResourceManager.StyleIncludeTemplate, config.ResourcePath.ConcatWith(styleItem.Path));
                                break;
                            default :
                            case ResourceLocationType.Embedded:
                                sb.AppendFormat(ResourceManager.StyleIncludeTemplate, ExtNetTransformer.GetWebResourceUrl(styleItem.Type, styleItem.PathEmbedded, config));
                                break;
                        }
                    }
                }
            }
        }

        private static void ShareScripts(StringBuilder sb, MVC.MvcResourceManagerConfig config)
        {
            if (HttpContext.Current.Items["Ext.Net.GlobaResources"] != null)            
            {
                List<ResourceItem> scripts = (List<ResourceItem>)HttpContext.Current.Items["Ext.Net.GlobalResources"];                

                foreach (var item in scripts)
                {
                    if (item is ClientScriptItem)
                    {
                        var scriptItem = (ClientScriptItem)item;

                        if (config.RenderScripts == ResourceLocationType.Embedded)
                        {
                            
                            if (config.ScriptMode == ScriptMode.Release || scriptItem.PathEmbeddedDebug.IsEmpty())
                            {
                                sb.AppendFormat(ResourceManager.ScriptIncludeTemplate, ExtNetTransformer.GetWebResourceUrl(scriptItem.Type, scriptItem.PathEmbedded, config));
                            }
                            else
                            {
                                sb.AppendFormat(ResourceManager.ScriptIncludeTemplate, ExtNetTransformer.GetWebResourceUrl(scriptItem.Type, scriptItem.PathEmbeddedDebug, config));                                
                            }
                        }
                        else if (config.RenderScripts == ResourceLocationType.File)
                        {
                            if (config.ScriptMode == ScriptMode.Release || scriptItem.PathDebug.IsEmpty())
                            {
                                sb.AppendFormat(ResourceManager.ScriptIncludeTemplate, config.ResourcePath.ConcatWith(scriptItem.Path));
                            }
                            else
                            {
                                sb.AppendFormat(ResourceManager.ScriptIncludeTemplate, config.ResourcePath.ConcatWith(scriptItem.PathDebug));                             
                            }
                        }
                        else if (config.RenderScripts == ResourceLocationType.CDN)
                        {
                            if (config.ScriptMode == ScriptMode.Release || scriptItem.PathDebug.IsEmpty())
                            {
                                sb.AppendFormat(ResourceManager.ScriptIncludeTemplate, ResourceManager.CDNPath.ConcatWith(scriptItem.Path));
                            }
                            else
                            {
                                sb.AppendFormat(ResourceManager.ScriptIncludeTemplate, ResourceManager.CDNPath.ConcatWith(scriptItem.PathDebug));
                            }
                        }
                    }
                }
            }
        }

        private static Page cachedPage = null;
        private static object syncLock = new object();

        /// <summary>
        /// 
        /// </summary>
        protected static Page CachedPageInstance
        {
            get
            {
                if (cachedPage == null)
                {
                    lock (syncLock)
                    {
                        if (cachedPage == null)
                            cachedPage = new Page();
                    }
                }
                return cachedPage;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="resourceName"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static string GetWebResourceUrl(Type type, string resourceName, MVC.MvcResourceManagerConfig config)
        {
            if (resourceName.StartsWith(ResourceManager.ASSEMBLYSLUG) && config.CleanResourceUrl && ResourceHandler.HasHandler())
            {
                string buster = (resourceName.EndsWith(".js") || resourceName.EndsWith(".css")) ? "?v=".ConcatWith(ResourceManager.CacheBuster) : "";

                return CachedPageInstance.ResolveUrl("~/{0}/ext.axd{1}".FormatWith(resourceName.Replace(ResourceManager.ASSEMBLYSLUG, "").Replace('.', '/').ReplaceLastInstanceOf("/", "-"), buster));
            }

            return HttpUtility.HtmlAttributeEncode(CachedPageInstance.ClientScript.GetWebResourceUrl(type, resourceName));
        }

        private static void ShareIcons(StringBuilder sb)
        {
            if (HttpContext.Current.Items["Ext.Net.GlobalIcons"] != null)
            {
                List<Icon> icons = (List<Icon>)HttpContext.Current.Items["Ext.Net.GlobalIcons"];
                HttpContext.Current.Items.Remove("Ext.Net.GlobalIcons");
                if (icons.Count > 0)
                {
                    string[] arr = new string[icons.Count];
                    for (int i = 0; i < icons.Count; i++)
                    {
                        arr[i] = icons[i].ToString();
                    }

                    sb.Append("<#:item ref='ext.net.global.icons'>Ext.net.ResourceMgr.registerIcon(");
                    sb.Append(JSON.Serialize(arr));
                    sb.Append(");</#:item>");
                }
            }
        }

        protected override Token CreateToken(string tagName, Match match)
        {
            if(tagName == "item")
            {
                string attrsStr = match.Groups["attrs"].Value;

                if (attrsStr != null && attrsStr.Contains("key="))
                {
                    return new LinkedScriptTag(match);
                }
            }

            return base.CreateToken(tagName, match);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [TagName("item")]
    [CLSCompliant(true)]
    public class LinkedScriptTag : ItemTag
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        public LinkedScriptTag(Match match)
            : base(match)
        {
        }

        public override string Output
        {
            get
            {                
                HttpContext.Current.Application[this.GetAttribute("key")] = this.Value;
                return ResourceManager.ScriptIncludeTemplate.FormatWith(this.GetAttribute("url"));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [TagName("inputs")]
    [CLSCompliant(true)]
    public class InputFieldsTag : ItemTag
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        public InputFieldsTag(Match match)
            : base(match)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IncludeViewState
        {
            get
            {
                string vs = this.GetAttribute("viewstate");
                return vs != null && vs.Length > 0 ? bool.Parse(vs) : false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Template
        {
            get
            {
                return "inputs";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Selector
        {
            get
            {
                return this.IncludeViewState ? "inputsVS" : "inputs";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Output
        {
            get
            {
                TokenSelector selector = TokenSelector.ToTokenSelector(this.Transformer, this.Selector);
                List<string> list = selector.Matches(this.Transformer.Text, this);

                if (list.Count <= 0)
                {
                    return "";
                }

                StringBuilder sb = new StringBuilder("Ext.net.ResourceMgr.initAspInputs({");
                var presented = false;
                foreach (string match in list)
                {
                    if (match != null && match.Length > 0)
                    {
                        Dictionary<string, string> attrs = this.BuildAttributes(match);
                        if (!(attrs["value"].IsEmpty() && (attrs["name"] == "__EVENTTARGET" || attrs["name"] == "__EVENTARGUMENT")))
                        {
                            sb.Append(JSON.Serialize(attrs["name"])).Append(":").Append(JSON.Serialize(attrs["value"])).Append(",");
                            presented = true;
                        }
                    }
                }

                if (!presented)
                {
                    return "";
                }

                sb.Remove(sb.Length - 1, 1);
                
                sb.Append("});");
                return sb.ToString();
            }
        }
    }
}
