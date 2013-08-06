/* @name Lignite For Betfair Project
 * @author Betfair Developers Program (http://bdp.betfair.com)
 * @version 0.0.1
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

/*
 * User Control Notes:
 * This control performs the following functions:
 * 1. Display selection specific information
 *    - Prices (bets 3)
 *    - Name
 *    - Racecard information i.e. Silks
 *    - Potensial outcome information
 * 2. Invoke the following actions:
 *    - Show place bet control
 *    - Show total available market depth control
 *    - Show traded volume control
 *    - Hyperlink to Betfair graph
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Betfair.Collections;
using Lignite.Controls.Events;
using Lignite.Controls.Properties;

namespace Lignite.Controls
{
    /// <summary>
    /// Provides a user control to display selection specific information
    /// </summary>
    [ToolboxBitmap(typeof (SelectionView))]
    public partial class SelectionView : UserControl, IUserControl
    {
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
                eventController = value;
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

        #region SelectionView

        private string m_currency;
        private string m_currencySymbol;

        /// <summary>
        /// Gets or sets the currency symbol.
        /// </summary>
        /// <value>The currency symbol.</value>
        public string Currency
        {
            get { return m_currency; }
            set 
            { 
                m_currency = value;
                m_currencySymbol = Helpers.GetCurrencySymbol(value);

                foreach (var priceButton in m_selectionPriceButtons)
                {
                    priceButton.CurrencySymbol = m_currencySymbol;
                }
            }
        }

        /// <summary>
        /// Gets or sets the exchange id.
        /// </summary>
        /// <value>The exchange id.</value>
        public int ExchangeId { get; set; }

        /// <summary>
        /// Gets or sets the market id.
        /// </summary>
        /// <value>The market id.</value>
        public int MarketId { get; set; }

        /// <summary>
        /// Gets or sets the selections data.
        /// </summary>
        /// <value>The selectiondata.</value>
        public Selection SelectionData { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance supports Betfair starting prices.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is BSP market; otherwise, <c>false</c>.
        /// </value>
        public bool IsBSPMarket { get; set; }

        private bool m_showStartingPricesIfAvailable;

        /// <summary>
        /// Gets or sets a value indicating whether [show starting prices if available].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [show starting prices if available]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowStartingPricesIfAvailable
        {
            get { return m_showStartingPricesIfAvailable; }
            set
            {
                m_showStartingPricesIfAvailable = value;

                ShowStartingPricesItems();
            }
        }

        private readonly SelectionPriceButton[] m_selectionPriceButtons;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionView"/> class.
        /// </summary>
        public SelectionView()
        {
            InitializeComponent();

            m_selectionPriceButtons = new[] { btnBack1, btnBack2, btnBack3, btnLay1, btnLay2, btnLay3, btnSPBack, btnSPLay };

            SelectionData = new Selection
                                {
                                    runnerDisplayDetail = new RacecardInfo(),
                                    pricesToBack = new PriceList(),
                                    pricesToLay = new PriceList()
                                };
        }

        /// <summary>
        /// Refreshes the entire controls data display elements.
        /// </summary>
        public void RefreshControl()
        {
            lblSPPrice.Text = "";
            lblClothNumber.Text = "";
            lblStallDraw.Text = "";
            lblWhatIfLeft.Text = "";
            lblWhatIfRight.Text = "";

            if (SelectionData == null) return;

            lblRunnerName.Text = SelectionData.name ?? SelectionData.selectionId.ToString();

            ShowRacecardInfo();

            RefreshControlPrices();
        }

        /// <summary>
        /// Refreshes the controls price display elements.
        /// </summary>
        public void RefreshControlPrices()
        {
            if (m_selectionPriceButtons == null) return;

            foreach (var selectionPriceButton in m_selectionPriceButtons)
            {
                selectionPriceButton.ClearButton();
            }

            if (SelectionData == null) return;

            if (SelectionData.pricesToBack != null)
            {
                foreach (var selectionPriceButton in m_selectionPriceButtons)
                {
                    foreach (Price price in SelectionData.pricesToBack)
                    {
                        if (price.depth != selectionPriceButton.ButtonDepth ||
                            selectionPriceButton.ButtonType != BetTypeOptions.B || selectionPriceButton.IsSpButton)
                            continue;

                        selectionPriceButton.CurrencySymbol = m_currencySymbol;
                        selectionPriceButton.PriceItem = price;
                        continue;
                    }
                }
            }

            if (SelectionData.pricesToLay != null)
            {
                foreach (var selectionPriceButton in m_selectionPriceButtons)
                {
                    foreach (Price price in SelectionData.pricesToLay)
                    {
                        if (price.depth == selectionPriceButton.ButtonDepth &&
                            selectionPriceButton.ButtonType == BetTypeOptions.L && !selectionPriceButton.IsSpButton)
                        {
                            selectionPriceButton.CurrencySymbol = m_currencySymbol;
                            selectionPriceButton.PriceItem = price;
                            continue;
                        }
                    }
                }
            }

            ShowStartingPricesItems();
        }

        /// <summary>
        /// Sets the racecard info (Silks).
        /// </summary>
        private void ShowRacecardInfo()
        {
            panelClothNumber.Visible = false;
            panelStallDraw.Visible = false;
            picBoxSilks.Visible = false;

            if (SelectionData.runnerDisplayDetail == null) return;

            if (SelectionData.runnerDisplayDetail.saddleCloth > 0)
            {
                lblClothNumber.Text = SelectionData.runnerDisplayDetail.saddleCloth.ToString();
                panelClothNumber.Visible = true;
            }

            if (SelectionData.runnerDisplayDetail.stallDraw > 0)
            {
                lblStallDraw.Text = String.Format("({0})", SelectionData.runnerDisplayDetail.stallDraw);
                panelStallDraw.Visible = true;
            }

            if (SelectionData.runnerDisplayDetail.silksURL == null) return;

            picBoxSilks.ImageLocation = @"http://content-cache.betfair.com/feeds_images/Horses/SilkColours/" + SelectionData.runnerDisplayDetail.silksURL;
            picBoxSilks.Visible = true;
        }

        /// <summary>
        /// Sets the starting prices items.
        /// </summary>
        private void ShowStartingPricesItems()
        {
            if (!ShowStartingPricesIfAvailable || !IsBSPMarket)
            {
                if (lblSPPrice.Visible)
                {
                    btnSPBack.Visible = false;
                    lblSPPrice.Visible = false;
                    btnSPLay.Visible = false;
                }
            }
            else
            {
                if (ShowStartingPricesIfAvailable)
                {
                    if (SelectionData.actualSPPrice >= 1.01 && btnSPBack.Visible)
                    {
                        btnSPBack.Visible = false;
                        lblSPPrice.Visible = true;
                        btnSPLay.Visible = false;
                    }
                    else if (!lblSPPrice.Visible)
                    {
                        btnSPBack.Visible = true;
                        lblSPPrice.Visible = true;
                        btnSPLay.Visible = true;
                    }

                    if (SelectionData.actualSPPrice >= 1.01 && SelectionData.actualSPPrice <= 1000)
                    {
                        if (lblSPPrice.Text != SelectionData.actualSPPrice.ToString() &&
                            lblSPPrice.BackColor != Color.Gainsboro)
                        {
                            lblSPPrice.Text = SelectionData.actualSPPrice.ToString();
                            lblSPPrice.BackColor = Color.Gainsboro;
                        }
                    }
                    else if (SelectionData.actualSPPrice < 1.01 && SelectionData.nearSPPrice >= 1.01 && SelectionData.farSPPrice >= 1.01)
                    {
                        lblSPPrice.Text = String.Format("Near: {0}\nFar: {1}", SelectionData.nearSPPrice, SelectionData.farSPPrice);

                        if (lblSPPrice.BackColor != Color.White) lblSPPrice.BackColor = Color.White;
                    }
                    else
                    {
                        lblSPPrice.Text = "?";
                    }
                }
            }
        }

        /// <summary>
        /// Handles the MouseClick event of the selectionPriceButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void selectionPriceButton_MouseClick(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof (SelectionPriceButton) || SelectionData == null) return;

            var button = ((SelectionPriceButton) sender);

            if(button.IsSpButton)
            {
                // todo: implement
            }
            else
            {
                var bet = new Bet
                              {
                                  betCategory = BetCategoryOptions.EXCHANGE,
                                  betPersistence = BetPersistenceOptions.NONE,
                                  betType = button.ButtonType,
                                  price = button.PriceItem.price,
                                  selectionId = SelectionData.selectionId,
                                  exchangeId = ExchangeId,
                                  marketId = MarketId,
                                  asianLineId = SelectionData.asianLineId
                              };

                eventController.InvokeShowBetPlacementControl(this, new ShowPlaceBetControlEventArgs { SenderUID = UniqueInstanceID, Bet = bet, ExchangeId = ExchangeId, MarketId = MarketId, SelectionName = SelectionData.name });
            }
        }

        /// <summary>
        /// Handles the Click event of the panelShowChart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void panelShowChart_Click(object sender, EventArgs e)
        {
            if (SelectionData == null || Currency == null) return;

            var url =
                String.Format(
                    "site.sports.betfair.com/betting/LoadRunnerInfoAction.do?marketId={0}&selectionId={1}&currency={2}",
                    MarketId, SelectionData.selectionId, Currency);

            switch (ExchangeId)
            {
                case 1:
                    Process.Start("http://uk." + url);
                    break;
                case 2:
                    Process.Start("http://au." + url);
                    break;
            }
        }


        /// <summary>
        /// Handles the MouseHover event of the Controls control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Controls_MouseHover(object sender, EventArgs e)
        {
            BackgroundImage = Resources.ControlRunnerActive;
        }

        /// <summary>
        /// Handles the MouseLeave event of the Controls control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Controls_MouseLeave(object sender, EventArgs e)
        {
            BackgroundImage = Resources.RunnerBackGround;
        }

        #endregion

        #region Nested type: SelectionPriceButton

        public class SelectionPriceButton : Button
        {
            private bool m_isActive;
            private bool m_isPrimaryButton;

            [NonSerialized]
            private Price m_priceItem;

            public SelectionPriceButton()
            {
                SetDefaults();
                UpdateBackground();
            }

            public int ButtonDepth { get; set; }

            private BetTypeOptions m_buttonType;

            /// <summary>
            /// Gets or sets the type of the button.
            /// </summary>
            /// <value>The type of the button.</value>
            public BetTypeOptions ButtonType
            {
                get { return m_buttonType; }
                set { m_buttonType = value; UpdateBackground(); }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this instance is a primary button.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if this instance is a primary button; otherwise, <c>false</c>.
            /// </value>
            public bool IsPrimaryButton
            {
                get { return m_isPrimaryButton; }
                set
                {
                    m_isPrimaryButton = value;
                    UpdateBackground();
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this instance is active.
            /// </summary>
            /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
            public bool IsActive
            {
                get { return m_isActive; }
                set
                {
                    m_isActive = value;
                    UpdateBackground();
                }
            }

            private bool m_isSpButton;
            public bool IsSpButton
            {
                get { return m_isSpButton; }
                set 
                { 
                    m_isSpButton = value; 
                    UpdateBackground();
                }
            }

            /// <summary>
            /// Gets or sets the currency symbol.
            /// </summary>
            /// <value>The currency symbol.</value>
            public string CurrencySymbol { get; set; }

            /// <summary>
            /// The price and type item for this button object.
            /// </summary>
            public Price PriceItem
            {
                get
                {
                    if (m_priceItem == null) m_priceItem = new Price();

                    return m_priceItem;
                }
                set { m_priceItem = value ?? new Price(); UpdateButton(); }
            }

            public void UpdateButton()
            {
                if(IsSpButton) return;

                Text = m_priceItem.price <= 0
                           ? ""
                           : String.Format("{0}\n{1}{2}", m_priceItem.price, CurrencySymbol,
                                           Math.Round(m_priceItem.amountAvailable));
            }

            /// <summary>
            /// Clears the button text and price variables.
            /// </summary>
            public void ClearButton()
            {
                m_priceItem = new Price{type = ButtonType};
                UpdateBackground();
                UpdateButton();

                if (!IsSpButton) Text = "";
            }

            protected override void OnMouseEnter(EventArgs e)
            {
                IsActive = true;
                base.OnMouseEnter(e);
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                IsActive = false;
                base.OnMouseLeave(e);
            }

            /// <summary>
            /// Sets the defaults.
            /// </summary>
            private void SetDefaults()
            {
                BackColor = Color.White;
                BackgroundImageLayout = ImageLayout.Stretch;
                CurrencySymbol = "";
                Dock = DockStyle.Right;
                FlatAppearance.BorderColor = Color.White;
                FlatAppearance.BorderSize = 0;
                FlatAppearance.MouseDownBackColor = Color.White;
                FlatAppearance.MouseOverBackColor = Color.White;
                FlatStyle = FlatStyle.Flat;
                Font = new Font("Microsoft Sans Serif", 6.85F, FontStyle.Regular, GraphicsUnit.Point, ((0)));
                Size = new Size(55, 35);
                TabIndex = 4;
                UseVisualStyleBackColor = false;
            }

            private void UpdateBackground()
            {
                if (IsActive)
                {
                    switch (ButtonType)
                    {
                        case BetTypeOptions.B:
                            BackgroundImage = Resources.BackButtonOver;
                            break;
                        case BetTypeOptions.L:
                            BackgroundImage = Resources.LayButtonOver;
                            break;
                    }
                }
                else // The button is not active
                {
                    if (!IsPrimaryButton) BackgroundImage = Resources.DefaultButton;

                    else
                        switch (ButtonType)
                        {
                            case BetTypeOptions.B:
                                BackgroundImage = Resources.BackButton;
                                break;
                            case BetTypeOptions.L:
                                BackgroundImage = Resources.LayButton;
                                break;
                        }
                }

                if (IsSpButton && Text != "SP")
                {
                    Text = "SP";
                }
                else if (Text == "SP" && !IsSpButton)
                {
                    Text = "Price\nSize";
                }
            }
        }

        #endregion
    }
}