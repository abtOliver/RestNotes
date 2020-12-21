using System.Collections.Generic;

namespace RestNotes.Models
{
    public interface INotesContext
    {
        IEnumerable<Note> ListAllNotes();
    }
}