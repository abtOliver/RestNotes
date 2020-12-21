using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestNotes.Models
{
    public class NotesListContext
    {
        readonly List<Note> notes = new List<Note>();

        public IEnumerable<Note> ListAllNotes()
        {
            return notes;
        }
    }
}
