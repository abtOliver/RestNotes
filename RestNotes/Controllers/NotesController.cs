using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestNotes.Models;
using System.Collections.Generic;

namespace RestNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesContext notesContext;

        public NotesController(INotesContext notesContext)
        {
            this.notesContext = notesContext;
        }

        [HttpGet]
        public IEnumerable<Note> GetNotes()
        {
            return notesContext.ListAllNotes();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public CreatedResult PostNote(Note note)
        {
            note = notesContext.AddNote(note);

            return Created(string.Empty, note);
        }
    }
}
