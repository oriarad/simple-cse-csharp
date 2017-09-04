using System;

namespace SimpleCSE
{
    public class RssItem
    {
        /**
         * The RSS item's category
         */
        private string category = "";
        /**
         * The RSS item's title
         */
        private string title = "";
        /**
         * The RSS item's description
         */
        private string description = "";
        /**
         * The RSS item's link
         */
        private string link = "";
        /**
         * The RSS item's publication-date
         */
        private string pubDate = "";
        /**
         * The RSS item's guid
         */
        private string guid = "";

        /**
         * Constructor
         */
        public RssItem()
        {
            // empty
        }

        /**
         * Gets the category of the item
         * @return The RSS item's category
         */
        public string GetCategory()
        {
            return this.category;
        }

        /**
         * Sets the category of the item
         * @param category The required RSS item's category
         */
        public void SetCategory(string category)
        {
            if (category == null)
            {
                this.category = "";
            }
            else
            {
                this.category = category;
            }
        }

        /**
         * Gets the title of the item
         * @return The RSS item's title
         */
        public String GetTitle()
        {
            return this.title;
        }

        /**
         * Sets the title of the item
         * @param title The required RSS item's title
         */
        public void SetTitle(string title)
        {
            if (title == null)
            {
                this.title = "";
            }
            else
            {
                this.title = title;
            }
        }

        /**
         * Gets the description of the item
         * @return The RSS item's description
         */
        public string GetDescription()
        {
            return this.description;
        }

        /**
         * Sets the description of the item
         * @param description The required RSS item's description
         */
        public void SetDescription(string description)
        {
            if (description == null)
            {
                this.description = "";
            }
            else
            {
                this.description = description;
            }
        }

        /**
         * Gets the link of the item
         * @return The RSS item's link
         */
        public string GetLink()
        {
            return this.link;
        }

        /**
         * Sets the link of the item
         * @param link
         */
        public void SetLink(string link)
        {
            if (link == null)
            {
                this.link = "";
            }
            else
            {
                this.link = link;
            }
        }

        /**
         * Gets the publication-date of the item
         * @return the publication-date of the item
         */
        public string GetPubDate()
        {
            return this.pubDate;
        }

        /**
         * Sets the publish-date of the item
         * @param pubDate the publication-date of the item
         */
        public void SetPubDate(string pubDate)
        {
            if (pubDate == null)
            {
                this.pubDate = "";
            }
            else
            {
                this.pubDate = pubDate;
            }
        }

        /**
         * Gets the guid of the item
         * @return the guid of the item
         */
        public string GetGuid()
        {
            return this.guid;
        }

        /**
         * Sets the guid of the item
         * @param guid
         */
        public void SetGuid(string guid)
        {
            if (guid == null)
            {
                this.guid = "";
            }
            else
            {
                this.guid = guid;
            }
        }

        /* (non-Javadoc)
         * @see java.lang.Object#toString()
         */
        public override string ToString()
        {
            return this.pubDate + ": " + this.title + ". " + this.description;
        }

        /**
         * Open the RSS item's link in the default browser
         */
        public void OpenLink()
        {
            // TBD
        }
    }
}
