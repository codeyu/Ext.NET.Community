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

using System.Collections.Generic;
using System.ComponentModel;

namespace Ext.Net
{
    public partial class ResourceManager
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string OnReadyTemplate = "Ext.onReady(function(){{{0}}});";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string OnTextResizeTemplate = "Ext.EventManager.onTextResize({0});";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string OnWindowResizeTemplate = "Ext.EventManager.onWindowResize({0});";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string ScriptBlockTemplate = "    <script type=\"text/javascript\">\r    //<![CDATA[\r        {0}\r    //]]>\r    </script>\r";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string SimpleScriptBlockTemplate = "<script type=\"text/javascript\">{0}</script>\r";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string ScriptIncludeTemplate = "    <script type=\"text/javascript\" src=\"{0}\"></script>\r";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string StyleBlockTemplate = "    <style type=\"text/css\">\n{0}    </style>\r";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string StyleBlockItemTemplate = "        {0}\r";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string StyleIncludeTemplate = "\r    <link type=\"text/css\" rel=\"stylesheet\" href=\"{0}\" />\r";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string ThemeIncludeTemplate = "    <link type=\"text/css\" rel=\"stylesheet\" href=\"{0}\" id=\"ext-theme\" />\r";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string CommentTemplate = "\r    <!-- {0} -->";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string FunctionTemplate = "function(){{{0}}}";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string FunctionTemplateWithParams = "function({0}){{{1}}}";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string FilterMarker = "ExtNetInitScriptFilter";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string INSTANCESCRIPT = "Ext.Net.ResourceMgr.InstanceScript";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string WarningTemplate = "<Ext.Net.InitScript.Warning><script type=\"text/javascript\">Ext.onReady(function(){Ext.Msg.show({title:'Warning',msg:'The <code>web.config</code> file for this project is missing the required DirectRequestModule.<br /><br /><div style=\"margin-left:48px;\"><b>Example</b><br /><br /><code>&lt;system.web><br />&nbsp;&nbsp;&lt;httpModules><br />&nbsp;&nbsp;&nbsp;&nbsp;&lt;add name=\"DirectRequestModule\" type=\"Ext.Net.DirectRequestModule, Ext.Net\" /><br />&nbsp;&nbsp;&lt;/httpModules><br />&lt;/system.web></code><br /><br />More information available at \"<a href=\"http://examples.ext.net/?/Getting_Started/Introduction/Overview/\">Getting Started</a>\".</div><br />',buttons: Ext.Msg.OK,icon: Ext.MessageBox.WARNING});});</script></Ext.Net.InitScript.Warning>" + Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string> { { "selector", "warning" } }, "");

        /// <summary>
        /// 
        /// </summary>
        public readonly static string ViewStateToken = Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string> { { "selector", "viewstate" } }, "");

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PostBackMethodToken = Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string> { { "selector", "postback" } }, "");

        /// <summary>
        /// 
        /// </summary>
        public readonly static string RemoveBlocksToken = Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string> { { "selector", "removeblocks" } }, "");

        /// <summary>
        /// 
        /// </summary>
        public readonly static string InputsToken = Transformer.NET.Net.CreateToken(typeof(InputFieldsTag), new Dictionary<string, string> { { "ref", "init_script" }, {"index", "-100"}}, "");

        /// <summary>
        /// 
        /// </summary>
        public readonly static string InputsVSToken = Transformer.NET.Net.CreateToken(typeof(InputFieldsTag), new Dictionary<string, string> { { "viewstate", "true" }, { "ref", "init_script" }, {"index", "-100"}}, "");
    }
}
