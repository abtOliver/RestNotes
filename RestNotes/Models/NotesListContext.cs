using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestNotes.Models
{
    public class NotesListContext : INotesContext
    {
        readonly List<Note> notes = new List<Note>();

        public Note AddNote(Note note)
        {
            notes.Add(note);

            note.Id = notes.IndexOf(note) + 1;

            return note;
        }

        public Note GetNote(int id)
        {
            return notes[id - 1];
        }

        public IEnumerable<Note> ListAllNotes()
        {
            return notes;
        }
    }
}
