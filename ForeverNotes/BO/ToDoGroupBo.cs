using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeverNotes.Domain;

namespace ForeverNotes.BO
{
    public class ToDoGroupBo
    {

        private int _toDoGroupID;
        public int ToDoGroupID
        {
            get { return _toDoGroupID; }
            set { _toDoGroupID = value; }
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


        public List<ToDoBo> ToDos;

        public Enums.Status CurStatus = 0;


        public ToDoGroupBo(ToDoGroup _group)
        {
            this._toDoGroupID = _group.ToDoGroupID;
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

            ToDos = new List<ToDoBo>();
        }


        public ToDoGroupBo(string _name)
        {
            this._name = _name;
            this._dateCreated = DateTime.Now;
            this._dateModified = DateTime.Now;

            CurStatus = Enums.Status.Create;

            ToDos = new List<ToDoBo>();
        }


    }
}
