using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeverNotes.Service;
using ForeverNotes.Domain;

namespace ForeverNotes.ConsoleApp
{
    class Program
    {
        /*
        static void Main(string[] args)
        {
            //AddNote();

            GetNoteByID(1);

            GetNoteByModifiedDate(new DateTime(2016, 10, 30, 23, 5, 0), DateTime.Now);
            GetNoteByCreatedDate(new DateTime(2016, 10, 30, 23, 5, 0), DateTime.Now);

            GetAllNotes();
        }
        
        static void AddNote()
        {
            NoteService.AddNote("pealkiri", "suurepärane sisu");
        }

        static void GetNoteByID(int id)
        {
            Note note = ForeverNotes.Service.NoteService.GetByID(id);
            Console.WriteLine(note.NoteID + " " + note.Heading + " " + note.Content + " " + note.DateCreated + " " + note.DateModified);
        }

        static void GetAllNotes()
        {
            List<ForeverNotes.Domain.Note> notes = NoteService.GetAllNotes();
            foreach (ForeverNotes.Domain.Note item in notes)
            {
                Console.WriteLine(item.NoteID + " " + item.Heading + " " + item.DateModified);
            }
        }

        static void GetNoteByModifiedDate(DateTime start, DateTime end)
        {
            List<ForeverNotes.Domain.Note> notes = NoteService.GetByModifiedDateRange(start, end);
            foreach (ForeverNotes.Domain.Note item in notes)
            {
                Console.WriteLine(item.NoteID + " " + item.Heading + " " + item.DateModified);
            }
        }

        static void GetNoteByCreatedDate(DateTime start, DateTime end)
        {
            List<ForeverNotes.Domain.Note> notes = NoteService.GetByCreatedDateRange(start, end);
            foreach (ForeverNotes.Domain.Note item in notes)
            {
                Console.WriteLine(item.NoteID + " " + item.Heading + " " + item.DateModified);
            }
        }
        */
    }
}
