using System.Collections.Generic;

namespace RestNotes.Models
{
    public interface INotesContext
    {
        Note AddNote(Note note);

        IEnumerable<Note> ListAllNotes();
    }
}