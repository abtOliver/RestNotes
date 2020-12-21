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
    }
}
