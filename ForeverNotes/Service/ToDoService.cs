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
    public static class ToDoService
    {
        /**
         * Get all notegroups from database and generate NoteGroupBo objects.
         */
        public static List<ToDoGroupBo> GetAllToDoGroups()
        {
            List<ToDoGroup> toDoGroups = new List<ToDoGroup>();
            List<ToDoGroupBo> toDoGroupBos = new List<ToDoGroupBo>();
            //get todogroups from database
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                toDoGroups = db.ToDoGroup.ToList();
            }
            // create BO-s
            foreach (ToDoGroup toDoGroup in toDoGroups)
            {
                ToDoGroupBo toDoGroupBo = new ToDoGroupBo(toDoGroup);
                toDoGroupBos.Add(toDoGroupBo);
            }

            return toDoGroupBos;
        }

        public static List<ToDoBo> GetAllToDos()
        {
            List<ToDo> toDos = new List<ToDo>();
            List<ToDoBo> toDoBos = new List<ToDoBo>();
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                toDos = db.ToDo.ToList();
            }
            foreach (ToDo toDo in toDos)
            {
                ToDoBo toDoBo = new ToDoBo(toDo);
                toDoBos.Add(toDoBo);
            }
            return toDoBos;
        }

        public static List<ToDoGroupConnection> GetGroupConnections()
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                return db.ToDoGroupConnection.ToList();
            }
        }

        public static void AddToDoGroup(ToDoGroupBo groupBo)
        {
            ToDoGroup group = new ToDoGroup()
            {
                Name = groupBo.Name,
                DateCreated = groupBo.DateCreated,
                DateModified = groupBo.DateModified
            };
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                db.ToDoGroup.Add(group);
                db.SaveChanges();
                groupBo.ToDoGroupID = group.ToDoGroupID;

            }
        }

        public static void RenameToDoGroup(ToDoGroupBo groupBo)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                ToDoGroup toModify = db.ToDoGroup.Where(x => x.ToDoGroupID == groupBo.ToDoGroupID).FirstOrDefault();
                if(toModify != null)
                {
                    toModify.Name = groupBo.Name;
                    toModify.DateModified = DateTime.Now;
                    db.SaveChanges();
                }
            }
        }

        public static void RemoveToDoGroup(ToDoGroupBo groupBo)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                var toRemove = db.ToDoGroup.Where(x => x.ToDoGroupID == groupBo.ToDoGroupID).FirstOrDefault();
                if (toRemove != null)
                {
                    db.ToDoGroup.Remove(toRemove);
                    db.SaveChanges();
                }
            }
        }

        public static void AddToDo(ToDoBo toDoBo)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                ToDo toDo = new ToDo()
                {
                    Content = toDoBo.Content,
                    Checked = toDoBo.IsCheckedDone,
                    Prioroty = toDoBo.IsCheckedPriority,
                    DateModified = toDoBo.DateModified,
                    DateCreated = toDoBo.DateCreated,
                };
                db.ToDo.Add(toDo);
                db.SaveChanges();
                toDoBo.ToDoID = toDo.ToDoID;
            }

        }

        public static void RemoveToDo(ToDoBo todo)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                var toRemove = db.ToDo.Where(x => x.ToDoID == todo.ToDoID).FirstOrDefault();
                if (toRemove != null)
                {
                    db.ToDo.Remove(toRemove);
                    db.SaveChanges();
                }
            }
        }

        public static void UpdateToDo(ToDoBo toDoBo)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                ToDo toModify = db.ToDo.Where(x => x.ToDoID == toDoBo.ToDoID).FirstOrDefault();
                if (toModify != null)
                {
                    toModify.Content = toDoBo.Content;
                    toModify.Checked = toDoBo.IsCheckedDone;
                    toModify.Prioroty = toDoBo.IsCheckedPriority;
                    toModify.DateModified = toDoBo.DateModified;
                    db.SaveChanges();
                }
            }
        }

        public static void SetGroupConnections(ToDoGroupBo groupBo)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                List<ToDoGroupConnection> toRemove = db.ToDoGroupConnection.Where(x => x.ToDoGroup_ToDoGroupID == groupBo.ToDoGroupID).ToList();
                if (toRemove != null)
                    foreach (ToDoGroupConnection con in toRemove)
                        db.ToDoGroupConnection.Remove(con);


                //create new connections.
                foreach (ToDoBo toDoBo in groupBo.ToDos)
                {
                    ToDoGroupConnection con = new ToDoGroupConnection
                    {
                        ToDoGroup_ToDoGroupID = groupBo.ToDoGroupID,
                        ToDo_ToDoID = toDoBo.ToDoID
                    };
                    db.ToDoGroupConnection.Add(con);
                }
                db.SaveChanges();
            }
        }
    }
}
