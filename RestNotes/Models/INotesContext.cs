using System.Collections.Generic;

namespace RestNotes.Models
{
    public interface INotesContext
    {
        Note AddNote(Note note);

        Note GetNote(int id);

        void SaveNote(Note note);

        IEnumerable<Note> ListAllNotes();
    }
}