using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeverNotes.Domain;

namespace ForeverNotes.BO
{
    public class ToDoBo
    {
        private int _toDoID;

        public int ToDoID
        {
            get { return _toDoID; }
            set { _toDoID = value; }
        }

        private string _content;

        public string Content
        {
            get { return _content; }
            set {
                _content = value;
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

        private bool _isCheckedDone;

        public bool IsCheckedDone
        {
            get { return _isCheckedDone; }
            set {
                _isCheckedDone = value;
                CurStatus = Enums.GetStatus(CurStatus, Enums.Status.Update);
            }
        }

        private bool _isCheckedPriority;

        public bool IsCheckedPriority
        {
            get { return _isCheckedPriority; }
            set {
                _isCheckedPriority = value;
                CurStatus = Enums.GetStatus(CurStatus, Enums.Status.Update);
            }
        }

        

        public Enums.Status CurStatus = 0;

        public ToDoBo(ToDo todo)
        {
            _toDoID = todo.ToDoID;
            _content = todo.Content;
            if (todo.DateCreated == DateTime.MinValue)
            {
                _dateCreated = DateTime.Now;
                _dateModified = DateTime.Now;
                CurStatus = Enums.Status.Create;
            }
            else
            {
                _dateCreated = todo.DateCreated;
                _dateModified = todo.DateModified;
                if (todo.Checked.HasValue && todo.Checked.Value == true)
                    _isCheckedDone = true;
                if (todo.Prioroty.HasValue && todo.Prioroty == true)
                    _isCheckedPriority = true;
                CurStatus = Enums.Status.Synced;
            }
        }

    }
}
