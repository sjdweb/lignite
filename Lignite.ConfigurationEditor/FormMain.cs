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
using System.IO;
using System.Windows.Forms;
using Lignite.Configuration;

namespace Lignite.ConfigurationEditor
{
    public partial class FormMain : Form
    {
        public static Settings MySettings;

        private TreeNode nodeBetfair;
        private TreeNode nodeGetAllMarkets;
        private TreeNode nodeStrategyDataLoaderPaterns;

        public FormMain()
        {
            InitializeComponent();

            MySettings = new XmlFileOperations().Read(Directory.GetCurrentDirectory() + "\\lignite.configuration.xml");
            BuildNodes();
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            panelBetfair.Controls.Clear();

            if (e.Node.Name == "StrategyLoadPaterns")
            {
                panelOptions.Visible = true;
                btnDeleteDataLoadPatern.Visible = false;
            }
            else if (e.Node.Tag == null)
            {
            }
            else if (e.Node.Tag.GetType() == typeof (BetfairConfigurationView))
            {
                ((UserControl) e.Node.Tag).Dock = DockStyle.Fill;
                panelBetfair.Controls.Add((UserControl) e.Node.Tag);
                panelOptions.Visible = false;
            }
            else if (e.Node.Tag.GetType() == typeof (GetAllMarketsConfigurationView))
            {
                ((UserControl) e.Node.Tag).Dock = DockStyle.Fill;
                panelBetfair.Controls.Add((UserControl) e.Node.Tag);
                panelOptions.Visible = false;
            }
            else if (e.Node.Tag.GetType() == typeof (StrategyLoadPaternsView))
            {
                ((UserControl) e.Node.Tag).Dock = DockStyle.Fill;
                panelBetfair.Controls.Add((StrategyLoadPaternsView) e.Node.Tag);
                panelOptions.Visible = true;

                btnDeleteDataLoadPatern.Visible = ((StrategyLoadPaternsView) e.Node.Tag).strategyLoadPatern.Key != "Default";
            }

            else if (e.Node.Tag.GetType() == typeof (DataLoadPaternView))
            {
                ((UserControl) e.Node.Tag).Dock = DockStyle.Fill;
                panelBetfair.Controls.Add((DataLoadPaternView) e.Node.Tag);
                panelOptions.Visible = false;
            }
        }

        private static void strategyLoadPaternsView1_DataChanged(object sender, EventArgs e)
        {
            if (sender != null && sender.GetType() == typeof (StrategyLoadPatern))
            {
                for (int x = 0; x < MySettings.StrategyLoadPaterns.Length; x++)
                {
                    if (MySettings.StrategyLoadPaterns[x].Key == ((StrategyLoadPatern) sender).Key)
                    {
                        MySettings.StrategyLoadPaterns[x] = ((StrategyLoadPatern) sender);
                        break;
                    }
                }
            }
        }

        private static void CreateDataLoadpaternTreeItems(TreeNode parentNode, StrategyLoadPaternsView StrategyLoadPaternsViewObject)
        {
            /*** Default ***/
            var node = new TreeNode("Default")
                           {
                               Text = "Default",
                               Name = "Default",
                               Tag = StrategyLoadPaternsViewObject.GetDataLoadPaternsView_Default()
                           };
            //node.Tag = dataLoadPaterns.Default;
            parentNode.Nodes.Add(node);

            /*** Default ***/
            node = new TreeNode("HasBets")
                       {
                           Text = "HasBets",
                           Name = "HasBets",
                           Tag = StrategyLoadPaternsViewObject.GetDataLoadPaternsView_HasBets()
                       };
            //node.Tag = dataLoadPaterns.HasBets;
            parentNode.Nodes.Add(node);

            /*** Default ***/
            node = new TreeNode("HasUnmatchedBets")
                       {
                           Text = "Has Unmatched Bets",
                           Name = "HasUnmatchedBets",
                           Tag = StrategyLoadPaternsViewObject.GetDataLoadPaternsView_HasUnmatchedBets()
                       };
            //node.Tag = dataLoadPaterns.HasUnmatchedBets;
            parentNode.Nodes.Add(node);

            /*** Default ***/
            node = new TreeNode("Inactive")
                       {
                           Text = "Inactive",
                           Name = "Inactive",
                           Tag = StrategyLoadPaternsViewObject.GetDataLoadPaternsView_Inactive()
                       };
            //node.Tag = dataLoadPaterns.Inactive;
            parentNode.Nodes.Add(node);

            /*** Default ***/
            node = new TreeNode("InPlay")
                       {
                           Text = "In-Play",
                           Name = "InPlay",
                           Tag = StrategyLoadPaternsViewObject.GetDataLoadPaternsView_InPlay()
                       };
            //node.Tag = dataLoadPaterns.InPlay;
            parentNode.Nodes.Add(node);

            /*** Default ***/
            node = new TreeNode("Suspended")
                       {
                           Text = "Suspended",
                           Name = "Suspended",
                           Tag = StrategyLoadPaternsViewObject.GetDataLoadPaternsView_Suspended()
                       };
            //node.Tag = dataLoadPaterns.Suspended;
            parentNode.Nodes.Add(node);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Would you like to save changes before exiting?\n\nAny unsaved changes will be lost!\n\nYes - Save and exit.\nNo - Exit without saving.\nCancel - Do nothing.",
                    "Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (result == DialogResult.No)
            {
                Close();
            }
            if (result == DialogResult.Yes)
            {
                new XmlFileOperations().Write(MySettings,
                                              Directory.GetCurrentDirectory() + "\\lignite.configuration.xml");
                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            new XmlFileOperations().Write(MySettings, Directory.GetCurrentDirectory() + "\\lignite.configuration.xml");

            MessageBox.Show("Saved to " + Directory.GetCurrentDirectory() + "\\lignite.configuration.xml", "File Saved",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void betfairConfigurationView1_DataChanged(object sender, EventArgs e)
        {
            if (sender != null && sender.GetType() == typeof (BetfairConfiguration))
            {
                MySettings.Betfair = (BetfairConfiguration) sender;
            }
        }

        private static void getAllMarketsConfigurationView1_DataChanged(object sender, EventArgs e)
        {
            if (sender != null && sender.GetType() == typeof (GetAllMarkets))
            {
                MySettings.GetAllMarketsConfiguration = (GetAllMarkets) sender;
            }
        }

        private void btnCreateBackup_Click(object sender, EventArgs e)
        {
            string backUpName = String.Format("{0}\\{1}.lignite.configuration.xml", Directory.GetCurrentDirectory(),
                                              DateTime.Now.ToFileTimeUtc());
            File.Copy(Directory.GetCurrentDirectory() + "\\lignite.configuration.xml", backUpName);

            MessageBox.Show("Copy of original saved to " + backUpName, "Backup", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnCreateNewDataLoadPatern_Click(object sender, EventArgs e)
        {
            var strategyItem = new StrategyLoadPatern
                                   {
                                       Name = "New",
                                       Key = Guid.NewGuid().ToString(),
                                       Version = "",
                                       OnMarketLoadActions = new DataLoadActions(),
                                       CustomLibrary = "",
                                       DataLoadPaterns = new DataLoadPaterns()
                                   };

            /*** Strategy Data Loader Paterns Config Tree Node ***/
            var node = new TreeNode(strategyItem.Name) {Name = strategyItem.Name};
            var StrategyLoadPaternsViewObject = new StrategyLoadPaternsView(strategyItem);
            StrategyLoadPaternsViewObject.DataChanged += strategyLoadPaternsView1_DataChanged;
            node.Tag = StrategyLoadPaternsViewObject;
            nodeStrategyDataLoaderPaterns.Nodes.Add(node);

            var node4 = new TreeNode {Name = "DataLoadPaterns", Text = "Data Load Paterns", Tag = node.Tag};
            node.Nodes.Add(node4);

            var tempStrategyLoadPaterns = new StrategyLoadPatern[MySettings.StrategyLoadPaterns.Length + 1];

            for (int x = 0; x < tempStrategyLoadPaterns.Length; x++)
            {
                tempStrategyLoadPaterns[x] = x >= MySettings.StrategyLoadPaterns.Length ? strategyItem : MySettings.StrategyLoadPaterns[x];
            }

            MySettings.StrategyLoadPaterns = tempStrategyLoadPaterns;

            CreateDataLoadpaternTreeItems(node4, StrategyLoadPaternsViewObject);

            treeView.SelectedNode = node;
        }

        private void btnDeleteDataLoadPatern_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Tag.GetType() == typeof (StrategyLoadPaternsView))
            {
                var removeMe = (StrategyLoadPaternsView) treeView.SelectedNode.Tag;
                DialogResult result = MessageBox.Show(
                    "Are sure you want to delete " + removeMe.strategyLoadPatern.Name, "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    string keyToRemove = removeMe.strategyLoadPatern.Key;

                    if (treeView.SelectedNode.Name == "DataLoadPaterns")
                    {
                        treeView.SelectedNode = treeView.SelectedNode.Parent;
                    }

                    treeView.SelectedNode.Remove();

                    var tempStrategyLoadPaterns = new StrategyLoadPatern[MySettings.StrategyLoadPaterns.Length - 1];

                    int count = 0;
                    for (int x = 0; x < MySettings.StrategyLoadPaterns.Length; x++)
                    {
                        if (MySettings.StrategyLoadPaterns[x].Key != keyToRemove)
                        {
                            tempStrategyLoadPaterns[count] = MySettings.StrategyLoadPaterns[x];
                            count++;
                        }
                    }

                    MySettings.StrategyLoadPaterns = tempStrategyLoadPaterns;
                }
            }
        }

        #region Build Nodes

        private void BuildNodes()
        {
            treeView.Nodes.Clear();

            #region Betfair

            nodeBetfair = new TreeNode("Betfair") {Name = "Betfair"};
            var BetfairConfigurationViewObject = new BetfairConfigurationView(MySettings.Betfair);
            BetfairConfigurationViewObject.DataChanged += betfairConfigurationView1_DataChanged;
            nodeBetfair.Tag = BetfairConfigurationViewObject;
            treeView.Nodes.Add(nodeBetfair);

            #endregion

            #region GetAllMarketsConfiguration

            /*** Get All Markets Config Tree Node ***/
            nodeGetAllMarkets = new TreeNode("Get All Markets Configuration") {Name = "GetAllMarketsConfiguration"};
            var GetAllMarketsConfigurationViewObject =
                new GetAllMarketsConfigurationView(MySettings.GetAllMarketsConfiguration);
            GetAllMarketsConfigurationViewObject.DataChanged += getAllMarketsConfigurationView1_DataChanged;
            nodeGetAllMarkets.Tag = GetAllMarketsConfigurationViewObject;
            treeView.Nodes.Add(nodeGetAllMarkets);

            #endregion

            #region StrategyLoadPaterns

            /*** Strategy Data Loader Paterns Config Tree Node ***/
            nodeStrategyDataLoaderPaterns = new TreeNode("Strategy Load Paterns")
                                                {
                                                    Name = "StrategyLoadPaterns",
                                                    Tag = null
                                                };
            treeView.Nodes.Add(nodeStrategyDataLoaderPaterns);

            /*** Strategy Data Loader Paterns Config Tree Node ***/
            TreeNode node;
            foreach (var strategyItem in MySettings.StrategyLoadPaterns)
            {
                /*** Strategy Data Loader Paterns Config Tree Node ***/
                node = new TreeNode(strategyItem.Name) {Name = strategyItem.Name};
                var StrategyLoadPaternsViewObject = new StrategyLoadPaternsView(strategyItem);
                StrategyLoadPaternsViewObject.DataChanged += strategyLoadPaternsView1_DataChanged;
                node.Tag = StrategyLoadPaternsViewObject;
                nodeStrategyDataLoaderPaterns.Nodes.Add(node);

                var node4 = new TreeNode {Name = "DataLoadPaterns", Text = "Data Load Paterns", Tag = node.Tag};
                node.Nodes.Add(node4);

                CreateDataLoadpaternTreeItems(node4, StrategyLoadPaternsViewObject);
            }

            #endregion
        }

        #endregion
    }
}