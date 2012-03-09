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

using System.Drawing;

namespace Ext.Net
{
    /// <summary>
    /// A mixin to add floating capability to a Component.
    /// </summary>
    interface IFloating
    {
        /// <summary>
        /// Specifies whether the floated component should be automatically focused when it is brought to the front. Defaults to true.
        /// </summary>
        bool FocusOnToFront { get; set; }

        /// <summary>
        /// Specifies whether the floating component should be given a shadow. Set to true to automatically create an Ext.Shadow, or a string indicating the shadow's display Ext.Shadow.mode. Set to false to disable the shadow. (Defaults to 'sides'.)
        /// </summary>
        bool Shadow { get; set; }

        /// <summary>
        /// Specifies whether the floating component should be given a shadow. Set to .Shadow="true" to automatically create an Ext.Shadow, or .ShadowMode. (Defaults to 'sides'.)
        /// </summary>
        ShadowMode ShadowMode { get; set; }

        /// <summary>
        /// Aligns this floating Component to the specified element
        /// 
        /// The position parameter is optional, and can be specified in any one of the following formats:
        /// Blank: Defaults to aligning the element's top-left corner to the target's bottom-left corner ("tl-bl").
        /// One anchor (deprecated): The passed anchor position is used as the target element's anchor point. The element being aligned will position its top-left corner (tl) to that point. This method has been deprecated in favor of the newer two anchor syntax below.
        /// Two anchors: If two values from the table below are passed separated by a dash, the first value is used as the element's anchor point, and the second value is used as the target's anchor point.
        /// In addition to the anchor points, the position parameter also supports the "?" character. If "?" is passed at the end of the position string, the element will attempt to align as specified, but the position will be adjusted to constrain to the viewport if necessary. Note that the element being aligned might be swapped to align to a different position than that specified in order to enforce the viewport constraints. Following are all of the supported anchor positions:
        /// Value  Description
        /// -----  -----------------------------
        /// tl     The top left corner (default)
        /// t      The center of the top edge
        /// tr     The top right corner
        /// l      The center of the left edge
        /// c      In the center of the element
        /// r      The center of the right edge
        /// bl     The bottom left corner
        /// b      The center of the bottom edge
        /// br     The bottom right corner
        /// Example Usage:
        /// // align el to other-el using the default positioning ("tl-bl", non-constrained)
        /// el.alignTo("other-el");
        ///
        /// // align the top left corner of el with the top right corner of other-el (constrained to viewport)
        /// el.alignTo("other-el", "tr?");
        /// 
        /// // align the bottom right corner of el with the center left edge of other-el
        /// el.alignTo("other-el", "br-l?");
        /// 
        /// // align the center of el with the bottom left corner of other-el and
        /// // adjust the x position by -6 pixels (and the y position by 0)
        /// el.alignTo("other-el", "c-bl", [-6, 0]);
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">(optional, defaults to "tl-bl?") The position to align to (see Ext.core.Element-alignTo for more details).</param>
        /// <param name="xOffset">(optional) Offset the x positioning</param>
        /// <param name="yOffset">(optional) Offset the y positioning</param>
        void AlignTo(string element, string position, int xOffset, int yOffset);

        /// <summary>
        /// Aligns this floating Component to the specified element
        /// 
        /// The position parameter is optional, and can be specified in any one of the following formats:
        /// Blank: Defaults to aligning the element's top-left corner to the target's bottom-left corner ("tl-bl").
        /// One anchor (deprecated): The passed anchor position is used as the target element's anchor point. The element being aligned will position its top-left corner (tl) to that point. This method has been deprecated in favor of the newer two anchor syntax below.
        /// Two anchors: If two values from the table below are passed separated by a dash, the first value is used as the element's anchor point, and the second value is used as the target's anchor point.
        /// In addition to the anchor points, the position parameter also supports the "?" character. If "?" is passed at the end of the position string, the element will attempt to align as specified, but the position will be adjusted to constrain to the viewport if necessary. Note that the element being aligned might be swapped to align to a different position than that specified in order to enforce the viewport constraints. Following are all of the supported anchor positions:
        /// Value  Description
        /// -----  -----------------------------
        /// tl     The top left corner (default)
        /// t      The center of the top edge
        /// tr     The top right corner
        /// l      The center of the left edge
        /// c      In the center of the element
        /// r      The center of the right edge
        /// bl     The bottom left corner
        /// b      The center of the bottom edge
        /// br     The bottom right corner
        /// Example Usage:
        /// // align el to other-el using the default positioning ("tl-bl", non-constrained)
        /// el.alignTo("other-el");
        ///
        /// // align the top left corner of el with the top right corner of other-el (constrained to viewport)
        /// el.alignTo("other-el", "tr?");
        /// 
        /// // align the bottom right corner of el with the center left edge of other-el
        /// el.alignTo("other-el", "br-l?");
        /// 
        /// // align the center of el with the bottom left corner of other-el and
        /// // adjust the x position by -6 pixels (and the y position by 0)
        /// el.alignTo("other-el", "c-bl", [-6, 0]);
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">(optional, defaults to "tl-bl?") The position to align to (see Ext.core.Element-alignTo for more details).</param>
        void AlignTo(string element, string position);

        /// <summary>
        /// Aligns this floating Component to the specified element
        /// </summary>
        /// <param name="element">The element to align to.</param>
        void AlignTo(string element);

        /// <summary>
        /// Center this Component in its container.
        /// </summary>
        void Center();

        /// <summary>
        /// Moves this floating AbstractComponent into a constrain region.
        /// By default, this AbstractComponent is constrained to be within the container it was added to, or the element it was rendered to.
        ///
        /// An alternative constraint may be passed.
        /// </summary>
        void DoConstrain();

        /// <summary>
        /// Moves this floating AbstractComponent into a constrain region.
        /// By default, this AbstractComponent is constrained to be within the container it was added to, or the element it was rendered to.
        ///
        /// An alternative constraint may be passed.
        /// </summary>
        /// <param name="element">Optional. The Element or Region into which this AbstractComponent is to be constrained.</param>
        void DoConstrain(string element);

        /// <summary>
        /// Moves this floating AbstractComponent into a constrain region.
        /// By default, this AbstractComponent is constrained to be within the container it was added to, or the element it was rendered to.
        ///
        /// An alternative constraint may be passed.
        /// </summary>
        /// <param name="region">Optional. The Element or Region into which this AbstractComponent is to be constrained.</param>
        void DoConstrain(Rectangle region);

        /// <summary>
        /// Makes this the active AbstractComponent by showing its shadow, or deactivates it by hiding its shadow. This method also fires the activate or deactivate event depending on which action occurred. This method is called internally by Ext.ZIndexManager.
        /// </summary>
        /// <param name="active">True to activate the AbstractComponent, false to deactivate it</param>
        void SetActive(bool active);

        /// <summary>
        /// Sends this AbstractComponent to the back of (lower z-index than) any other visible windows
        /// </summary>
        void ToBack();

        /// <summary>
        /// Brings this floating AbstractComponent to the front of any other visible, floating Components managed by the same ZIndexManager
        ///
        /// If this AbstractComponent is modal, inserts the modal mask just below this AbstractComponent in the z-index stack.
        /// </summary>
        void ToFront();

        /// <summary>
        /// Brings this floating AbstractComponent to the front of any other visible, floating Components managed by the same ZIndexManager
        ///
        /// If this AbstractComponent is modal, inserts the modal mask just below this AbstractComponent in the z-index stack.
        /// </summary>
        /// <param name="preventFocus">(optional) Specify true to prevent the AbstractComponent from being focused.</param>
        void ToFront(bool preventFocus);
    }
}