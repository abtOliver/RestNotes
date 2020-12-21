using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestNotes.Models
{
    public class NotesListContext : INotesContext
    {
        readonly List<Note> notes = new List<Note>();

        public IEnumerable<Note> ListAllNotes()
        {
            return notes;
        }

        public Note AddNote(Note note)
        {
            notes.Add(note);

            note.Id = notes.IndexOf(note) + 1;

            return note;
        }
    }
}
