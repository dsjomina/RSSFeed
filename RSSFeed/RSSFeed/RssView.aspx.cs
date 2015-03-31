using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Xml;

namespace RSSFeed
{
    public partial class RssView : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindRssRepeater();
        }

        private void BindRssRepeater()
        {
            const string rssFeedUrl = "https://www.readability.com/rseero/latest/feed";

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(rssFeedUrl);

                if (xmlDocument.DocumentElement != null)
                {
                    List<Feed> feedList = new List<Feed>();
                    XmlNodeList nodeList = xmlDocument.DocumentElement.SelectNodes("/rss/channel/item");

                    if (nodeList != null)
                    {
                        foreach (XmlNode xmlNode in nodeList)
                        {
                            Feed feed = new Feed();
                            feed.Title = xmlNode.SelectSingleNode("title") == null ? string.Empty : xmlNode.SelectSingleNode("title").InnerText;
                            feed.Link = xmlNode.SelectSingleNode("link") == null ? string.Empty : xmlNode.SelectSingleNode("link").InnerText;
                            feed.PublishDate = xmlNode.SelectSingleNode("pubDate") == null ? string.Empty : xmlNode.SelectSingleNode("pubDate").InnerText.Substring(0, xmlNode.SelectSingleNode("pubDate").InnerText.Length - 5);
                            feed.Description = xmlNode.SelectSingleNode("description") == null ? string.Empty : xmlNode.SelectSingleNode("description").InnerText;
                            feedList.Add(feed);
                        }
                    }
                    else
                    {
                        errorLabel.Text = "Failed to load RSS feed";
                    }

                    rssRepeater.DataSource = feedList;
                    rssRepeater.DataBind();
                }
                else
                {
                    errorLabel.Text = "Failed to load RSS feed";
                }
            }
            catch (Exception ex)
            {
                errorLabel.Text = String.Format("Failed to populate RSS feed, exception: {0}", ex.Message);
            }
        }
    }
}