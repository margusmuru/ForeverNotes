using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeverNotes.Domain;

namespace ForeverNotes.BO
{
    public class FeedBo
    {

        private int _feedID;

        public int FeedID
        {
            get { return _feedID; }
            set { _feedID = value; }
        }


        private string _feedName;
        public string FeedName
        {
            get { return _feedName; }
            set { _feedName = value; }
        }

        private string _feedUrl;
        public string FeedUrl
        {
            get { return _feedUrl; }
            set { _feedUrl = value; }
        }

        private DateTime _dateCreated;
        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set { _dateCreated = value; }
        }

        public Enums.Status CurStatus = 0;

        public List<NewsBo> News;

        //constructor. 
        public FeedBo(RssFeed feed)
        {
            News = new List<NewsBo>();

            _feedID = feed.FeedID;
            _feedName = feed.Name;
            _feedUrl = feed.Url;

            if (feed.DateCreated == DateTime.MinValue)
            {
                CurStatus = Enums.Status.Create;
                _dateCreated = DateTime.Now;
            }
            else
            {
                CurStatus = Enums.Status.Synced;
                _dateCreated = feed.DateCreated;
            }
                
        }

    }
}
