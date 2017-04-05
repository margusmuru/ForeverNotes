using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Xml;
using System.Xml.Linq;
using ForeverNotes.BO;
using ForeverNotes.Domain;
using ForeverNotes.Service;
using ForeverNotes;
using System.Text.RegularExpressions;
using System.Web;
using System.Globalization;

namespace ForeverNotesWPF.ViewModels
{
    public class RSSTabVM : MainVM
    {

        public string imgpath;

        //collection to hold FeedBo objects
        private ObservableCollection<FeedBo> _feeds;
        public ObservableCollection<FeedBo> Feeds
        {
            get { return _feeds; }
            set { _feeds = value; }
        }

        //collection to hold NewsBo objects
        private ObservableCollection<NewsBo> _selectedNews;
        public ObservableCollection<NewsBo> SelectedNews
        {
            get { return _selectedNews; }
            set { _selectedNews = value; }
        }

        private List<FeedBo> _feedTrash;

        //Constructor
        public RSSTabVM()
        {
            _feeds = new ObservableCollection<FeedBo>();
            _selectedNews = new ObservableCollection<NewsBo>();
            _feedTrash = new List<FeedBo>();

            GetAllFeeds();
        }

        //check if url is valid rss feed
        public bool TryParseFeed(string url)
        {
            try
            {
                SyndicationFeed feed = SyndicationFeed.Load(XmlReader.Create(url));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //gets all feeds
        private void GetAllFeeds()
        {
            List<FeedBo> feeds = RssService.GetAllFeeds();
            foreach (FeedBo feedBo in feeds)
            {
                _feeds.Add(feedBo);
            }
            LoadFeed(0);
        }
        //syncs with database, either adds feed or removes from database
        public void Sync()
        {
            foreach (FeedBo feedBo in _feeds)
            {
                if(feedBo.CurStatus == Enums.Status.Create)
                {
                    RssService.AddNewFeed(feedBo);
                    _log.Add("Added Feed \"" + feedBo.FeedName + "\" To DataBase");
                    feedBo.CurStatus = Enums.Status.Synced;
                }
            }

            foreach (FeedBo feedBo in _feedTrash)
            {
                if(feedBo.CurStatus == Enums.Status.Remove)
                {
                    RssService.RemoveFeed(feedBo);
                    _log.Add("Removed Feed \"" + feedBo.FeedName + "\" from DataBase");
                }
               
            }
            _feedTrash.Clear();
        }
        //method to add feed
        public void AddNewFeed(string url)
        {
            RssFeed feed = new RssFeed()
            {
                Url = url
            };
            FeedBo feedBo = new FeedBo(feed);
            _feeds.Add(feedBo);
            DownloadFeed(feedBo);
        }
        //loads feed
        public void LoadFeed(int index)
        {
            if(_feeds.Count > 0)
            {
                FeedBo feedBo = _feeds.ElementAt(index);
                DownloadFeed(feedBo);
                _log.Add("Feed \"" + feedBo.FeedName + "\" downloaded");
            }
            
        }
        //method to download feed
        public void DownloadFeed(FeedBo feedBo)
        {
            feedBo.FeedName = "Feed error";
            if (TryParseFeed(feedBo.FeedUrl))
            {

                XDocument xdoc = XDocument.Load(feedBo.FeedUrl);
                IEnumerable<XElement> uudised = from x in xdoc.Descendants("item") select x;

                string tmpName = "";
                tmpName = xdoc.Element("rss").Element("channel").Element("title").Value.Trim();
                if (tmpName.Equals(""))
                    tmpName = feedBo.FeedUrl;

                if (feedBo.FeedName.Equals("Feed error"))
                    feedBo.FeedName = tmpName;

                foreach (XElement item in uudised)
                {
                    //news title
                    XElement xePealkiri = item.Element("title");
                    //news url link
                    XElement xeLink = item.Element("link");
                    //news quick description, content
                    XElement xeDescription = item.Element("description");
                    //posted news time
                    XElement xepubDate = item.Element("pubDate");
                    
                    imgpath = ImageSearch(xeDescription.Value);

                    if (item.Element("enclosure") != null)
                    {
                        if (item.Element("enclosure").Attribute("url") != null)
                        {
                            //Checks if image is in enclosure tag
                            XAttribute enclosure_url = item.Element("enclosure").Attribute("url");
                            //Console.WriteLine(enclosure_url.Value);
                            imgpath = enclosure_url.Value;
                        }
                    }
                    string content;
                    //deleting image link from content
                    content = DeleteImageLink(xeDescription.Value);
                    content = Regex.Replace(content, "<.+?>", string.Empty);
                    //decoding html
                    content = HttpUtility.HtmlDecode(content).ToString();
                    //deleting excessive spaces from content
                    content = content.Trim();
                    char tabs = '\u0009';
                    content = content.Replace(tabs.ToString(), "");

                    //parsing datetime and setting it to custom format
                    string parseFormat = "ddd, dd MMM yyyy HH:mm:ss zzz";
                    string date = String.Format("{0:dddd, MMMM d, yyyy HH:mm:ss}", DateTime.ParseExact(xepubDate.Value, parseFormat, CultureInfo.InvariantCulture));
                    if (xePealkiri != null)
                    {
                        NewsBo newsBo = new NewsBo()
                        {
                            Heading = xePealkiri.Value,
                            Content = content,
                            PubDate = "Posted: " + date,
                            ImageUrl = imgpath,
                            Link = xeLink.Value
                        };
                        feedBo.News.Add(newsBo);
                    }

                }

            }


        }
        //removes feed
        public void RemoveFeed(int index)
        {         
            try
            {
                FeedBo feed = _feeds.ElementAt(index);
                _feeds.Remove(feed);
                _feedTrash.Add(feed);
                feed.CurStatus = Enums.Status.Remove;

                if (_feeds.Count > 0)
                    SetCurrentFeed(0);
                else
                    _selectedNews.Clear();
            }
            catch (Exception e)
            {
                _log.Add("Error deleting feed");
            }
        }
        //looks description for img source files, returns first
        string ImageSearch(string content)
        {
            // search for <img> tags 
            Regex searchimg = new Regex("<img.*?>");

            //Console.WriteLine("item");
            string firstresult = "";
            foreach (Match m in searchimg.Matches(content))
            {
                // extract the src attribute 
                Regex searchsrc = new Regex("(?<=src=\").*?(?=\")");
                string result = searchsrc.Match(m.ToString()).ToString();
                if (firstresult == "")
                    firstresult = result;
             //Console.WriteLine(result);
            }

            return firstresult;
        }


        //sets current feed
        public void SetCurrentFeed(int index)
        {

            _selectedNews.Clear();

            FeedBo selectedFeed = _feeds.ElementAt(index);

            selectedFeed.News.Clear();
            DownloadFeed(selectedFeed);

            if(selectedFeed != null)
            {
                Console.WriteLine("News Count in item: " + selectedFeed.News.Count);
                foreach (NewsBo news in selectedFeed.News)
                {
                    _selectedNews.Add(news);
                }
                Console.WriteLine("Added " + _selectedNews.Count + " news to list");
            }
        }

        //searches image link from content
        public string FindImageUrl(string content)
        {
            return Regex.Match(content, "<img.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;
        }
        //deletes image link from content
        public string DeleteImageLink(string content)
        {
            return Regex.Replace(content, "<img.+?src=[\"'](.+?)[\"'].*?>", String.Empty); ;
        }

    }
}
