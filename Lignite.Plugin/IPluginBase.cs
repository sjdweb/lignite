/* @name Lignite For Betfair Project
 * @author Carel Vosloo
 * @author Betfair Developers Program (http://bdp.betfair.com)
 * @copyright Copyright (C) 2008 Betfair Ltd. All rights reserved.
 * @license This file is part of the Lignite For Betfair Project.
 * The BetfairAPIFramework is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * The "Lignite For Betfair Project" is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with the "Lignite For Betfair Project".  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using Betfair.Collections;

namespace Lignite.Plugin
{
    public interface IPluginBase
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        string Version { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; }

        /// <summary>
        /// Gets or sets the bets.
        /// </summary>
        /// <value>The bets.</value>
        List<Bet> Bets { get; set; }

        /// <summary>
        /// Gets or sets the custom user configuration for this instance.
        /// </summary>
        /// <value>The configuration.</value>
        PluginConfigurationBase Configuration { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has a form.
        /// </summary>
        /// <value><c>true</c> if this instance has form; otherwise, <c>false</c>.</value>
        bool HasWinForm { get; }

        /// <summary>
        /// Shows the plugin's main form.
        /// </summary>
        void ShowForm();

        /// <summary>
        /// Run the StartsUp logic and initializers.
        /// </summary>
        /// <param name="processorId">The processor id.</param>
        /// <param name="market">The market.</param>
        /// <param name="requestTimeGmt">The request time GMT.</param>
        /// <returns></returns>
        bool StartUp(string processorId, Market market, DateTime requestTimeGmt);

        /// <summary>
        /// The main entry point that will be called from the  Lignite for Betfair engine
        /// </summary>
        /// <param name="processorId">The processor id.</param>
        /// <param name="market">The market.</param>
        /// <param name="requestTimeGmt">The request time GMT.</param>
        /// <returns></returns>
        bool Execute(string processorId, Market market, DateTime requestTimeGmt);

        /// <summary>
        /// The shutdown method in your class gets excuted when the thread terminates.
        /// use this to elegantly close down data sources etc.
        /// </summary>
        /// <param name="processorId">The processor id.</param>
        /// <param name="market">The market.</param>
        /// <param name="requestTimeGmt">The request time GMT.</param>
        /// <returns></returns>
        bool ShutDown(string processorId, Market market, DateTime requestTimeGmt);
    }
}