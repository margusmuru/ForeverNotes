using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeverNotes.Domain;
using ForeverNotes.Service;
using ForeverNotes.BO;

namespace ForeverNotes.Service
{
    public static class RssService
    {


        public static List<FeedBo> GetAllFeeds()
        {
            List<RssFeed> rssFeeds = new List<RssFeed>();
            List<FeedBo> feedBos = new List<FeedBo>();

            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                 rssFeeds = db.RssFeed.ToList();
            }

            foreach (RssFeed rssFeed in rssFeeds)
            {
                FeedBo feedBo = new FeedBo(rssFeed);
                feedBos.Add(feedBo);
            }
            return feedBos;
        }

        //adds new feed to the database
        public static void AddNewFeed(FeedBo feedBo)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                RssFeed rssFeed = new RssFeed()
                {
                    Name = feedBo.FeedName,
                    Url = feedBo.FeedUrl,
                    DateCreated = feedBo.DateCreated
                };
                db.RssFeed.Add(rssFeed);
                feedBo.FeedID = rssFeed.FeedID;
                db.SaveChanges();
            }

        }

        //removes feed from the database
        public static void RemoveFeed(FeedBo feedBo)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                var toRemove = db.RssFeed.Where(x => x.FeedID == feedBo.FeedID).FirstOrDefault();
                if(toRemove != null)
                {
                    db.RssFeed.Remove(toRemove);
                    db.SaveChanges();
                }
            }
        }
    }
}
