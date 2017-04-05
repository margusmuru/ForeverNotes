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

namespace ForeverNotesWPF.ViewModels
{
    public class ToDoTabVM : MainVM
    {

        
        //todo gruppide observable list
        private ObservableCollection<ToDoGroupBo> _toDoGroupCollection;
        public ObservableCollection<ToDoGroupBo> ToDoGroupCollection
        {
            get { return _toDoGroupCollection; }
            set { _toDoGroupCollection = value; }
        }

        //todo objektide observable list. nimekiri nendest todo-dest mis on valitud grupis

        private ObservableCollection<ToDoBo> _toDoCollection;
        public ObservableCollection<ToDoBo> ToDoCollection
        {
            get { return _toDoCollection; }
            set { _toDoCollection = value; }
        }

        private List<ToDoGroupBo> _toDoGroupTrash;
        private List<ToDoBo> _toDoTrash;

        public ToDoTabVM()
        {
            _toDoGroupCollection = new ObservableCollection<ToDoGroupBo>();
            _toDoCollection = new ObservableCollection<ToDoBo>();
            _toDoGroupTrash = new List<ToDoGroupBo>();
            _toDoTrash = new List<ToDoBo>();

            GetAllToDoGroupsFromDataBase();
            GetAllToDosFromDataBase();
            GetAllToDosConnectionsFromDataBase();
            _log.Add("Download from database complete");
        }

        //uue lisamine
        //grupi lisamine

        public void AddToDoGroup()
        {
            ToDoGroup newToDoGroup = new ToDoGroup();
   
            //create BO
            ToDoGroupBo groupBo = new ToDoGroupBo(newToDoGroup)
            {
                Name = "New ToDo Group"
            };

            _toDoGroupCollection.Add(groupBo);

            _log.Add("New ToDo Group \"" + groupBo.Name + "\" added.");
        }

        //todo lisamine

        public void AddToDo(int toDoGroupIndex, string content)
        {
            //Console.WriteLine("index: " + toDoGroupIndex);

            try
            {

                ToDo toDo = new ToDo()
                {
                    Content = content,
                };

                ToDoBo toDoBo = new ToDoBo(toDo);
                _toDoCollection.Add(toDoBo);

                ToDoGroupBo groupBo = _toDoGroupCollection.ElementAt(toDoGroupIndex);
                groupBo.ToDos.Insert(0, toDoBo);
                groupBo.CurStatus = Enums.GetGroupStatus(groupBo.CurStatus, Enums.Status.UpdateGroupItems);

                _log.Add("A new todo has been added to group \"" + _toDoGroupCollection.ElementAt(toDoGroupIndex).Name + "\"");

            }
            catch (Exception e)
            {
                _log.Add("matzi kood on katki");
            }
        }

        public void RemoveToDo(int toDoIndex, int groupIndex)
        {
            ToDoGroupBo group = _toDoGroupCollection.ElementAt(groupIndex);
            ToDoBo todo = _toDoCollection.ElementAt(toDoIndex);
            if(group != null && todo != null)
            {
                todo.CurStatus = Enums.GetStatus(todo.CurStatus, Enums.Status.Remove);
                _toDoTrash.Add(todo);
                _toDoCollection.Remove(todo);

                group.ToDos.Remove(todo);
                group.CurStatus = Enums.GetGroupStatus(group.CurStatus, Enums.Status.UpdateGroupItems);
            }
            else
                _log.Add("ERROR: ToDoTabVM: cannot find group or todo for deletion");
        }

        public void GetAllToDoGroupsFromDataBase()
        {
            List<ToDoGroupBo> groups = ToDoService.GetAllToDoGroups();
            foreach (ToDoGroupBo groupBo in groups)
            {
                _toDoGroupCollection.Add(groupBo);
                //log
            }
            _log.Add("Downloaded " + groups.Count + " ToDo groups from database");
        }

        public void GetAllToDosFromDataBase()
        {
            List<ToDoBo> toDoBos = ToDoService.GetAllToDos();
            foreach (ToDoBo toDoBo in toDoBos)
            {
                _toDoCollection.Insert(0, toDoBo);
                _log.Add("ToDo \"" + toDoBo.Content + "\" added from database");
            }
            _log.Add("Downloaded " + toDoBos.Count + " ToDo items from database");

        }

        public void GetAllToDosConnectionsFromDataBase()
        {
            List<ToDoGroupConnection> connections = ToDoService.GetGroupConnections();
            foreach (ToDoGroupConnection con in connections)
            {
                ToDoGroupBo group = GetGroupBoByID(con.ToDoGroup_ToDoGroupID);
                ToDoBo toDo = GetToDoBoByID(con.ToDo_ToDoID);
                if(group != null && toDo != null)
                {
                    group.ToDos.Add(toDo);
                    _log.Add("ToDo \"" + toDo.Content + "\" added to group \"" + group.Name + "\" from database");
                }              
            }
            _log.Add("Downlaoded " + connections.Count + " ToDo connections from database");
        }

        private ToDoGroupBo GetGroupBoByID(int id)
        {
            foreach (ToDoGroupBo groupBo in _toDoGroupCollection)
            {
                if (groupBo.ToDoGroupID == id)
                    return groupBo;
            }
            return null;
        }

        private ToDoBo GetToDoBoByID(int id)
        {
            foreach (ToDoBo toDoBo in _toDoCollection)
            {
                if (toDoBo.ToDoID == id)
                    return toDoBo;
            }
            return null;
        }

        public void SetToDos(int groupIndex)
        {
            _toDoCollection.Clear();

            ToDoGroupBo groupBo = _toDoGroupCollection.ElementAt(groupIndex);

            Comparison<ToDoBo> comparison = new Comparison<ToDoBo>(
            (p, q) =>
            {
                DateTime first = p.DateCreated;
                DateTime second = q.DateCreated;
                if (first == second)
                    return 0;
                if (first > second)
                    return -1;
                return 1;
            });
            List<ToDoBo> tempList = groupBo.ToDos.ToList();
            tempList.Sort(comparison);


            foreach (ToDoBo todo in tempList)
            {
                if (todo.IsCheckedPriority && !todo.IsCheckedDone)
                    _toDoCollection.Add(todo);
            }

            foreach(ToDoBo todo in tempList)
            {
                if (!todo.IsCheckedPriority && !todo.IsCheckedDone)
                    _toDoCollection.Add(todo);
            }

            foreach (ToDoBo todo in tempList)
            {
                if (!_toDoCollection.Contains(todo))
                    _toDoCollection.Add(todo);
            }

        }

        public void RenameToDoGroup(int index, string newName)
        {
            if (!newName.Trim().Equals(""))
            {
                ToDoGroupBo groupBo = _toDoGroupCollection.ElementAt(index);
                groupBo.Name = newName;
                groupBo.CurStatus = Enums.GetGroupStatus(groupBo.CurStatus, Enums.Status.UpdateGroup);
                //log
                _log.Add("ToDo has been renamed to \"" + newName + "\"");
            }
        }

        public void RemoveToDoGroup(int index)
        {
            ToDoGroupBo groupToEdit = _toDoGroupCollection.ElementAt(index);
            //set status
            groupToEdit.CurStatus = Enums.GetGroupStatus(groupToEdit.CurStatus, Enums.Status.Remove);
            //_log.Add("ToDoGroup status set to " + groupToEdit.CurStatus.ToString());

            _toDoGroupCollection.RemoveAt(index);

            _toDoGroupTrash.Add(groupToEdit);

            _toDoCollection.Clear();

            foreach(ToDoBo todo in groupToEdit.ToDos)
            {
                todo.CurStatus = Enums.GetStatus(todo.CurStatus, Enums.Status.Remove);
                _toDoTrash.Add(todo);
            }
            groupToEdit.ToDos.Clear();

            //log
            _log.Add("ToDoGroup \"" + groupToEdit.Name + "\" removed.");
        }

        public void Sync()
        {
            _log.Add("Starting ToDo-s Sync...");
            SyncGroups();
            SyncTodos();
            SyncConnections();

            SyncItemsToRemove();

            _log.Add("ToDo-s Sync complete");
        }

        public void SyncGroups()
        {
            foreach (ToDoGroupBo groupBo in _toDoGroupCollection)
            {
                switch (groupBo.CurStatus)
                {
                    case Enums.Status.Create:
                        ToDoService.AddToDoGroup(groupBo);
                        _log.Add("Added ToDoGroup \"" + groupBo.Name + "\" To DataBase");
                        groupBo.CurStatus = Enums.Status.UpdateGroupItems;
                        break;

                    case Enums.Status.UpdateGroup:
                        ToDoService.RenameToDoGroup(groupBo);
                        _log.Add("Renamed ToDoGroup \"" + groupBo.Name + "\" in database");
                        groupBo.CurStatus = Enums.Status.Synced;
                        break;

                    case Enums.Status.UpdateGroupAndItems:
                        ToDoService.RenameToDoGroup(groupBo);
                        _log.Add("Renamed ToDoGroup \"" + groupBo.Name + "\" in database");
                        groupBo.CurStatus = Enums.Status.UpdateGroupItems;
                        break;

                    default:
                        break;
                }
            }
        }

        public void SyncTodos()
        {
            foreach (ToDoBo toDoBo in _toDoCollection)
            {
                switch (toDoBo.CurStatus)
                {
                    case Enums.Status.Create:
                        ToDoService.AddToDo(toDoBo);
                        _log.Add("Added ToDo \"" + toDoBo.Content + "\" To DataBase");
                        
                        break;
                    case Enums.Status.Update:
                        ToDoService.UpdateToDo(toDoBo);
                        _log.Add("ToDo \"" + toDoBo.Content + "\" updated in database");
                        break;
                   
                    default:
                        break;
                }
                toDoBo.CurStatus = Enums.Status.Synced;
            }
        }

        public void SyncConnections()
        {
            int counter = 0;
            foreach (ToDoGroupBo groupBo in _toDoGroupCollection)
            {
                if (groupBo.CurStatus == Enums.Status.UpdateGroupItems)
                {
                    ToDoService.SetGroupConnections(groupBo);
                    groupBo.CurStatus = Enums.Status.Synced;
                    counter++;
                }
            }
            _log.Add("Added " + counter + " todo groups to connections in database");
            counter = 0;
            foreach (ToDoGroupBo groupBo in _toDoGroupTrash)
            {
                if (groupBo.CurStatus == Enums.Status.Remove)
                {
                    ToDoService.SetGroupConnections(groupBo);
                    counter++;
                }
            }
            _log.Add("Removed " + counter + " todo groups to connections in database");
        }

        public void SyncItemsToRemove()
        {
            foreach (ToDoGroupBo groupBo in _toDoGroupTrash)
            {
                if(groupBo.CurStatus == Enums.Status.Remove)
                {
                    ToDoService.RemoveToDoGroup(groupBo);
                    _log.Add("Removed ToDoGroup \"" + groupBo.Name + "\" from database");
                }
            }

            _toDoGroupTrash.Clear();

            foreach (ToDoBo todo in _toDoTrash)
            {
                if(todo.CurStatus == Enums.Status.Remove)
                {
                    ToDoService.RemoveToDo(todo);
                    _log.Add("Removed ToDo \"" + todo.Content + "\" from database");
                }
            }

            _toDoTrash.Clear();
        }

    }
}
