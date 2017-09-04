/* COPYRIGHT (C) 2017 Ori Arad. All Rights Reserved. */
/* See LICENSE.txt for more details                  */

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;
using System.ServiceModel.Syndication;

namespace SimpleCSE
{
    public class SimpleRss
    {
        /**
         * The RSS channel's source
         */
        private string source = "";
        /**
         * The RSS channel's URL address
         */
        private string url = null;
        /**
         * An array of all the RSS channel's items
         */
        private List<RssItem> items = null;
        /**
         * The RSS channel's title
         */
        private string title = "";
        /**
         * The RSS channel's description
         */
        private string description = "";
        /**
         * The RSS channel's link
         */
        private string link = "";
        /**
         * The RSS channel's language code
         */
        private string language = "";
        /**
         * The RSS channel's copyright
         */
        private string copyright = "";
        /**
         * The RSS channel's publication date
         */
        private string pubDate = "";
        /**
         * The RSS channel's image-link
         */
        private string imageLink = "";
        /**
         * 
         */
        XmlReader xmlReader = null;

        /**
         * Constructor - Will open the given RSS link
         * @param rssLocation The location (URL) of RSS file
         * @throws ParserConfigurationException 
         */
        public SimpleRss(string rssLocation) : this()
        {
            LoadUrl(rssLocation);
        }

        /**
         * Constructor - creates an empty RSS object
         * @throws ParserConfigurationException 
         */
        public SimpleRss()
        {
            this.items = new List<RssItem>();
        }

        /**
         * Load a RSS file from URL address
         * @param rssLocation The location (URL) of RSS file
         * @return "true" if URL loading succeed, and "false" otherwise
         */
        public bool LoadUrl(string rssLocation)
        {
            this.url = rssLocation;
            string result = null;
            using (WebClient client = new WebClient())
            {
                result = client.DownloadString(url);
            }
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            this.xmlReader = XmlReader.Create(this.url, settings);
            ParseXml();
            return (result != null);
        }

        /**
         * Loads a file with RSS data
         * @param filename  The file-name and path of the RSS file
         * @return "true" if RSS file loading succeed, and "false" otherwise
         */
        public bool LoadFile(string filename)
        {
            // TBD
            Boolean result = false;
            return result;
        }

        /**
         * Loads a file with RSS data
         * @param filename  The file-name and path of the RSS file
         * @return "true" if RSS file loading succeed, and "false" otherwise
         */
        public bool ParseXml()
        {
            XmlReader reader = XmlReader.Create(this.url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            this.title = feed.Title.Text;
            this.link = feed.Links[0].ToString();
            this.description = feed.Title.Text;
            this.language = feed.Language.ToString();
            this.copyright = feed.Copyright.Text;
            this.pubDate = feed.LastUpdatedTime.ToString();

            foreach (SyndicationItem item in feed.Items)
            {
                RssItem rssItem = new RssItem();
                rssItem.SetTitle(item.Title.Text);
                rssItem.SetDescription(item.Content==null?"": item.Content.ToString());
                rssItem.SetLink(item.Links.Count > 0 ? "" : item.Links[0].Uri.ToString());                
                rssItem.SetPubDate(item.PublishDate.ToString());
                rssItem.SetGuid(item.Id);
                this.items.Add(rssItem);
            }
            return true;
        }


        /**
         * Gets a RssItem object from the required index
         * @param i The item's index
         * @return A RssItem object from the required index, of null if index is out-of-range
         */
        public RssItem GetItem(int i)
        {
            Debug.Assert(this.items != null);
            if ((i < 0) || (i >= GetSize()))
            {
                Console.WriteLine("RssItem getItem: Illegal index - out-of-range.");
                return null;
            }
            return this.items[i];
        }

        /**
         * Gets an array of all RSS items
         * @return an array of all RSS items
         */
        public RssItem[] GetItems()
        {
            Debug.Assert(this.items != null);
            return this.items.ToArray();
        }

        /**
         * Gets the number of RSS items
         * @return The number of RSS items
         */
        public int GetSize()
        {
            Debug.Assert(this.items != null);
            return this.items.Count;
        }

        /**
         * Gets the RSS channel's title
         * @return The RSS channel's title
         */
        public string GetTitle()
        {
            return this.title;
        }

        /**
         * Gets the RSS channel's description
         * @return The RSS channel's description
         */
        public string GetDescription()
        {
            return this.description;
        }

        /**
         * Gets the RSS channel's link
         * @return The RSS channel's link
         */
        public string GetLink()
        {
            return this.link;
        }

        /**
         * Gets the RSS channel's language code
         * @return The RSS channel's language code
         */
        public string GetLanguage()
        {
            return this.language;
        }

        /**
         * Gets the RSS channel's copyright info
         * @return The RSS channel's copyright info
         */
        public string GetCopyright()
        {
            return this.copyright;
        }

        /**
         * Gets the RSS channel's publication date
         * @return The RSS channel's publication date
         */
        public string GetPubDate()
        {
            return this.pubDate;
        }

        /**
         * Gets the RSS channel's image-link
         * @return The RSS channel's image-link
         */
        public string GetImageLink()
        {
            return this.imageLink;
        }

        /**
         * Gets the RSS channel's source
         * @return The RSS channel's source
         */
        public string GetSource()
        {
            return this.source;
        }

        public string Tostring()
        {
            StringBuilder result = new StringBuilder();
            result.Append(GetTitle() + '\n');
            result.Append(GetDescription() + '\n');
            result.Append("Language: " + GetLanguage() + '\n');
            foreach (RssItem item in this.items)
            {
                result.Append(item.ToString());
                result.Append('\n');
            }
            return result.ToString();
        }
    }
}