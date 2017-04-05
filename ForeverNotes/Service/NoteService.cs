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
    public class NoteService
    {
        


        /**
         * Add a new Note to the database
         */
        public static Note AddNote(NoteBo noteBo)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                Note note = new Note()
                {
                    Heading = noteBo.Heading,
                    Content = noteBo.Content,
                    DateCreated = noteBo.DateCreated,
                    DateModified = noteBo.DateModified
                };
                db.Note.Add(note);
                db.SaveChanges();
                noteBo.NoteID = note.NoteID;
                return note;
            }
        }

        /**
         * Update given note in database
         */
        public static void UpdateNote(NoteBo noteBo)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                Note toModify = db.Note.Where(x => x.NoteID == noteBo.NoteID).FirstOrDefault();
                if (toModify != null)
                {
                    toModify.Heading = noteBo.Heading;
                    toModify.Content = noteBo.Content;
                    toModify.DateModified = noteBo.DateModified;
                    db.SaveChanges();
                }
            }
        }

        /**
         * Remove note from database
         */
         public static void RemoveNote(NoteBo noteBo)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                var toRemove = db.Note.Where(x => x.NoteID == noteBo.NoteID).FirstOrDefault();
                if (toRemove != null)
                {
                    db.Note.Remove(toRemove);
                    db.SaveChanges();
                }
            }
        }




        /**
         * Add a new NoteGroup to the database
         */
        public static NoteGroup AddNoteGroup(NoteGroupBo groupBo)
        {
            NoteGroup group = new NoteGroup()
            {
                Name = groupBo.Name,
                DateCreated = groupBo.DateCreated,
                DateModified = groupBo.DateModified
            };
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                db.NoteGroup.Add(group);
                db.SaveChanges();
                //add newly created ID to BO
                groupBo.GroupID = group.NoteGroupID;
                return group;
            }
        }

        /**
         * Rename given NoteGroup
         */
        public static void RenameNoteGroup(NoteGroupBo groupBo)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                NoteGroup toModify = db.NoteGroup.Where(x => x.NoteGroupID == groupBo.GroupID).FirstOrDefault();
                if (toModify != null)
                {
                    toModify.Name = groupBo.Name;
                    toModify.DateModified = DateTime.Now;
                    db.SaveChanges();
                }
            }
        }

        /**
         * Remove given NoteGroup
         */
        public static void RemoveNoteGroup(NoteGroupBo groupBo)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                var toRemove = db.NoteGroup.Where(x => x.NoteGroupID == groupBo.GroupID).FirstOrDefault();
                if (toRemove != null)
                {
                    db.NoteGroup.Remove(toRemove);
                    db.SaveChanges();
                }
            }
        }



        public static void SetGroupConnections(NoteGroupBo groupBo)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {

                List<GroupConnection> toRemove = db.GroupConnection.Where(x => x.NoteGroupID == groupBo.GroupID).ToList();

                if (toRemove != null)
                {
                    foreach (GroupConnection con in toRemove)
                        db.GroupConnection.Remove(con);
                }


                //create new connections
                foreach (NoteBo note in groupBo.notes)
                {
                    GroupConnection newConnection = new GroupConnection()
                    {
                        NoteID = note.NoteID,
                        NoteGroupID = groupBo.GroupID
                    };
                    db.GroupConnection.Add(newConnection);
                }

                db.SaveChanges();
            }
        }


        public static List<Tag> GetAllTags()
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                return db.Tag.ToList();
            }
        }

        public static List<TagConnection> GetAllTagConnections()
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                return db.TagConnection.ToList();
            }
        }

        public static void SyncTags(NoteBo noteBo)
        {

            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                //check if tag is already in database

                List<Tag> tags = db.Tag.ToList();
                List<Tag> newTags = new List<Tag>();

                foreach (Tag noteTag in noteBo.TagsList)
                {
                    bool found = false;
                    foreach (Tag dTag in tags)
                    {
                        if(dTag.TagID == noteTag.TagID)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                        newTags.Add(noteTag);


                }
                //add new Tags
                foreach (Tag nTag in newTags)
                {
                    db.Tag.Add(nTag);
                    db.SaveChanges();
                }

                //check if connection is already in database
                List<TagConnection> connections = db.TagConnection.ToList();

                foreach (Tag tag in noteBo.TagsList)
                {
                    bool found = false;
                    foreach (TagConnection con in connections)
                    {
                        if(con.NoteID.Equals(noteBo.NoteID) && con.TagID.Equals(tag.TagID))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        TagConnection newConnection = new TagConnection
                        {
                            TagID = tag.TagID,
                            NoteID = noteBo.NoteID
                        };
                        db.TagConnection.Add(newConnection);
                        db.SaveChanges();
                        connections.Add(newConnection);
                    }
                }

                //remove connections to tags, that are not included with the note
                
                foreach (TagConnection curCon in connections)
                {
                    bool found = false;
                    foreach (Tag tag in noteBo.TagsList)
                    {
                        if(tag.TagID == curCon.TagID)
                        {
                            found = true;
                            break;
                        }
                    }


                    if (curCon.NoteID.Equals(noteBo.NoteID) && !found)
                    {
                        db.TagConnection.Remove(curCon);
                        db.SaveChanges();
                    }
                        
                }
                
                db.SaveChanges();
            }
        }

        public static void RemoveTagsWithNoConnections()
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                List<Tag> tags = db.Tag.ToList();
                List<TagConnection> connections = db.TagConnection.ToList();

                foreach (Tag tag in tags)
                {
                    bool found = false;
                    foreach (TagConnection con in connections)
                    {
                        if (con.Tag.Equals(tag))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        db.Tag.Remove(tag);
                    }
                }
                db.SaveChanges();

            }
        }

        /**
         * Get all notes from database and generate NoteBo objects. 
         */
        public static List<NoteBo> GetAllNotes()
        {
            List<Note> notes = new List<Note>();
            List<NoteBo> noteBos = new List<NoteBo>();
            //get notes from database
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                notes = db.Note.ToList();
            }
            //create BO-s
            foreach (Note note in notes)
            {
                NoteBo noteBO = new NoteBo(note);
                noteBos.Add(noteBO);
            }
            return noteBos;
        }

        /**
         * Get group connections from database
         */
        public static List<GroupConnection> GetAllGroupConnections()
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                return db.GroupConnection.ToList();
            }
        }

        /**
         * Get all notegroups from database and generate NoteGroupBo objects.
         */
        public static List<NoteGroupBo> GetAllNoteGroups()
        {
            List<NoteGroup> groups = new List<NoteGroup>();
            List<NoteGroupBo> groupBos = new List<NoteGroupBo>();
            //get notegroups from database
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                groups = db.NoteGroup.ToList();
            }
            // create BO-s
            foreach (NoteGroup group in groups)
            {
                NoteGroupBo groupBO = new NoteGroupBo(group);
                groupBos.Add(groupBO);
            }
            
            return groupBos;
        }


    }
}
