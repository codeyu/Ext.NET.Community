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
    /// This animation class is a mixin.
    /// 
    /// Ext.util.Animate provides an API for the creation of animated transitions of properties and styles.
    /// This class is used as a mixin and currently applied to Ext.Element, Ext.CompositeElement, Ext.draw.Sprite, Ext.draw.CompositeSprite, and Ext.Component. Note that Components have a limited subset of what attributes can be animated such as top, left, x, y, height, width, and opacity (color, paddings, and margins can not be animated).
    /// </summary>
    interface IAnimate
    {
        /// <summary>
        /// Perform custom animation on this object.
        /// </summary>
        /// <param name="cfg">An object containing properties which describe the animation's start and end states, and the timeline of the animation.</param>
        void Animate(AnimConfig cfg);

        /// <summary>
        /// Ensures that all effects queued after sequenceFx is called on this object are run in sequence. This is the opposite of syncFx.
        /// </summary>
        void SequenceFx();

        /// <summary>
        /// Stops any running effects and clears this object's internal effects queue if it contains any additional effects that haven't started yet.
        /// </summary>
        void StopAnimation();

        /// <summary>
        /// Ensures that all effects queued after syncFx is called on this object are run concurrently. This is the opposite of sequenceFx.
        /// </summary>
        void SyncFx();
    }
}