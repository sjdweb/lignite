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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lignite.ConfigurationEditor
{
    public partial class DataLoadPaternView : UserControl
    {
        //declaring the event
        public event EventHandler DataChanged;

        //Function to trigger the event
        //This will be called when the user clicks the button
        public void OnDataChanged()
        {
            //Invoking all the event handlers
            if (DataChanged != null) DataChanged(DataLoadPaterns, new EventArgs());
        }

        private Lignite.Configuration.DataLoad[] __dataLoadPaterns;
        public Lignite.Configuration.DataLoad[] DataLoadPaterns
        {
            get
            {
                return __dataLoadPaterns;
            }
            set
            {
                __dataLoadPaterns = value;
                UpdateDisplay();
            }
        }

        public DataLoadPaternView()
        {
            InitializeComponent();
        }

        public DataLoadPaternView(Lignite.Configuration.DataLoad[] DataLoadPaterns)
        {
            InitializeComponent();
            this.__dataLoadPaterns = DataLoadPaterns;
            UpdateDisplay();
        }

        private void dgDataLoadFrequency_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (!displayUpdating)
            {
                LoadDataLoadPaternsFromDataSet();
                OnDataChanged();
            }
        }

        private bool displayUpdating;
        public void UpdateDisplay()
        {
            displayUpdating = true;

            LoadDataSetFromDataLoadPaterns();

            displayUpdating = false;
        }

        private void LoadDataSetFromDataLoadPaterns()
        {
            dsDataLoadPaterns.Clear();

            if (__dataLoadPaterns != null)
            {
                for (int x = 0; x < __dataLoadPaterns.Length; x++)
                {
                    DataRow dataRow = dsDataLoadPaterns.Tables[0].NewRow();

                    dataRow["Frequency"] = __dataLoadPaterns[x].Frequency;
                    dataRow["TimeBeforeOff"] = __dataLoadPaterns[x].TimeBeforeOff;
                    if (__dataLoadPaterns[x].Actions != null)
                    {
                        dataRow["GetBets"] = __dataLoadPaterns[x].Actions.GetBets;
                        dataRow["GetCompleteMarketTradedVolume"] = __dataLoadPaterns[x].Actions.GetCompleteMarketTradedVolume;
                        dataRow["GetExtendedRunnerInfo"] = __dataLoadPaterns[x].Actions.GetExtendedRunnerInfo;
                        dataRow["GetMarketPrices"] = __dataLoadPaterns[x].Actions.GetMarketPrices;
                        dataRow["GetMarketPricesComplete"] = __dataLoadPaterns[x].Actions.GetMarketPricesComplete;
                        dataRow["TerminateMarketThread"] = __dataLoadPaterns[x].Actions.TerminateMarketThread;
                    }
                    dsDataLoadPaterns.Tables[0].Rows.Add(dataRow);
                }
            }
        }

        private void LoadDataLoadPaternsFromDataSet()
        {
            Lignite.Configuration.DataLoad[] temp = new Lignite.Configuration.DataLoad[dsDataLoadPaterns.Tables[0].Rows.Count];

            try
            {
                for (int x = 0; x < temp.Length; x++)
                {
                    DataRow dataRow = dsDataLoadPaterns.Tables[0].Rows[x];

                    temp[x] = new Lignite.Configuration.DataLoad();

                    temp[x].Frequency = Convert.ToDouble(dataRow["Frequency"]);
                    temp[x].TimeBeforeOff = Convert.ToDouble(dataRow["TimeBeforeOff"]);

                    temp[x].Actions = new Lignite.Configuration.DataLoadActions();
                    temp[x].Actions.GetBets = Convert.ToBoolean(dataRow["GetBets"]);
                    temp[x].Actions.GetCompleteMarketTradedVolume = Convert.ToBoolean(dataRow["GetCompleteMarketTradedVolume"]);
                    temp[x].Actions.GetExtendedRunnerInfo = Convert.ToBoolean(dataRow["GetExtendedRunnerInfo"]);
                    temp[x].Actions.GetMarketPrices = Convert.ToBoolean(dataRow["GetMarketPrices"]);
                    temp[x].Actions.GetMarketPricesComplete = Convert.ToBoolean(dataRow["GetMarketPricesComplete"]);
                    temp[x].Actions.TerminateMarketThread = Convert.ToBoolean(dataRow["TerminateMarketThread"]);
                }

                __dataLoadPaterns = temp;
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void dgDataLoadFrequency_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (!displayUpdating)
            {
                for (int x = 2; x < e.Row.Cells.Count; x++)
                {
                    if (e.Row.Cells[x].Value == null)
                    {
                        e.Row.Cells[x].Value = false;
                    }
                }
            }
        }
    }
}
