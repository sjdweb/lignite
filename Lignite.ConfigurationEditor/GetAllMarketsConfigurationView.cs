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
    public partial class GetAllMarketsConfigurationView : UserControl
    {
        //declaring the event
        public event EventHandler DataChanged;

        //Function to trigger the event
        //This will be called when the user clicks the button
        public void OnDataChanged()
        {
            //Invoking all the event handlers
            if (DataChanged != null) DataChanged(getAllMarketsConfiguration, new EventArgs());
        }

        public Lignite.Configuration.GetAllMarkets getAllMarketsConfiguration
        {
            get
            {

                __getAllMarketsConfiguration.EventDateFrom = Convert.ToDouble(txtEventDateFrom.Text);
                __getAllMarketsConfiguration.Countries = txtCountries.Lines;
                __getAllMarketsConfiguration.EventDateTo = Convert.ToDouble(txtEventDateTo.Text);
                __getAllMarketsConfiguration.EventIds = ConvertToInt32Array(txtEventIds.Lines);
                __getAllMarketsConfiguration.RunMarketsQueryEvery = Convert.ToDouble(txtRunMarketsQueryEvery.Text);

                if (cmbExchangeIds.SelectedIndex == 0)
                {
                    __getAllMarketsConfiguration.ExchangeIds = new int[1];
                    __getAllMarketsConfiguration.ExchangeIds[0] = 1;
                }
                else if (cmbExchangeIds.SelectedIndex == 1)
                {
                    __getAllMarketsConfiguration.ExchangeIds = new int[1];
                    __getAllMarketsConfiguration.ExchangeIds[0] = 2;
                }
                else if (cmbExchangeIds.SelectedIndex == 2)
                {
                    __getAllMarketsConfiguration.ExchangeIds = new int[2];
                    __getAllMarketsConfiguration.ExchangeIds[0] = 1;
                    __getAllMarketsConfiguration.ExchangeIds[1] = 2;
                }

                return __getAllMarketsConfiguration;
            }
            set
            {
                this.__getAllMarketsConfiguration = value;
                UpdateDisplay();
            }
        }
        Lignite.Configuration.GetAllMarkets __getAllMarketsConfiguration;

        public GetAllMarketsConfigurationView()
        {
            InitializeComponent();
            __getAllMarketsConfiguration = new Lignite.Configuration.GetAllMarkets();
        }

        public GetAllMarketsConfigurationView(Lignite.Configuration.GetAllMarkets getAllMarketsConfiguration)
        {
            InitializeComponent();
            __getAllMarketsConfiguration = getAllMarketsConfiguration;
            UpdateDisplay();
        }

        private bool displayUpdating;
        private void UpdateDisplay()
        {
            displayUpdating = true;
            txtEventDateFrom.Text = __getAllMarketsConfiguration.EventDateFrom.ToString();
            txtCountries.Lines = __getAllMarketsConfiguration.Countries;
            txtEventDateTo.Text = __getAllMarketsConfiguration.EventDateTo.ToString();
            txtEventIds.Lines = ConvertToStringArray(__getAllMarketsConfiguration.EventIds);
            txtRunMarketsQueryEvery.Text = __getAllMarketsConfiguration.RunMarketsQueryEvery.ToString();

            if (__getAllMarketsConfiguration.ExchangeIds.Length == 2) cmbExchangeIds.SelectedIndex = 2;
            else if (__getAllMarketsConfiguration.ExchangeIds.Length == 1)
            {
                if (__getAllMarketsConfiguration.ExchangeIds[0] == 1) cmbExchangeIds.SelectedIndex = 0;
                if(__getAllMarketsConfiguration.ExchangeIds[0] == 2) cmbExchangeIds.SelectedIndex = 1;
            }
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

        private void textBox_Validating_int_array(object sender, CancelEventArgs e)
        {
            if (sender != null && sender.GetType() == typeof(TextBox))
            {
                ValiidateTextBoxValueNotNull((TextBox)sender);

                string[] text = ((TextBox)sender).Lines;

                try
                {
                    foreach(string t in text)
                    {
                        int temp = int.Parse(t);
                    }
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
                //errorProvider1.SetError(textBox, "Invalid!");
            }
            else
            {
                errorProvider1.SetError(textBox, "");
            }
        }

        private Nullable<int>[] ConvertToInt32Array(string[] value)
        {
            if (value == null || value.Length == 0) return null;

            Nullable<int>[] response = new Nullable<int>[value.Length];
            int count = 0;
            foreach (string s in value) { response[count] = int.Parse(s); count++; }
            return response;
        }


        private string[] ConvertToStringArray(Nullable<int>[] value)
        {
            if (value == null || value.Length == 0) return null;

            string[] response = new string[value.Length];
            int count = 0;
            foreach (int s in value) { response[count] = s.ToString(); count++; }
            return response;
        }

        private string[] ConvertToStringArray(int[] value)
        {
            if (value == null || value.Length == 0) return null;

            string[] response = new string[value.Length];
            int count = 0;
            foreach (int s in value) { response[count] = s.ToString(); count++; }
            return response;
        }

        private void txtRunMarketsQueryEvery_TextChanged(object sender, EventArgs e)
        {
            if (!displayUpdating)
            {
                OnDataChanged();
            }
        }
    }
}
