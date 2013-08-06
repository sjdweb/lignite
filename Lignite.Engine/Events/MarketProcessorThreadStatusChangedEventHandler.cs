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
using System.Linq;
using System.Text;

namespace Lignite.Engine.Events
{
    public delegate void MarketProcessorThreadStatusChangedEventHandler(object sender, MarketProcessorThreadStatusChangedEventArgs e);

    public class MarketProcessorThreadStatusChangedEventArgs : EventArgs
    {
        public string senderID { get; set; }
        public MarketProcessorThreadStatus status { get; set; }

        public MarketProcessorThreadStatusChangedEventArgs() { }

        public MarketProcessorThreadStatusChangedEventArgs(string senderID, MarketProcessorThreadStatus status)
        {
            this.senderID = senderID;
            this.status = status;
        }
    }

    public enum MarketProcessorThreadStatus
    {
        INITIALIZED,
        SLEEPING,
        WORKING,
        CLOSED,
        WORKING_CLIENT_LIBRARY
    }
}
