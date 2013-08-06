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
    public partial class BetfairConfigurationView : UserControl
    {
        //declaring the event
        public event EventHandler DataChanged;

        //Function to trigger the event
        //This will be called when the user clicks the button
        public void OnDataChanged()
        {
            //Invoking all the event handlers
            if (DataChanged != null) DataChanged(betfairConfiguration, new EventArgs());
        }

        public Lignite.Configuration.BetfairConfiguration betfairConfiguration
        {
            get
            {
                if (this.__betfairConfiguration != null)
                {
                    __betfairConfiguration.Username = txtUsername.Text;
                    __betfairConfiguration.VendorSoftwareId = Convert.ToInt32(txtVendorSoftwareId.Text);
                    __betfairConfiguration.ProductId = Convert.ToInt32(txtProductId.Text);
                    __betfairConfiguration.Password = txtPassword.Text;
                    __betfairConfiguration.EndPointGlobalAPI = txtEndPointGlobal.Text;
                    __betfairConfiguration.EndPointExchangeAPIs = new string[2];
                    __betfairConfiguration.EndPointExchangeAPIs[0] = txtEndPointUK.Text;
                    __betfairConfiguration.EndPointExchangeAPIs[1] = txtEndPointAustralia.Text;
                    __betfairConfiguration.AutoKeepAliveFrequency = Convert.ToInt32(txtAutoKeepAlive.Text);

                    return __betfairConfiguration;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.__betfairConfiguration = value;
                UpdateDisplay();
            }
        }
        Lignite.Configuration.BetfairConfiguration __betfairConfiguration;

        public BetfairConfigurationView()
        {
            InitializeComponent();
        }

        public BetfairConfigurationView(Lignite.Configuration.BetfairConfiguration betfairConfiguration)
        {
            InitializeComponent();
            this.__betfairConfiguration = betfairConfiguration;
            UpdateDisplay();
        }

        private bool displayUpdating;
        public void UpdateDisplay()
        {
            displayUpdating = true;
            if (__betfairConfiguration.EndPointExchangeAPIs.Length > 0)
            {
                txtEndPointUK.Text = __betfairConfiguration.EndPointExchangeAPIs[0].ToString();

                if (__betfairConfiguration.EndPointExchangeAPIs.Length >= 2)
                {
                    txtEndPointAustralia.Text = __betfairConfiguration.EndPointExchangeAPIs[1].ToString();
                }
            }
            txtEndPointGlobal.Text = __betfairConfiguration.EndPointGlobalAPI.ToString();
            txtPassword.Text = __betfairConfiguration.Password.ToString();
            txtProductId.Text = __betfairConfiguration.ProductId.ToString();
            txtUsername.Text = __betfairConfiguration.Username.ToString();
            txtVendorSoftwareId.Text = __betfairConfiguration.VendorSoftwareId.ToString();
            txtAutoKeepAlive.Text = __betfairConfiguration.AutoKeepAliveFrequency.ToString();
            displayUpdating = false;
        }

        private void textBox_Validating_string(object sender, CancelEventArgs e)
        {
            if (sender != null && sender.GetType() == typeof(TextBox))
            {
                ValiidateTextBoxValueNotNull((TextBox)sender);

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

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (!displayUpdating)
            {
                OnDataChanged();
            }
        }
    }
}
