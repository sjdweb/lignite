using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Lignite.Controls
{
    public partial class SystemStatusMonitor : UserControl, IUserControl
    {
        private string feedUrl;
        private string m_uniqueInstanceID;
        private XmlNode nodeChannel;
        private XmlNode nodeItem;
        private XmlNode nodeRss;
        private XmlDocument rssDoc;
        private XmlTextReader rssReader;

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

        public SystemStatusMonitor()
        {
            InitializeComponent();
            RefreshTimer.Enabled = true;
        }


        public string FeedUrl
        {
            get { return feedUrl; }
            set
            {
                txtFeedUrl.Text = value;
                feedUrl = value;
            }
        }

        public int RefreshTimerInterval
        {
            get { return RefreshTimer.Interval; }
            set { RefreshTimer.Interval = value; }
        }

        public void Start()
        {
            RefreshTimer.Start();
        }

        public void Stop()
        {
            RefreshTimer.Stop();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshFeed();
        }

        private void btnLoadFeedUrl_Click(object sender, EventArgs e)
        {
            feedUrl = txtFeedUrl.Text;
            RefreshFeed();
        }

        public void RefreshFeed()
        {
            try
            {
                if (txtFeedUrl.BackColor == Color.Red)
                {
                    txtFeedUrl.BackColor = Color.White;
                }


                lblFeedChannelTitle.Text = "";
                txtItemLastBuildDateresponse.Text = "";
                txtItemTitleResponse.Text = "";
                txtItemDescriptionResponse.Text = "";
                txtItemCategoryResponse.Text = "";
                txtItemPublishDateResponse.Text = "";

                /*** Create a new XmlTextReader from the specified URL (RSS feed) ***/
                rssReader = new XmlTextReader(feedUrl);
                rssDoc = new XmlDocument();

                /*** Load the XML content into a XmlDocument ***/
                rssDoc.Load(rssReader);

                /*** Loop for the <rss> tag ***/
                for (int i = 0; i < rssDoc.ChildNodes.Count; i++)
                {
                    // If it is the rss tag
                    if (rssDoc.ChildNodes[i].Name == "rss")
                    {
                        // <rss> tag found
                        nodeRss = rssDoc.ChildNodes[i];
                        break;
                    }
                }

                /*** Loop for the <channel> tag ***/
                for (int i = 0; i < nodeRss.ChildNodes.Count; i++)
                {
                    // If it is the channel tag

                    if (nodeRss.ChildNodes[i].Name == "channel")
                    {
                        // <channel> tag found
                        nodeChannel = nodeRss.ChildNodes[i];
                        break;
                    }
                }

                lblFeedChannelTitle.Text = nodeChannel["title"].InnerText;
                txtItemLastBuildDateresponse.Text = nodeChannel["lastBuildDate"].InnerText;

                /*** Loop for the <title>, <link>, <description> and all the other tags ***/
                for (int i = 0; i < nodeChannel.ChildNodes.Count; i++)
                {
                    /*** If it is the item tag, then it has children tags which we will add as items to the ListView ***/
                    if (nodeChannel.ChildNodes[i].Name == "item")
                    {
                        nodeItem = nodeChannel.ChildNodes[i];

                        txtItemTitleResponse.Text = nodeItem["title"].InnerText;
                        txtItemDescriptionResponse.Text = nodeItem["description"].InnerText;
                        txtItemCategoryResponse.Text = nodeItem["category"].InnerText;
                        txtItemPublishDateResponse.Text = nodeItem["pubDate"].InnerText;
                        txtItemCategoryResponse_TextChanged(this, new EventArgs());
                    }
                }
            }
            catch (Exception e)
            {
                txtFeedUrl.BackColor = Color.Red;

                lblFeedChannelTitle.Text = "Error Loading Url";
                txtItemLastBuildDateresponse.Text = "";
                txtItemTitleResponse.Text = "";
                txtItemDescriptionResponse.Text = e.Message;
                txtItemCategoryResponse.Text = "";
                txtItemPublishDateResponse.Text = "";
            }
        }

        private void lblFeedChannelTitle_Click(object sender, EventArgs e)
        {
            if (feedUrl != null)
            {
                Process.Start(feedUrl);
            }
        }

        private void txtItemCategoryResponse_TextChanged(object sender, EventArgs e)
        {
            if (txtItemCategoryResponse.Text.ToLower() == "available" ||
                txtItemCategoryResponse.Text.ToLower() == "resolved")
            {
                if (txtItemCategoryResponse.BackColor != Color.FromArgb(((((176)))), ((((227)))), ((((0))))))
                {
                    txtItemCategoryResponse.BackColor = Color.FromArgb(((((176)))), ((((227)))), ((((0)))));
                }
            }
            else if (txtItemCategoryResponse.Text.ToLower() == "unavailable")
            {
                if (txtItemCategoryResponse.BackColor != Color.Red)
                {
                    txtItemCategoryResponse.BackColor = Color.Red;
                }
            }
            else if (txtItemCategoryResponse.Text.ToLower() == "degraded")
            {
                if (txtItemCategoryResponse.BackColor != Color.NavajoWhite)
                {
                    txtItemCategoryResponse.BackColor = Color.NavajoWhite;
                }
            }
            else if (txtItemCategoryResponse.BackColor != Color.Gainsboro)
            {
                txtItemCategoryResponse.BackColor = Color.Gainsboro;
            }
        }
    }
}