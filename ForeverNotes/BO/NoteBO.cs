using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeverNotes.Domain;

namespace ForeverNotes.BO
{
    public class NoteBo
    {
        private int _noteID;

        public int NoteID
        {
            get { return _noteID; }
            set { _noteID = value; }
        }

        private string _heading;
        public string Heading
        {
            get { return _heading; }
            set {
                _heading = value;
                _dateModified = DateTime.Now;
                CurStatus = Enums.GetStatus(CurStatus, Enums.Status.Update);
            }
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set {
                _content = value;
                _dateModified = DateTime.Now;
                CurStatus = Enums.GetStatus(CurStatus, Enums.Status.Update);
            }
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

       

        private string _tagString;
        public string TagString
        {
            get { return _tagString; }
            set {
                _tagString = value;
                _dateModified = DateTime.Now;
                if(CurStatus != Enums.Status.Remove)
                    CurStatus = Enums.GetStatus(CurStatus, Enums.Status.Update);
            }
        }



        
        public Enums.Status CurStatus = 0;

        public NoteBo(Note note)
        {
            _noteID = note.NoteID;
            _heading = note.Heading;
            _content = note.Content;
            if(note.DateCreated == DateTime.MinValue)
            {
                _dateCreated = DateTime.Now;
                _dateModified = DateTime.Now;
                _heading = "New Note";
                CurStatus = Enums.Status.Create;
            }
            else
            {
                _dateCreated = note.DateCreated;
                _dateModified = note.DateModified;
                CurStatus = Enums.Status.Synced;
            }
            //GenerateTagString();
            _tagsList = new List<Tag>();
        }

        
        public void GenerateTagString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Tag itemTag in _tagsList)
            {
                builder.Append(itemTag.Name + ", ");
            }
            _tagString = builder.ToString();
        }

        public string GenerateTagObjects(List<Tag> _allTags)
        {
            string[] curTags = _tagString.Split(',').ToArray();

            for(int i = 0; i < curTags.Length; i++)
            {
                curTags[i] = curTags[i].Trim();
            }

            //check if a tag with the same name already excists
            _tagsList.Clear();
            foreach (string tagString in curTags)
            {
                if (tagString.Equals(""))
                    continue;
                
                Tag exTag = null;
                foreach (Tag eTag in _allTags)
                {
                    if (eTag.Name.Equals(tagString))
                    {
                        exTag = eTag;
                        break;
                    }
                }

                if(exTag == null)
                {
                    //create new tag
                    Tag newTag = new Tag()
                    {
                        Name = tagString,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    };
                    _allTags.Add(newTag);
                    _tagsList.Add(newTag);
                }
                else
                {
                    //tag excists
                    _tagsList.Add(exTag);
                }
            }
            if (_tagsList.Count == 0)
                return "";
            else
                return "Generated " + _tagsList.Count + " tags for Note \"" + _heading + "\"";
        }

    }
}
