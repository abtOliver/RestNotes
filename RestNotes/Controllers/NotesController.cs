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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        public CreatedAtActionResult PostNote(Note note)
        {
            note = notesContext.AddNote(note);

            return CreatedAtAction(nameof(GetNote),new { id = note.Id }, note);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult PutNote(int id, Note note)
        {
            if (note.Id == 0)
            {
                note.Id = id;
            }
            else if (note.Id != id)
            {
                return BadRequest();
            }

            try
            {
                notesContext.SaveNote(note);

                return NoContent();
            }
            catch  // if the context throws any exception, the note can't be found for update anyways
            {
                return NotFound();
            }
        }
    }
}
