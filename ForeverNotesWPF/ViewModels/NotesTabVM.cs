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
    public class NotesTabVM : MainVM

    {
        //collection of currently displayed notes
        private ObservableCollection<NoteBo> _notesCollection;
        public ObservableCollection<NoteBo> NotesCollection
        {
            get { return _notesCollection;}
        }

        private ObservableCollection<NoteGroupBo> _noteGroupCollection;
        public ObservableCollection<NoteGroupBo> NoteGroupCollection
        {
            get { return _noteGroupCollection; }
        }
        private List<NoteGroupBo> _noteGroupTrash;
        private List<NoteBo> _noteTrash;


        private List<NoteBo> _allNotes;
        private List<Tag> _allTags;

        /**
         * Constructor. Initialize lists and startup methods
         */
        public NotesTabVM()
        {
            _notesCollection = new ObservableCollection<NoteBo>();
            _noteGroupCollection = new ObservableCollection<NoteGroupBo>();
            
            _noteGroupTrash = new List<NoteGroupBo>();
            _noteTrash = new List<NoteBo>();
            //kinda temporary
            _allNotes = new List<NoteBo>();
            _allTags = new List<Tag>();

            //working
            GetAllNotesFromDataBase();
            //working
            GetAllNoteGroupsFromDataBase();
            //working
            GetAllNoteGroupConnectionsFromDataBase();
            //might work
            GetTagsFromDataBase();

            _log.Add("Download from database complete");
        }

        /**
         * Get objects
         */


        /**
         * Get all note Bo-s and add to List
         */
        public void GetAllNotesFromDataBase()
        {
            List<NoteBo> notes = NoteService.GetAllNotes();
            foreach (NoteBo noteBo in notes)
            {
                _allNotes.Add(noteBo);
                _log.Add("Note \"" + noteBo.Heading + "\" added from database");
            }
            _log.Add("Downloaded " + notes.Count + " notes from database");
        }

        /**
         * Get all Tags from database
         */
        public void GetTagsFromDataBase()
        {
            _allTags = NoteService.GetAllTags();
            List<TagConnection> tagConnections = NoteService.GetAllTagConnections();
            //add tags to notes
            foreach (TagConnection connection in tagConnections)
            {
                NoteBo noteBo = GetNoteBoByID(connection.NoteID);
                noteBo.TagsList.Add(GetTagByID(connection.TagID));
            }
            //generate tag string
            foreach (NoteBo noteBo in _allNotes)
            {
                noteBo.GenerateTagString();
            }
        }

        /**
         * Get all group Bo-s and add to List
         */
        public void GetAllNoteGroupsFromDataBase()
        {
            List<NoteGroupBo> groups = NoteService.GetAllNoteGroups();
            foreach (NoteGroupBo groupBo in groups)
            {
                _noteGroupCollection.Add(groupBo);
            }
            //check if some groups are missing
            //search results
            NoteGroupBo group = GetGroupBoByName("# Search Results");
            if (group == null)
            {
                group = new NoteGroupBo("# Search Results");
                _log.Add("Added new NoteGroup \"# Search Results\"");
            }

            else
            {
                _noteGroupCollection.Remove(group);
                _log.Add("Reordering NoteGroup \"# Search Results\"");
            }   
            _noteGroupCollection.Insert(0, group);
            
            //Trash
            group = GetGroupBoByName("# Trash");
            if (group == null)
            {
                group = new NoteGroupBo("# Trash");
                _log.Add("Added new NoteGroup \"# Trash\"");
            }
            else
            {
                _noteGroupCollection.Remove(group);
                _log.Add("Reordering NoteGroup \"# Trash\"");
            }            
            _noteGroupCollection.Insert(0, group);
            
            //All Notes
            group = GetGroupBoByName("# All Notes");
            if (group == null)
            {
                group = new NoteGroupBo("# All Notes");
                _log.Add("Added new NoteGroup \"# All Notes\"");
            }
            else
            {
                _noteGroupCollection.Remove(group);
                _log.Add("Reordering NoteGroup \"# All Notes\"");
            }              
            _noteGroupCollection.Insert(0, group);

            _log.Add("Downloaded " + groups.Count + " groups from database");
            //Reorder so #-ed items are on top.
        }

        /**
         * Get group connections and add noteBO-s to NoteGroupBo-s lists
         */
        public void GetAllNoteGroupConnectionsFromDataBase()
        {
            List<GroupConnection> connections = NoteService.GetAllGroupConnections();
            //add notes to groups
            foreach(GroupConnection con in connections)
            {
                NoteGroupBo groupBo = GetGroupBoByID(con.NoteGroupID);
                NoteBo noteBo = GetNoteBoByID(con.NoteID);
                if(groupBo != null && noteBo != null)
                {
                    groupBo.notes.Add(noteBo);
                    _log.Add("Note \"" + noteBo.Heading + "\" added to group \"" + groupBo.Name + "\" from database");
                }
            }
            _log.Add("Downloaded " + connections.Count + " connections from database");
        }


        /**
         * Search methods
         */


        /**
         * Find a NoteGroupBo by ID
         */
        private NoteGroupBo GetGroupBoByID(int id)
        {
            foreach(NoteGroupBo groupBO in _noteGroupCollection)
            {
                if (groupBO.GroupID == id)
                    return groupBO;
            }
            return null;
        }

        /**
         * Find a NotegroupBo by ID
         */
         private NoteGroupBo GetGroupBoByName(string name)
        {
            foreach (NoteGroupBo groupBO in _noteGroupCollection)
            {
                if (groupBO.Name.Equals(name))
                    return groupBO;
            }
            return null;
        }

        /**
         * Find a NoteBo by ID
         */
        private NoteBo GetNoteBoByID(int id)
        {
            foreach(NoteBo noteBO in _allNotes)
            {
                if (noteBO.NoteID == id)
                    return noteBO;
            }
            return null;
        }

        /**
         * Find Tag by ID
         */
        private Tag GetTagByID(int id)
        {
            foreach (Tag tag in _allTags)
            {
                if (tag.TagID == id)
                    return tag;
            }
            return null;
        }


        /**
         * Notegroups
         */


        /**
         * Add a new NoteGroup
         */
        public void AddNoteGroup(string name)
        {
            NoteGroup newNoteGroup = new NoteGroup();

            //set name
            if (!name.Trim().Equals(""))
                newNoteGroup.Name = name;
            else
                newNoteGroup.Name = "New NoteGroup";

            //create BO
            NoteGroupBo newGroupBO = new NoteGroupBo(newNoteGroup);
            //add to collection
            _noteGroupCollection.Add(newGroupBO);
            //log
            _log.Add("New NoteGroup \"" + newNoteGroup.Name + "\" added.");
            
        }

        /**
         * Remove NoteGroup
         */
        public void RemoveNoteGroup(int index)
        {
            NoteGroupBo groupToEdit = _noteGroupCollection.ElementAt(index);
            NoteGroupBo trash = GetGroupBoByName("# Trash");

            //remove all notes in that group
            foreach (NoteBo noteBo in groupToEdit.notes)
            {
                trash.notes.Insert(0, noteBo);
                //noteBo.CurStatus = Enums.GetStatus(noteBo.CurStatus, Enums.Status.UpdateGroup);

                NoteGroupBo allNotes = GetGroupBoByName("# All Notes");
                allNotes.notes.Remove(noteBo);
                allNotes.CurStatus = Enums.GetGroupStatus(allNotes.CurStatus, Enums.Status.UpdateGroup);
            }

            //set status
            groupToEdit.CurStatus = Enums.GetStatus(groupToEdit.CurStatus, Enums.Status.Remove);
            _log.Add("Group status set to " + groupToEdit.CurStatus.ToString());
            //add to trash
            _noteGroupTrash.Add(groupToEdit);
            //remove from main list
            _noteGroupCollection.RemoveAt(index);
            //log
            _log.Add("NoteGroup \"" + groupToEdit.Name + "\" removed.");
        }

        /**
         * Rename a NoteGroup
         */
        public void RenameNoteGroup(int index, string newName)
        {
            if (!newName.Trim().Equals(""))
            {
                NoteGroupBo groupBo = _noteGroupCollection.ElementAt(index);
                groupBo.Name = newName;
                groupBo.CurStatus = Enums.GetGroupStatus(groupBo.CurStatus, Enums.Status.UpdateGroup);
                //log
                _log.Add("Group has been renamed to \"" + newName + "\"");
            }
        }



        /**
         * Notes
         */


        /**
         * Add a new note
         */
        public void AddNote(int notegroupIndex)
        {
            NoteBo newNote = new NoteBo(new Note());
            _allNotes.Insert(0, newNote);
            
            //add note to currently selected group
            NoteGroupBo groupBo = _noteGroupCollection.ElementAt(notegroupIndex);
            groupBo.notes.Insert(0,newNote);
            groupBo.CurStatus = Enums.GetGroupStatus(groupBo.CurStatus, Enums.Status.UpdateGroupItems);
            
            //add note to current collection so its displayed right away
            _notesCollection.Insert(0, newNote);
            
            //add note to "#all notes". not even sure if needed XD
            NoteGroupBo allNotes = GetGroupBoByName("# All Notes");
            if(allNotes != null)
            {
                allNotes.notes.Insert(0, newNote);
                allNotes.CurStatus = Enums.GetGroupStatus(allNotes.CurStatus, Enums.Status.UpdateGroupItems);
            }
            //log
            _log.Add("A new note has been added to group \"" + _noteGroupCollection.ElementAt(notegroupIndex).Name + "\"");
        }

        /**
         * Remove a note. called by notelistbox context menu and edit menu
         */
        public void RemoveNote(int noteIndex, int noteGroupIndex)
        {
            //note to remove
            NoteBo noteBo = _notesCollection.ElementAt(noteIndex);
            //group from where to remove
            NoteGroupBo groupBo = _noteGroupCollection.ElementAt(noteGroupIndex);

            if (noteBo != null && groupBo != null)
            {
                //update trash
                NoteGroupBo trash = GetGroupBoByName("# Trash");
                trash.notes.Insert(0, noteBo);
                trash.CurStatus = Enums.GetGroupStatus(trash.CurStatus, Enums.Status.UpdateGroupItems);
                //update all notes
                NoteGroupBo allNotes = GetGroupBoByName("# All Notes");
                allNotes.notes.Remove(noteBo);
                allNotes.CurStatus = Enums.GetGroupStatus(allNotes.CurStatus, Enums.Status.UpdateGroupItems);
                //update original group
                groupBo.notes.Remove(noteBo);
                _notesCollection.Remove(noteBo);
                groupBo.CurStatus = Enums.GetGroupStatus(groupBo.CurStatus, Enums.Status.UpdateGroupItems);

                //log
                _log.Add("Note \"" + noteBo.Heading + "\" deleted");
            }
            else
                _log.Add("ERROR: NotesTabVM: cannot find notegroup or note for deletion");
        }




        /**
         * Services
         */

        public void EmptyTrash(bool removeFromCurrent)
        {
            NoteGroupBo trash = GetGroupBoByName("# Trash");
            foreach (NoteBo noteBo in trash.notes)
            {
                _noteTrash.Add(noteBo);
                _allNotes.Remove(noteBo);
                noteBo.TagsList.Clear();
                noteBo.CurStatus = Enums.GetStatus(noteBo.CurStatus, Enums.Status.Remove);

                if (removeFromCurrent)
                {
                    try
                    {
                        _notesCollection.Remove(noteBo);
                    }
                    catch (NullReferenceException e) { }
                }
            }
            trash.CurStatus = Enums.GetGroupStatus(trash.CurStatus, Enums.Status.UpdateGroupItems);
            trash.notes.Clear();
            _log.Add("Trash has been emptied");
        }

        /**
         * Changes from which notegroup to display notes
         */
        public void SetNotesList(object groupBo)
        {
            _notesCollection.Clear();
            foreach(NoteBo noteBo in ((NoteGroupBo)groupBo).notes)
            {
                
                _notesCollection.Add(noteBo);
            }
        }

        public void Sync()
        {
            _log.Add("Starting database sync...");

            BuildTagObjectsForNoteBos();
            SyncGroups();
            SyncNotes();
            SyncConnections();

            SyncItemsToRemove();
            

            _log.Add("Sync complete");
        }

        private void SyncNotes()
        {
            foreach(NoteBo noteBo in _allNotes)
            {
                switch (noteBo.CurStatus)
                {
                    case Enums.Status.Create:

                        NoteService.AddNote(noteBo);
                        NoteService.SyncTags(noteBo);
                        _log.Add("Note \"" + noteBo.Heading + "\" added to database");
                        //noteBo.CurStatus = Enums.Status.UpdateGroup;
                        break;

                    case Enums.Status.Update:

                        NoteService.UpdateNote(noteBo);
                        NoteService.SyncTags(noteBo);
                        _log.Add("Note \"" + noteBo.Heading + "\" updated in database");
                        //
                        break;

                    default:
                        break;
                }
                noteBo.CurStatus = Enums.Status.Synced;
            }
            
        }

        private void SyncConnections()
        {
            
            foreach (NoteGroupBo noteGroupBo in _noteGroupCollection)
            {
                if(noteGroupBo.CurStatus == Enums.Status.UpdateGroupItems)
                {
                    NoteService.SetGroupConnections(noteGroupBo);
                    noteGroupBo.CurStatus = Enums.Status.Synced;
                }
                
            }
            
        }



        private void SyncGroups()
        {
            foreach(NoteGroupBo noteGroupBo in _noteGroupCollection)
            {
                switch (noteGroupBo.CurStatus)
                {
                    case Enums.Status.Create:

                        NoteService.AddNoteGroup(noteGroupBo);
                        _log.Add("Added NoteGroup \"" + noteGroupBo.Name + "\" to database");

                        if(noteGroupBo.notes.Count > 0)
                            noteGroupBo.CurStatus = Enums.Status.UpdateGroupItems;
                        else
                            noteGroupBo.CurStatus = Enums.Status.Synced;

                        break;
                    case Enums.Status.UpdateGroup:

                        NoteService.RenameNoteGroup(noteGroupBo);
                        _log.Add("Renamed NoteGroup \"" + noteGroupBo.Name + "\" in database");
                        noteGroupBo.CurStatus = Enums.Status.Synced;

                        break;
                    case Enums.Status.UpdateGroupAndItems:
                        NoteService.RenameNoteGroup(noteGroupBo);
                        _log.Add("Renamed NoteGroup \"" + noteGroupBo.Name + "\" in database");
                        noteGroupBo.CurStatus = Enums.Status.UpdateGroupItems;
                    
                        break;
                    
                    default:
                        break;
                }
                
            }
            
        }

        private void SyncItemsToRemove()
        {
            //empty trash
            foreach (NoteBo noteBo in _noteTrash)
            {
                if (noteBo.CurStatus != Enums.Status.LeaveIt)
                {
                    NoteService.SyncTags(noteBo);
                    NoteService.RemoveNote(noteBo);
                    _log.Add("Note \"" + noteBo.Heading + "\" removed from database");
                }

                noteBo.CurStatus = Enums.Status.Synced;
            }
            _noteTrash.Clear();

            //delete trash
            foreach (NoteGroupBo noteGroupBo in _noteGroupTrash)
            {
                if (noteGroupBo.CurStatus != Enums.Status.LeaveIt)
                {
                    NoteService.RemoveNoteGroup(noteGroupBo);
                    _log.Add("Removed NoteGroup \"" + noteGroupBo.Name + "\" from database");
                }

                noteGroupBo.CurStatus = Enums.Status.Synced;
            }
            _noteGroupTrash.Clear();

            NoteService.RemoveTagsWithNoConnections();
        }

        private void BuildTagObjectsForNoteBos()
        {
            foreach (NoteBo noteBo in _allNotes)
            {
                string result = noteBo.GenerateTagObjects(_allTags);
                if (!result.Equals(""))
                    _log.Add(result);
            }
        }



    }
}
