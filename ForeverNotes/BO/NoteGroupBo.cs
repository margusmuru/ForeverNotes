using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeverNotes.Domain;

namespace ForeverNotes.BO
{
    public class NoteGroupBo
    {

        private int _groupID;
        public int GroupID
        {
            get { return _groupID; }
            set { _groupID = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                _dateModified = DateTime.Now;
                CurStatus = Enums.GetStatus(CurStatus, Enums.Status.Update);

            }
        }


        private System.DateTime _dateCreated;
        public System.DateTime DateCreated
        {
            get { return _dateCreated; }
        }


        private System.DateTime _dateModified;
        public System.DateTime DateModified
        {
            get { return _dateModified; }
        }


        public List<NoteBo> notes;

        public Enums.Status CurStatus = 0;

        public NoteGroupBo(NoteGroup _group)
        {
            this._groupID = _group.NoteGroupID;

            this._name = _group.Name;
            if (_group.DateCreated == DateTime.MinValue)
            {
                this._dateCreated = DateTime.Now;
                this._dateModified = DateTime.Now;
                CurStatus = Enums.Status.Create;
            }
            else
            {
                this._dateCreated = _group.DateCreated;
                this._dateModified = _group.DateModified;
                CurStatus = Enums.Status.Synced;
            }

            notes = new List<NoteBo>();
        }

        public NoteGroupBo(string _name)
        {
            this._name = _name;
            this._dateCreated = DateTime.Now;
            this._dateModified = DateTime.Now;

            CurStatus = Enums.Status.Create;

            notes = new List<NoteBo>();
        }
    }
}
