using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeverNotes.Domain;

namespace ForeverNotes.BO
{
    class Note
    {
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

        private DateTime _dateCreated;

        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set { _dateCreated = value; }
        }

        private DateTime _dateModified;     

        public DateTime DateModified    
        {
            get { return _dateModified; }
            set { _dateModified = value; }
        }

        private List<Tag> _tagsList;

        public List<Tag> TagsList
        {
            get { return _tagsList; }
            set { _tagsList = value; }
        }

        private List<NoteGroup> _noteGroups;

        public List<NoteGroup> NoteGroups
        {
            get { return _noteGroups; }
            set { _noteGroups = value; }
        }


    }
}
