using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeverNotes.Domain;

namespace ForeverNotes.Service
{
    public class NoteService
    {
        public static void AddNote(string heading, string content)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                Note note = new Note()
                {
                    Heading = heading,
                    Content = content,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
            };
                db.Note.Add(note);
                db.SaveChanges();
            }
        }

        public static Note GetByID(int id)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                return db.Note.Where(x => x.NoteID == id).FirstOrDefault();
            }
        }

        public static List<Note> GetAllNotes()
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                return db.Note.ToList();
            }
        }

        public static List<Note> GetByModifiedDateRange(DateTime start, DateTime end)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                return db.Note.Where(x => x.DateModified >= start && x.DateModified <= end)
                    .OrderByDescending(x => x.DateModified)
                    .Select(x => x)
                    .ToList();
            }
        }

        public static List<Note> GetByCreatedDateRange(DateTime start, DateTime end)
        {
            using (ForeverNotesEntities db = new ForeverNotesEntities())
            {
                return db.Note.Where(x => x.DateCreated >= start && x.DateCreated <= end)
                    .OrderByDescending(x => x.DateCreated)
                    .Select(x => x)
                    .ToList();
            }
        }

    }
}
