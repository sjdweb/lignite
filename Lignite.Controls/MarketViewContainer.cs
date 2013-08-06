using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Betfair.Collections;
using Lignite.Controls.Events;
using Lignite.Controls.Properties;

namespace Lignite.Controls
{
    [ToolboxBitmap(typeof (MarketViewContainer))]
    public partial class MarketViewContainer : UserControl, IUserControl
    {
        #region Variables

        /// <summary>
        /// The page currently being displayed.
        /// </summary>
        public int CurrentPage = 1;

        private int m_itemsPerPage = 20;

        private List<MarketViewStateItem> m_marketViewStateItemList;
        private bool m_showMenuPathInDisplayName = true;
        private bool m_showStartingPricesIfAvailable = true;
        private string m_uniqueInstanceID;
        private MarketViewSortOrder sortOrder = MarketViewSortOrder.DATE_FIRST_TO_LAST;

        /// <summary>
        /// The total number of pages.
        /// </summary>
        public int TotalPages = 1;

        /// <summary>
        /// Display the complete menu tree in the market name label
        /// </summary>
        public bool ShowMenuPathInDisplayName
        {
            get { return m_showMenuPathInDisplayName; }
            set
            {
                m_showMenuPathInDisplayName = value;

                foreach (MarketView item in panelThreadControls.Controls)
                    item.ShowMenuPathInDisplayName = m_showMenuPathInDisplayName;
            }
        }

        /// <summary>
        /// Display the Betfair starting prices if this is a BSP market
        /// </summary>
        public bool ShowStartingPricesIfAvailable
        {
            get { return m_showStartingPricesIfAvailable; }
            set
            {
                m_showStartingPricesIfAvailable = value;

                foreach (MarketView item in panelThreadControls.Controls)
                    item.ShowStartingPricesIfAvailable = m_showStartingPricesIfAvailable;
            }
        }

        /// <summary>
        /// List of  MarketViewStateItems
        /// </summary>
        public List<MarketViewStateItem> MarketViewStateItemList
        {
            get
            {
                if (m_marketViewStateItemList == null) m_marketViewStateItemList = new List<MarketViewStateItem>();
                return m_marketViewStateItemList;
            }
        }

        /// <summary>
        /// Gets or sets the items per page.
        /// The number has to be between 1 and 50, anymore than this has an undesiarable performance impact.
        /// </summary>
        /// <value>The items per page. Default 20.</value>
        public int ItemsPerPage
        {
            get { return m_itemsPerPage; }
            set
            {
                if (Double.IsNaN(value) ||
                    Double.IsInfinity(value) ||
                    value > 50 ||
                    value < 1)
                {
                    throw new Exception("The value has to be between 1 and 50!");
                }

                m_itemsPerPage = value;

                if (!listItemsPerPage.Items.Contains(m_itemsPerPage.ToString()))
                {
                    listItemsPerPage.Items.Add(m_itemsPerPage);
                }

                listItemsPerPage.SelectedItem = m_itemsPerPage.ToString();

                // Nothing to do get out of here.
                if (panelThreadControls.Controls.Count >= m_itemsPerPage) return;

                var difference = m_itemsPerPage - panelThreadControls.Controls.Count;

                SuspendLayout();

                panelThreadControls.Visible = false;
                panelThreadControls.Dock = DockStyle.None;
                panelThreadControls.Height = 0;
                panelThreadControls.Visible = true;

                // Make all the controls visible otherwise z-order does not get updated correctly

                foreach (MarketView marketView in panelThreadControls.Controls)
                {
                    marketView.Visible = true;
                    marketView.ResetControl();
                }

                var panelThreadControlsCount = panelThreadControls.Controls.Count;

                for (var x = panelThreadControlsCount; x < panelThreadControlsCount + difference; x++)
                {
                    var ctrl = new MarketView
                                   {
                                       Visible = true,
                                       ShowMenuPathInDisplayName = ShowMenuPathInDisplayName,
                                       MaximizeMinimizeEnabled = true,
                                       IsMaximized = false,
                                       ShowStartingPricesIfAvailable = ShowStartingPricesIfAvailable,
                                       ControlOrdering = x+1,
                                       Dock = DockStyle.Top,
                                       Controller = Controller,
                                       Name = x.ToString()
                                   };

                    panelThreadControls.Controls.Add(ctrl);
                    ctrl.BringToFront();
                }

                foreach (MarketView marketView in panelThreadControls.Controls)
                {
                    marketView.Visible = false;
                }

                panelThreadControls.Dock = DockStyle.Fill;
                panelThreadControls.Height = 0;

                ShowPageItems();

                ResumeLayout(true);
            }
        }

        #endregion

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

                foreach (MarketView item in panelThreadControls.Controls)
                    item.Controller = value;

                eventController.DataProcessorMarketThreadStatusChanged -=
                    eventController_DataProcessorMarketThreadStatusChanged;
                eventController.MarketDataUpdate -= eventController_MarketDataUpdate;

                eventController = value;

                eventController.DataProcessorMarketThreadStatusChanged +=
                    eventController_DataProcessorMarketThreadStatusChanged;
                eventController.MarketDataUpdate += eventController_MarketDataUpdate;
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

        #region Initialize

        /// <summary>
        /// 
        /// </summary>
        public MarketViewContainer()
        {
            InitializeComponent();

            /*** Set default values ***/
            panelThreadControls.Controls.Clear();
            ItemsPerPage = 20;
        }

        #endregion

        #region AddMarket

        /// <summary>
        /// Adds the market.
        /// </summary>
        /// <param name="threadProcessorId">The thread processor id.</param>
        /// <param name="market">The market.</param>
        public void AddMarket(string threadProcessorId, Market market)
        {
            if (threadProcessorId == null || market == null || threadProcessorId == "" || MarketViewStateItemListContains(threadProcessorId))
                return;

            /*** Make the new item indicator visible so that user know the ordering might have changed ***/
            panelLoadingNewMarketItem.Visible = true;

            /*** Create the MarketViewItem instance and add it to the list ***/
            var item = new MarketViewStateItem
                           {
                               Name = market.partialFullName,
                               EventDate = market.eventDate,
                               ThreadProcessorId = threadProcessorId,
                               ControlOrdering = -1,
                               IsMaximized = false
                           };

            //var item = new MarketViewStateItem {ThreadProcessorId = id, order = (-1), market = market};

            MarketViewStateItemList.Add(item);

            /*** A new item has been added so we need to amend the page count and refresh the display ***/
            UpdatePageCount();

            ShowPageItems();
        }

        #endregion

        #region RemoveMarket

        /// <summary>
        /// Remove a MarketViewItem form the MarketView control
        /// </summary>
        /// <param name="threadProcessorId">The thread processor id.</param>
        /// <returns></returns>
        public bool RemoveMarket(string threadProcessorId)
        {
            if (String.IsNullOrEmpty(threadProcessorId)) return false;

            var index = MarketViewStateItemListGetIndex(threadProcessorId);
            if (index < 0) return false;

            MarketViewStateItemList.RemoveAt(index);
            UpdatePageCount();
            ShowPageItems();

            return true;
        }

        #endregion

        #region ClearMarkets

        /// <summary>
        /// Clear all controls
        /// </summary>
        public void ClearMarkets()
        {
            SuspendLayout();

            MarketViewStateItemList.Clear();

            UpdatePageCount();
            ShowPageItems();

            ResumeLayout(true);
        }

        #endregion

        #region OrderMarketData

        /// <summary>
        /// Order the market thraeds by event date
        /// </summary>
        public void OrderMarketData()
        {
            OrderMarketData(sortOrder);
        }

        /// <summary>
        /// Order the market thraeds by event date
        /// </summary>
        public void OrderMarketData(MarketViewSortOrder sort)
        {
            if (panelLoadingNewMarketItem.Visible)
            {
                panelLoadingNewMarketItem.Visible = false;
            }

            switch (sortOrder)
            {
                case MarketViewSortOrder.DATE_FIRST_TO_LAST:
                    MarketViewStateItemList.Sort(new MarketViewItemDateComparer());
                    break;
                case MarketViewSortOrder.DATE_LAST_TO_FIRST:
                    MarketViewStateItemList.Sort(new MarketViewItemDateComparerReverse());
                    break;
                case MarketViewSortOrder.MARKET_NAME_A_TO_Z:
                    MarketViewStateItemList.Sort(new MarketViewItemNameComparer());
                    break;
                case MarketViewSortOrder.MARKET_NAME_Z_TO_A:
                    MarketViewStateItemList.Sort(new MarketViewItemNameComparerReverse());
                    break;
            }

            sortOrder = sort;
            ShowPageItems();
        }

        #endregion

        #region ShowPageItems

        /// <summary>
        /// Update and re-order the items displayed
        /// </summary>
        private void ShowPageItems()
        {
            SuspendLayout();

            /*** Update the page label ***/
            if (lblShowingPageXofY.Text != (String.Format("Page {0} of {1}", CurrentPage, TotalPages)))
            {
                lblShowingPageXofY.Text = String.Format("Page {0} of {1}", CurrentPage, TotalPages);
            }

            /*** Nothing to show cleanup, get out ***/
            if (MarketViewStateItemList.Count == 0)
            {
                foreach (MarketView control in panelThreadControls.Controls)
                {
                    if (control.Visible) control.Visible = false;
                    if(!String.IsNullOrEmpty(control.ThreadProcessorId)) control.ResetControl();
                }

                ResumeLayout();
                return;
            }

            // Example: 2*20 = 40  -1 = 39;
            var showItemTo = (CurrentPage*ItemsPerPage) - 1;
            // Example: 2*20 = 40 -20 = 20; So: 39 - 20 = 19 which is 20 on a zero rated index;
            var showItemFrom = (CurrentPage * ItemsPerPage) - ItemsPerPage;

            /*** Make sure we are not exceding the bounds of the array ***/
            if (showItemTo > (MarketViewStateItemList.Count - 1))
            {
                showItemTo = (MarketViewStateItemList.Count - 1);
            }
            if (showItemTo == -1) showItemTo = 0;

            /*** Hide extra controls ***/
            for (var x = 0; x < panelThreadControls.Controls.Count; x++)
            {
                var ctrl = (MarketView)panelThreadControls.Controls[x.ToString()];

                var indexNo = MarketViewStateItemListGetIndex(ctrl.ThreadProcessorId);

                if (indexNo >= 0)
                {
                    //MarketViewStateItemList[indexNo].ThreadProcessorStatus = ctrl.ThreadStatus;
                    MarketViewStateItemList[indexNo].IsMaximized = ctrl.IsMaximized;
                    //MarketViewStateItemList[indexNo].MarketData = ctrl.MarketData;
                    //MarketViewStateItemList[indexNo].ThreadProcessorId = ctrl.ThreadProcessorId;
                }

                if (x <= (showItemTo - showItemFrom)) continue;

                ctrl.ResetControl();
                ctrl.Visible = false;
            }

            /*** Display the controls ***/
            for (var x = showItemFrom; x <= showItemTo; x++)
            {
                var ctrl = (MarketView)panelThreadControls.Controls[(x - showItemFrom).ToString()];

                if (ctrl.ThreadProcessorId == MarketViewStateItemList[x].ThreadProcessorId)
                {
                    if (!ctrl.Visible)
                    {
                        ctrl.Visible = true;
                        ctrl.AutoUpdateControl();
                        //ctrl.UpdateControl(MarketViewStateItemList[x].MarketData);
                    }
                    continue;
                }

                /*** Show the new market ***/
                if (!ctrl.Visible) ctrl.Visible = true;
                ctrl.ControlOrdering = (x + 1);
                ctrl.IsMaximized = MarketViewStateItemList[x].IsMaximized;
                //ctrl.ShowMenuPathInDisplayName = ShowMenuPathInDisplayName;
                //ctrl.ShowStartingPricesIfAvailable = ShowStartingPricesIfAvailable;
                //ctrl.MarketData = MarketViewStateItemList[x].MarketData;
                //ctrl.ThreadStatus = MarketViewStateItemList[x].ThreadProcessorStatus;
                ctrl.ThreadProcessorId = MarketViewStateItemList[x].ThreadProcessorId;
                if (ctrl.Controller != Controller) ctrl.Controller = Controller;
                ctrl.AutoUpdateControl();
            }

            ResumeLayout(true);
        }

        #endregion

        #region UpdatePageCount

        /// <summary>
        /// Calculate the total number of pages
        /// </summary>
        private void UpdatePageCount()
        {
            if (MarketViewStateItemList.Count <= ItemsPerPage)
            {
                TotalPages = 1;
                CurrentPage = 1;
            }
            else
            {
                var pages = MarketViewStateItemList.Count/Convert.ToDecimal(ItemsPerPage);

                if (pages.ToString().Contains("."))
                {
                    var rounded = Math.Round(pages, 0);

                    if (rounded < pages)
                    {
                        rounded++;
                    }
                    TotalPages = Convert.ToInt32(rounded);
                }
                else
                {
                    TotalPages = Convert.ToInt32(pages);
                }
            }

            if (CurrentPage > TotalPages)
                CurrentPage = 1;
        }

        #endregion

        #region MarketViewStateItemListContains

        public bool MarketViewStateItemListContains(string threadProcessorId)
        {
            foreach (MarketViewStateItem item in MarketViewStateItemList)
            {
                if (item.ThreadProcessorId == threadProcessorId) return true;
            }

            return false;
        }

        #endregion

        #region MarketViewStateItemListGetIndex

        public int MarketViewStateItemListGetIndex(string threadProcessorId)
        {
            var count = 0;
            foreach (var item in MarketViewStateItemList)
            {
                if (item.ThreadProcessorId == threadProcessorId)
                {
                    return count;
                }
                count++;
            }

            return -1;
        }

        #endregion

        #region Page Nav Buttons Click, Mouse Enter and Leave

        /*** btnFirstPage ***/

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            if (panelLoadingNewMarketItem.Visible)
            {
                panelLoadingNewMarketItem.Visible = false;
            }
            if (CurrentPage > 1)
            {
                CurrentPage = 1;
                ShowPageItems();
            }
            btnFirstPage_MouseLeave(sender, e);
            btnFirstPage_MouseEnter(sender, e);
        }

        private void btnFirstPage_MouseEnter(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                btnFirstPage.BackgroundImage = Resources.ArrowFirst_Over;
            }
        }

        private void btnFirstPage_MouseLeave(object sender, EventArgs e)
        {
            btnFirstPage.BackgroundImage = Resources.ArrowFirst;
        }

        /*** btnPrevPage ***/

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (panelLoadingNewMarketItem.Visible)
            {
                panelLoadingNewMarketItem.Visible = false;
            }
            if (CurrentPage > 1)
            {
                CurrentPage--;
                ShowPageItems();
            }
            btnPrevPage_MouseLeave(sender, e);
            btnPrevPage_MouseEnter(sender, e);
        }

        private void btnPrevPage_MouseEnter(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                btnPrevPage.BackgroundImage = Resources.ArrowLeft_Over;
            }
        }

        private void btnPrevPage_MouseLeave(object sender, EventArgs e)
        {
            btnPrevPage.BackgroundImage = Resources.ArrowLeft;
        }

        /*** btnNextPage ***/

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (panelLoadingNewMarketItem.Visible)
            {
                panelLoadingNewMarketItem.Visible = false;
            }
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
                ShowPageItems();
            }
            btnNextPage_MouseLeave(sender, e);
            btnNextPage_MouseEnter(sender, e);
        }

        private void btnNextPage_MouseEnter(object sender, EventArgs e)
        {
            if (CurrentPage < TotalPages)
            {
                btnNextPage.BackgroundImage = Resources.ArrowRight_Over;
            }
        }

        private void btnNextPage_MouseLeave(object sender, EventArgs e)
        {
            btnNextPage.BackgroundImage = Resources.ArrowRight;
        }

        /*** btnLastPage ***/

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            if (panelLoadingNewMarketItem.Visible)
            {
                panelLoadingNewMarketItem.Visible = false;
            }
            if (CurrentPage < TotalPages)
            {
                CurrentPage = TotalPages;
                ShowPageItems();
            }
            btnLastPage_MouseLeave(sender, e);
            btnLastPage_MouseEnter(sender, e);
        }

        private void btnLastPage_MouseEnter(object sender, EventArgs e)
        {
            if (CurrentPage < TotalPages)
            {
                btnLastPage.BackgroundImage = Resources.ArrowLast_Over;
            }
        }

        private void btnLastPage_MouseLeave(object sender, EventArgs e)
        {
            btnLastPage.BackgroundImage = Resources.ArrowLast;
        }

        #endregion

        #region Other Controls

        /// <summary>
        /// Handles the Click event of the lblEventDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lblEventDate_Click(object sender, EventArgs e)
        {
            switch (sortOrder)
            {
                case MarketViewSortOrder.DATE_FIRST_TO_LAST:
                    OrderMarketData(MarketViewSortOrder.DATE_LAST_TO_FIRST);
                    break;
                default:
                    OrderMarketData(MarketViewSortOrder.DATE_FIRST_TO_LAST);
                    break;
            }
        }

        /// <summary>
        /// Handles the Click event of the lblMarketName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lblMarketName_Click(object sender, EventArgs e)
        {
            switch (sortOrder)
            {
                case MarketViewSortOrder.MARKET_NAME_A_TO_Z:
                    OrderMarketData(MarketViewSortOrder.MARKET_NAME_Z_TO_A);
                    break;
                default:
                    OrderMarketData(MarketViewSortOrder.MARKET_NAME_A_TO_Z);
                    break;
            }
        }

        /// <summary>
        /// Handles the SelectedValueChanged event of the listItemsPerPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void listItemsPerPage_SelectedValueChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (Convert.ToInt32(listItemsPerPage.SelectedItem) != ItemsPerPage)
            {
                ItemsPerPage = Convert.ToInt32(listItemsPerPage.SelectedItem);
                UpdatePageCount();
                ShowPageItems();
            }

            Cursor = Cursors.Arrow;
        }

        #endregion

        #region Events

        /// <summary>
        /// Handles the MarketDataUpdate event of the eventController control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void eventController_MarketDataUpdate(object sender, MarketDataUpdateEventArgs e)
        {
            if (InvokeRequired)
            {
                if (e != null)
                {
                    eventController_MarketDataUpdateCallback d = eventController_MarketDataUpdate;
                    BeginInvoke(d, new[] { sender, e });
                }
            }

            if (e == null) return;
            if (e.MarketData == null) return;

            var index = MarketViewStateItemListGetIndex(e.SenderID);

            if (index >= 0)
            {
                //MarketViewStateItemList[index].MarketData = e.MarketData;
            }
            else
            {
                AddMarket(e.SenderID, e.MarketData);
            }
        }

        private delegate void eventController_MarketDataUpdateCallback(object sender, MarketDataUpdateEventArgs e);

        /// <summary>
        /// Handles the DataProcessorMarketThreadStatusChanged event of the eventController control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void eventController_DataProcessorMarketThreadStatusChanged(object sender, DataProcessorMarketThreadStatusChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                MarketThreadStatusChangedEventDelegate d = eventController_DataProcessorMarketThreadStatusChanged;
                BeginInvoke(d, new[] { sender, e });
            }

            if (e == null) return;

            var index = MarketViewStateItemListGetIndex(e.SenderID);

            if (index < 0) return;

            if (e.Status == "CLOSED") RemoveMarket(e.SenderID);
            //else
            //    MarketViewStateItemList[index].ThreadProcessorStatus = e.Status;
        }

        private delegate void MarketThreadStatusChangedEventDelegate(object sender, DataProcessorMarketThreadStatusChangedEventArgs e);

        #endregion

        #region MarketView.Control.Collections

        public enum MarketViewSortOrder
        {
            DATE_FIRST_TO_LAST,
            DATE_LAST_TO_FIRST,
            MARKET_NAME_A_TO_Z,
            MARKET_NAME_Z_TO_A
        }

        #region Nested type: MarketViewItemDateComparer

        /// <summary>
        /// Order the MarketViewItem by MarketViewItem.eventDate
        /// </summary>
        private class MarketViewItemDateComparer : IComparer<MarketViewStateItem>
        {
            #region IComparer<MarketViewStateItem> Members

            public int Compare(MarketViewStateItem x, MarketViewStateItem y)
            {
                return
                    (x.EventDate.ToUniversalTime().CompareTo(
                        y.EventDate.ToUniversalTime()));
            }

            #endregion
        }

        #endregion

        #region Nested type: MarketViewItemDateComparerReverse

        /// <summary>
        /// Reverse order the MarketViewItem by MarketViewItem.eventDate
        /// </summary>
        private class MarketViewItemDateComparerReverse : IComparer<MarketViewStateItem>
        {
            #region IComparer<MarketViewStateItem> Members

            public int Compare(MarketViewStateItem x, MarketViewStateItem y)
            {
                return
                    (x.EventDate.ToUniversalTime().CompareTo(
                        y.EventDate.ToUniversalTime()))*(-1);
            }

            #endregion
        }

        #endregion

        #region Nested type: MarketViewItemNameComparerReverse

        /// <summary>
        /// Reverse order the MarketViewItem by MarketViewItem.name
        /// </summary>
        private class MarketViewItemNameComparerReverse : IComparer<MarketViewStateItem>
        {
            #region IComparer<MarketViewStateItem> Members

            public int Compare(MarketViewStateItem x, MarketViewStateItem y)
            {
                return
                    (x.Name.CompareTo(
                        y.Name)) * (-1);
            }

            #endregion
        }

        #endregion

        #region Nested type: MarketViewItemNameComparer

        /// <summary>
        /// Reverse order the MarketViewItem by MarketViewItem.name
        /// </summary>
        private class MarketViewItemNameComparer : IComparer<MarketViewStateItem>
        {
            #region IComparer<MarketViewStateItem> Members

            public int Compare(MarketViewStateItem x, MarketViewStateItem y)
            {
                return
                    (x.Name.CompareTo(
                        y.Name));
            }

            #endregion
        }

        #endregion

        #region Nested type: MarketViewStateItem

        public class MarketViewStateItem
        {
            /// <summary>
            /// Gets or sets the control number. This is the count in the top left of the control
            /// </summary>
            /// <value>The control number.</value>
            public int ControlOrdering;

            /// <summary>
            /// Is the this item expanded
            /// </summary>
            public bool IsMaximized;

            //public Market MarketData;

            public DateTime EventDate;

            public string Name;

            /// <summary>
            /// Gets or sets the market thread processor id this instance is linked to.
            /// </summary>
            /// <value>The thread processor id.</value>
            public string ThreadProcessorId;

            /// <summary>
            /// The last known status of this item
            /// </summary>
            //public string ThreadProcessorStatus;
        }

        #endregion

        #endregion
    }
}