using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestNotes.Models;
using System;
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

        [HttpGet("{id}")]
        public ActionResult<Note> GetNote(int id)
        {
            try
            {
                return notesContext.GetNote(id); 
            } catch // if the context throws any exception, the note can't be found anyways
            {
                return NotFound();
            }
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
