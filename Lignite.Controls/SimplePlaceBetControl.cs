using System;
using System.Drawing;
using System.Windows.Forms;
using Betfair.Collections;
using Betfair.Utilities;
using Lignite.Controls.Properties;

namespace Lignite.Controls
{
    public partial class SimplePlaceBetControl : UserControl, IUserControl
    {
        private readonly PriceIncrements m_priceIncrements;

        private Bet m_betRequest;
        private decimal m_prevPriceValue;

        private string m_selectionName;
        private string m_uniqueInstanceID;

        #region Implementation of IUserControl

        /// <summary>
        /// The Lignite control controller is the data path used for communication between controls and the parent form
        /// </summary>
        public EventController Controller
        {
            get { return eventController; }
            set
            {
                eventController.ShowBetPlacementControl -= eventController_ShowBetPlacementControl;

                eventController = value;

                eventController.ShowBetPlacementControl += eventController_ShowBetPlacementControl;
            }
        }

        /// <summary>
        /// Gets the unique instance id for this object.
        /// </summary>
        /// <value>The unique instance ID.</value>
        public string UniqueInstanceID
        {
            get
            {
                if (m_uniqueInstanceID != null) return m_uniqueInstanceID;

                m_uniqueInstanceID = Guid.NewGuid().ToString();

                return m_uniqueInstanceID;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SimplePlaceBetControl"/> class.
        /// </summary>
        public SimplePlaceBetControl()
        {
            InitializeComponent();

            m_priceIncrements = new PriceIncrements();

            m_betRequest = new Bet();
        }

        /// <summary>
        /// Gets or sets the bet request.
        /// </summary>
        /// <value>The bet request.</value>
        public Bet BetRequest
        {
            get { return m_betRequest; }
            set
            {
                m_betRequest = value;

                if (m_betRequest.betType == BetTypeOptions.L)
                {
                    BackgroundImage = Resources.PlaceBetFormBackgroundLay;
                    lblProfitLiability.Text = "Liability";
                    lblProfitLiabilityResult.ForeColor = Color.Red;
                }
                else
                {
                    BackgroundImage = Resources.PlaceBetFormBackground;
                    lblProfitLiability.Text = "Profit";
                    lblProfitLiabilityResult.ForeColor = Color.Green;
                }

                numStake.Value = (decimal) m_betRequest.size;
                numOdds.Value = (decimal) m_betRequest.price;

                if (m_betRequest.betPersistence == BetPersistenceOptions.IN_PLAY_PERSISTENCE)
                    rdBtnBetPersisKeepInPlay.Checked = true;
                if (m_betRequest.betPersistence == BetPersistenceOptions.NONE)
                    rdBtnBetPersisNone.Checked = true;
                if (m_betRequest.betPersistence == BetPersistenceOptions.UNMATCHED_FILL_WITH_SP)
                    rdBtnBetPersisUnmatcheSPFill.Checked = true;
            }
        }

        /// <summary>
        /// Gets or sets the name of the selection.
        /// </summary>
        /// <value>The name of the selection.</value>
        public string SelectionName
        {
            get { return m_selectionName; }
            set
            {
                m_selectionName = value;
                lblRunnerName.Text = m_selectionName;
            }
        }

        /// <summary>
        /// Handles the Click event of the StakeButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void StakeButton_Click(object sender, EventArgs e)
        {
            double val;

            if (sender.GetType() != typeof(Button) || !Double.TryParse(((Button)sender).Tag.ToString(), out val))
                return;
            if(val <= 0) return;

            m_betRequest.size += val;
            numStake.Value = (decimal)m_betRequest.size;
        }

        /// <summary>
        /// Handles the ValueChanged event of the numOdds control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void numOdds_ValueChanged(object sender, EventArgs e)
        {
            // If the submitted price is valid do nothing
            // valid prices range from 0 to 349
            int priceIndexNumber = m_priceIncrements.GetValidPriceValueIndexNumber(numOdds.Value, null);
            if (priceIndexNumber == -1)
            {
                //Make sure that a change actually occured
                if (numOdds.Value != m_prevPriceValue)
                {
                    //if this ValueType is equal 0.01 then shift up if it is -0.01 shift down
                    decimal change = numOdds.Value - m_prevPriceValue;

                    if (change == 0.01m)
                    {
                        decimal temp = m_priceIncrements.GetHigherPriceValue(m_prevPriceValue);
                        m_prevPriceValue = temp;
                        numOdds.Value = m_prevPriceValue;
                    }
                    else if (change == -0.01m)
                    {
                        decimal temp = m_priceIncrements.GetLowerPriceValue(m_prevPriceValue);
                        m_prevPriceValue = temp;
                        numOdds.Value = m_prevPriceValue;
                    }
                    // None of the above - Ok the user submitted their own value and it is invalid
                    // lets get them a valid option
                    else
                    {
                        if (change >= 0.01m) // They were heading up so lets round up
                        {
                            decimal temp = m_priceIncrements.GetValidPriceValue(numOdds.Value, true);
                            m_prevPriceValue = temp;
                            numOdds.Value = m_prevPriceValue;
                        }
                        else // They were heading down so lets round down
                        {
                            decimal temp = m_priceIncrements.GetValidPriceValue(numOdds.Value, false);
                            m_prevPriceValue = temp;
                            numOdds.Value = m_prevPriceValue;
                        }
                    }
                }
            }
            else
            {
                m_prevPriceValue = numOdds.Value;
            }
            DoCalculation();
        }

        /// <summary>
        /// Does the calculation.
        /// </summary>
        private void DoCalculation()
        {
            if (numStake.Value > 0.01m && numOdds.Value > 0.01m)
            {
                lblProfitLiabilityResult.Text = m_betRequest.betType == BetTypeOptions.L
                                                    ? Math.Round(((numStake.Value * numOdds.Value) - numStake.Value), 2).
                                                          ToString()
                                                    : Math.Round(((numStake.Value * numOdds.Value) - numStake.Value), 2).
                                                          ToString();

                m_betRequest.size = Convert.ToDouble(numStake.Value);
                m_betRequest.price = Convert.ToDouble(numOdds.Value);
            }
            else
            {
                lblProfitLiabilityResult.Text = "";
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the numStake control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void numStake_ValueChanged(object sender, EventArgs e)
        {
            DoCalculation();
        }

        /// <summary>
        /// Handles the Click event of the btnSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(RadioButton)) return;

            var radio = sender as RadioButton;

            if (radio != null && radio.Checked && m_betRequest != null)
            {
                m_betRequest.betPersistence = ToEnum<BetPersistenceOptions>(radio.Tag.ToString());
            }
        }

        /// <summary>
        /// String the enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        private static T ToEnum<T>(string str)
            where T : struct
        {
            return (T)Enum.Parse(typeof(T), str);
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            m_prevPriceValue = 1.01m;
            numOdds.Value = 1.01m;
            numStake.Value = 0m;
            lblProfitLiabilityResult.Text = "";

            m_betRequest = new Bet { size = 0, price = 1.01 };

            numOdds.Value = Convert.ToDecimal(m_betRequest.price);
            numStake.Value = Convert.ToDecimal(m_betRequest.size);
            lblRunnerName.Text = "";
        }

        private void eventController_ShowBetPlacementControl(object sender, Events.ShowPlaceBetControlEventArgs e)
        {
            Clear();
            m_betRequest = e.Bet;

            if (e.SelectionName == null)
                lblRunnerName.Text = e.Bet.selectionId.ToString();
            else
            {
                lblRunnerName.Text = e.SelectionName;
            }
        }

        /// <summary>
        /// Occurs when [close clicked].
        /// </summary>
        public event EventHandler CloseClicked;

        /// <summary>
        /// Handles the Click event of the Close control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Close_Click(object sender, EventArgs e)
        {
            if (CloseClicked != null) CloseClicked(sender, e);
        }
    }
}