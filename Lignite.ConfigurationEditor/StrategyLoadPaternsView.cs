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
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lignite.ConfigurationEditor
{
    public partial class StrategyLoadPaternsView : UserControl
    {
        //declaring the event
        public event EventHandler DataChanged;

        //Function to trigger the event
        //This will be called when the user clicks the button
        public void OnDataChanged()
        {
            //Invoking all the event handlers
            if (DataChanged != null) DataChanged(strategyLoadPatern, new EventArgs());
        }


        private Lignite.Configuration.StrategyLoadPatern __strategyLoadPatern;
        public Lignite.Configuration.StrategyLoadPatern strategyLoadPatern
        {
            get
            {
                if (__strategyLoadPatern != null)
                {
                    __strategyLoadPatern.Key = txtKey.Text;
                    __strategyLoadPatern.Name = txtName.Text;
                    __strategyLoadPatern.Version = txtVersion.Text;

                    __strategyLoadPatern.OnMarketLoadActions.GetMarketPrices = rbGetMarketPrices.Checked;
                    __strategyLoadPatern.OnMarketLoadActions.GetMarketPricesComplete = rbGetMarketPricesComplete.Checked;

                    __strategyLoadPatern.OnMarketLoadActions.GetBets = chkGetBets.Checked;
                    __strategyLoadPatern.OnMarketLoadActions.GetCompleteMarketTradedVolume = chkGetCompleteMarketTradedVolume.Checked;
                    __strategyLoadPatern.OnMarketLoadActions.GetExtendedRunnerInfo = chkGetExtendedRunnerInfo.Checked;
                    __strategyLoadPatern.OnMarketLoadActions.TerminateMarketThread = false;

                    if (__strategyLoadPatern.Key.ToLower() == "default")
                    {
                        __strategyLoadPatern.CustomLibrary = null;
                        __strategyLoadPatern.FilterGetAllMarketsResults = null;
                    }
                    else
                    {
                        __strategyLoadPatern.CustomLibrary = txtCustomLibrary.Text;
                        __strategyLoadPatern.FilterGetAllMarketsResults = LoadFilterGetAllMarketsResultsFromDataSet();
                    }
                }
                return __strategyLoadPatern;
            }
            set
            {
                __strategyLoadPatern = value;
                UpdateDisplay();
            }
        }

        public StrategyLoadPaternsView()
        {
            InitializeComponent();
        }

        public StrategyLoadPaternsView(Lignite.Configuration.StrategyLoadPatern strategyLoadPatern)
        {
            InitializeComponent();
            this.strategyLoadPatern = strategyLoadPatern;
            LoadFilterGetAllMarketsResultsFromDataSet();
            Loadplugin();
        }

        public bool displayUpdating;
        public void UpdateDisplay()
        {
            displayUpdating = true;
            if (__strategyLoadPatern != null)
            {
                txtKey.Text = __strategyLoadPatern.Key.ToString();
                txtName.Text = __strategyLoadPatern.Name.ToString();
                txtVersion.Text = __strategyLoadPatern.Version.ToString();

                rbGetMarketPrices.Checked = __strategyLoadPatern.OnMarketLoadActions.GetMarketPrices;
                rbGetMarketPricesComplete.Checked = __strategyLoadPatern.OnMarketLoadActions.GetMarketPricesComplete;

                chkGetBets.Checked = __strategyLoadPatern.OnMarketLoadActions.GetBets;
                chkGetCompleteMarketTradedVolume.Checked = __strategyLoadPatern.OnMarketLoadActions.GetCompleteMarketTradedVolume;
                chkGetExtendedRunnerInfo.Checked = __strategyLoadPatern.OnMarketLoadActions.GetExtendedRunnerInfo;
                chkTerminateMarketThread.Checked = false;

                if (__strategyLoadPatern.Key.ToLower() == "default")
                {
                    txtCustomLibrary.Text = "";
                    txtCustomLibrary.Enabled = false;
                    groupBoxFilterMarketResults.Visible = false;
                    btnDirectoryBrowser.Visible = false;
                    btnShowPluginForm.Visible = false;
                }
                else
                {
                    txtCustomLibrary.Text = __strategyLoadPatern.CustomLibrary.ToString();
                    txtCustomLibrary.Enabled = true;
                    groupBoxFilterMarketResults.Visible = true;
                    btnDirectoryBrowser.Visible = true;
                    btnShowPluginForm.Visible = true;
                }

                LoadDataSetFromFilterGetAllMarketsResults();

            }

            displayUpdating = false;
        }

        private void LoadDataSetFromFilterGetAllMarketsResults()
        {
            dsGetAllMarketsResultsFilters.Clear();

            if (__strategyLoadPatern.FilterGetAllMarketsResults != null)
            {
                for (int x = 0; x < __strategyLoadPatern.FilterGetAllMarketsResults.Length; x++)
                {
                    Lignite.Configuration.GetAllMarketsResultsFilter getAllMarketsResultsFilter = __strategyLoadPatern.FilterGetAllMarketsResults[x];
                    bool loop = true;

                    while (loop)
                    {
                        if (getAllMarketsResultsFilter != null)
                        {
                            DataRow filterRow = dsGetAllMarketsResultsFilters.Tables[0].NewRow();

                            filterRow["Field"] = getAllMarketsResultsFilter.Field;
                            filterRow["Operator"] = getAllMarketsResultsFilter.Operator;
                            filterRow["Value"] = getAllMarketsResultsFilter.Value;

                            dsGetAllMarketsResultsFilters.Tables[0].Rows.Add(filterRow);

                            getAllMarketsResultsFilter = getAllMarketsResultsFilter.And;
                        }
                        else
                        {
                            loop = false;
                        }
                    }
                }
            }
        }

        private Lignite.Configuration.GetAllMarketsResultsFilter[] LoadFilterGetAllMarketsResultsFromDataSet()
        {
            Lignite.Configuration.GetAllMarketsResultsFilter[] response = new Lignite.Configuration.GetAllMarketsResultsFilter[1];

            Lignite.Configuration.GetAllMarketsResultsFilter filter = null;
            foreach (DataRow row in dsGetAllMarketsResultsFilters.Tables[0].Rows)
            {
                if (row.RowState != DataRowState.Detached)
                {
                    Lignite.Configuration.GetAllMarketsResultsFilter and = new Lignite.Configuration.GetAllMarketsResultsFilter();
                    and.Field = row["Field"].ToString();
                    and.Operator = (Lignite.Configuration.QueryOperator)Enum.Parse(typeof(Lignite.Configuration.QueryOperator), row["Operator"].ToString());
                    and.Value = row["Value"].ToString();

                    and.And = filter;
                    filter = and;
                }
            }
            response[0] = filter;
            return response;
        }

        private void textBox_Validating_string(object sender, CancelEventArgs e)
        {
            if (sender != null && sender.GetType() == typeof(TextBox))
            {
                ValiidateTextBoxValueNotNull((TextBox)sender);
                object o = dsGetAllMarketsResultsFilters;

                if (((TextBox)sender).Text.Length < 2)
                {
                    errorProvider1.SetError(((TextBox)sender), "Invalid!");
                }
            }
        }

        private void textBox_Validating_int(object sender, CancelEventArgs e)
        {
            if (sender != null && sender.GetType() == typeof(TextBox))
            {
                ValiidateTextBoxValueNotNull((TextBox)sender);

                string text = ((TextBox)sender).Text;

                try
                {
                    int temp = int.Parse(text);
                }
                catch
                {
                    errorProvider1.SetError(((TextBox)sender), "Not a number!");
                }
            }
        }

        private void ValiidateTextBoxValueNotNull(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                errorProvider1.SetError(textBox, "Invalid!");
            }
            else
            {
                errorProvider1.SetError(textBox, "");
            }
        }

        private void chkGetCompleteMarketTradedVolume_CheckedChanged(object sender, EventArgs e)
        {
            if (!displayUpdating)
            {
                if (__strategyLoadPatern.OnMarketLoadActions == null)
                {
                    __strategyLoadPatern.OnMarketLoadActions = new Lignite.Configuration.DataLoadActions();
                }

                __strategyLoadPatern.OnMarketLoadActions.GetBets = chkGetBets.Checked;
                __strategyLoadPatern.OnMarketLoadActions.GetCompleteMarketTradedVolume = chkGetCompleteMarketTradedVolume.Checked;
                __strategyLoadPatern.OnMarketLoadActions.GetExtendedRunnerInfo = chkGetExtendedRunnerInfo.Checked;
                __strategyLoadPatern.OnMarketLoadActions.GetMarketPrices = rbGetMarketPrices.Checked;
                __strategyLoadPatern.OnMarketLoadActions.GetMarketPricesComplete = rbGetMarketPricesComplete.Checked;
                __strategyLoadPatern.OnMarketLoadActions.TerminateMarketThread = chkTerminateMarketThread.Checked;

                OnDataChanged();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (!displayUpdating)
            {
                if (__strategyLoadPatern == null)
                {
                    __strategyLoadPatern = new Lignite.Configuration.StrategyLoadPatern();
                }

                __strategyLoadPatern.CustomLibrary = txtCustomLibrary.Text;
                __strategyLoadPatern.Key = txtKey.Text;
                __strategyLoadPatern.Name = txtName.Text;
                __strategyLoadPatern.Version = txtVersion.Text;

                OnDataChanged();
            }
        }

        private void dgFilterGetAllMarketsResultsWhere_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (!displayUpdating && e.ListChangedType != ListChangedType.Reset)
            {
                __strategyLoadPatern.FilterGetAllMarketsResults = LoadFilterGetAllMarketsResultsFromDataSet();
                OnDataChanged();
            }
        }

        /*********************************************/

        public DataLoadPaternView DataLoadPaternsView_Default;
        public DataLoadPaternView GetDataLoadPaternsView_Default()
        {
            DataLoadPaternsView_Default = new DataLoadPaternView(__strategyLoadPatern.DataLoadPaterns.Default);
            DataLoadPaternsView_Default.DataChanged += new EventHandler(dataLoadPaternsView_Default_DataChanged);
            return DataLoadPaternsView_Default;
        }
        private void dataLoadPaternsView_Default_DataChanged(object sender, EventArgs e)
        {
            if (sender != null && sender.GetType() == typeof(Lignite.Configuration.DataLoad[]))
            {
                __strategyLoadPatern.DataLoadPaterns.Default = (Lignite.Configuration.DataLoad[])sender;
                OnDataChanged();
            }
        }

        /*********************************************/

        public DataLoadPaternView DataLoadPaternsView_HasBets;
        public DataLoadPaternView GetDataLoadPaternsView_HasBets()
        {
            DataLoadPaternsView_HasBets = new DataLoadPaternView(__strategyLoadPatern.DataLoadPaterns.HasBets);
            DataLoadPaternsView_HasBets.DataChanged += new EventHandler(dataLoadPaternsView_HasBets_DataChanged);
            return DataLoadPaternsView_HasBets;
        }
        private void dataLoadPaternsView_HasBets_DataChanged(object sender, EventArgs e)
        {
            if (sender != null && sender.GetType() == typeof(Lignite.Configuration.DataLoad[]))
            {
                __strategyLoadPatern.DataLoadPaterns.HasBets = (Lignite.Configuration.DataLoad[])sender;
            }
        }

        /*********************************************/

        public DataLoadPaternView DataLoadPaternsView_HasUnmatchedBets;
        public DataLoadPaternView GetDataLoadPaternsView_HasUnmatchedBets()
        {
            DataLoadPaternsView_HasUnmatchedBets = new DataLoadPaternView(__strategyLoadPatern.DataLoadPaterns.HasUnmatchedBets);
            DataLoadPaternsView_HasUnmatchedBets.DataChanged += new EventHandler(dataLoadPaternsView_HasUnmatchedBets_DataChanged);
            return DataLoadPaternsView_HasUnmatchedBets;
        }
        private void dataLoadPaternsView_HasUnmatchedBets_DataChanged(object sender, EventArgs e)
        {
            if (sender != null && sender.GetType() == typeof(Lignite.Configuration.DataLoad[]))
            {
                __strategyLoadPatern.DataLoadPaterns.HasUnmatchedBets = (Lignite.Configuration.DataLoad[])sender;
            }
        }

        /*********************************************/

        public DataLoadPaternView DataLoadPaternsView_Inactive;
        public DataLoadPaternView GetDataLoadPaternsView_Inactive()
        {
            DataLoadPaternsView_Inactive = new DataLoadPaternView(__strategyLoadPatern.DataLoadPaterns.Inactive);
            DataLoadPaternsView_Inactive.DataChanged += new EventHandler(dataLoadPaternsView_Inactive_DataChanged);
            return DataLoadPaternsView_Inactive;
        }
        private void dataLoadPaternsView_Inactive_DataChanged(object sender, EventArgs e)
        {
            if (sender != null && sender.GetType() == typeof(Lignite.Configuration.DataLoad[]))
            {
                __strategyLoadPatern.DataLoadPaterns.Inactive = (Lignite.Configuration.DataLoad[])sender;
            }
        }

        /*********************************************/

        public DataLoadPaternView DataLoadPaternsView_InPlay;
        public DataLoadPaternView GetDataLoadPaternsView_InPlay()
        {
            DataLoadPaternsView_InPlay = new DataLoadPaternView(__strategyLoadPatern.DataLoadPaterns.InPlay);
            DataLoadPaternsView_InPlay.DataChanged += new EventHandler(dataLoadPaternsView_InPlay_DataChanged);
            return DataLoadPaternsView_InPlay;
        }
        private void dataLoadPaternsView_InPlay_DataChanged(object sender, EventArgs e)
        {
            if (sender != null && sender.GetType() == typeof(Lignite.Configuration.DataLoad[]))
            {
                __strategyLoadPatern.DataLoadPaterns.InPlay = (Lignite.Configuration.DataLoad[])sender;
            }
        }

        /*********************************************/

        public DataLoadPaternView DataLoadPaternsView_Suspended;
        public DataLoadPaternView GetDataLoadPaternsView_Suspended()
        {
            DataLoadPaternsView_Suspended = new DataLoadPaternView(__strategyLoadPatern.DataLoadPaterns.Suspended);
            DataLoadPaternsView_Suspended.DataChanged += new EventHandler(dataLoadPaternsView_Suspended_DataChanged);
            return DataLoadPaternsView_Suspended;
        }

        private void dataLoadPaternsView_Suspended_DataChanged(object sender, EventArgs e)
        {
            if (sender != null && sender.GetType() == typeof(Lignite.Configuration.DataLoad[]))
            {
                __strategyLoadPatern.DataLoadPaterns.Suspended = (Lignite.Configuration.DataLoad[])sender;
            }
        }

        private void btnDirectoryBrowser_Click(object sender, EventArgs e)
        {
            var startDir = Directory.GetCurrentDirectory();
            openFileDialog.DefaultExt = ".dll";
            openFileDialog.Filter = "All libraries (*.dll)|*.dll";
            openFileDialog.FileName = "";
            openFileDialog.AddExtension = true;
            openFileDialog.AutoUpgradeEnabled = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.InitialDirectory = startDir;
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            txtCustomLibrary.Text = openFileDialog.SafeFileName;
            strategyLoadPatern.CustomLibrary = openFileDialog.SafeFileName;
            strategyLoadPatern.CustomLibraryConfigSection = null;
            Loadplugin();
        }


        #region Load Plugins

        private Lignite.Plugin.PluginManager m_plugin;

        /// <summary>
        /// Pre load the plugin specified in the configuration file
        /// </summary>
        private void Loadplugin()
        {
            if (strategyLoadPatern != null && strategyLoadPatern.CustomLibrary != null && strategyLoadPatern.CustomLibrary != "")
            {
                m_plugin = new Lignite.Plugin.PluginManager(Directory.GetCurrentDirectory() + "\\" + strategyLoadPatern.CustomLibrary, strategyLoadPatern.CustomLibraryConfigSection);

                if (m_plugin.Settings.hasForm)
                    btnShowPluginForm.Visible = true;
                else
                    btnShowPluginForm.Visible = false;
            }
        }

        #endregion

        private void btnShowPluginForm_Click(object sender, EventArgs e)
        {
            if (m_plugin != null)
            {
                m_plugin.ShowWinForm();
                strategyLoadPatern.CustomLibraryConfigSection = m_plugin.GetIPluginBasePropertyValue<Plugin.PluginConfigurationBase>( Plugin.PluginManager.PluginBaseProperty.Configuration);
            }
        }
    }
}
