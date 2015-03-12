using System;
using System.Collections.Generic;
using System.Xml;

namespace RSSFeed
{
    public partial class RssView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindRssGridView();
        }

        private void BindRssGridView()
        {
            const string rssFeedUrl = "https://www.readability.com/rseero/latest/feed";

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(rssFeedUrl);

                if (xmlDocument.DocumentElement != null)
                {
                    List<Feed> feedList = new List<Feed>();
                    XmlNodeList node = xmlDocument.DocumentElement.SelectNodes("/rss/channel/item");

                    if (node != null)
                    {
                        foreach (XmlNode childNode in node)
                        {
                            Feed feed = new Feed();
                            feed.Title = childNode.SelectSingleNode("title") == null ? string.Empty : childNode.SelectSingleNode("title").InnerText;
                            feed.Link = childNode.SelectSingleNode("link") == null ? string.Empty : childNode.SelectSingleNode("link").InnerText;
                            feed.PublishDate = childNode.SelectSingleNode("pubDate") == null ? string.Empty : childNode.SelectSingleNode("pubDate").InnerText.Substring(0, childNode.SelectSingleNode("pubDate").InnerText.Length - 5);
                            feed.Description = childNode.SelectSingleNode("description") == null ? string.Empty : childNode.SelectSingleNode("description").InnerText;
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