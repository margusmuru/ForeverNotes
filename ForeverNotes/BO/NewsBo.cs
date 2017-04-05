using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeverNotes.BO
{
   public class NewsBo
    {
        /**
         * see klass on iga eraldiseisva uudise objetk
         */

        private string _heading;
        public string Heading
        {
            get { return _heading; }
            set { _heading = value; }
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private DateTime _pubdatetime;
        public DateTime PubDatetime
        {
            get { return _pubdatetime; }
            set { _pubdatetime = value; }
        }

        private string _pubdate;
        public string PubDate
        {
            get { return _pubdate; }
            set { _pubdate = value; }
        }

        private string _imageurl;
        public string ImageUrl
        {
            get { return _imageurl; }
            set { _imageurl = value; }
        }

        private string _link;
        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }


    }
}

