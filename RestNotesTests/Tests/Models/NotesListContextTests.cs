using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestNotes.Models;
using System;
using System.Linq;

namespace RestNotesTests.Tests.Models
{
    [TestClass()]
    public class NotesListContextTests
    {
        [TestMethod()]
        public void GivenNewNotesListContext_GetNotes_ShouldReturnEmptyCollection()
        {
            var expectedEmpty = Array.Empty<Note>();

            var context = new NotesListContext();

            var actualNotes = context.ListAllNotes();

            CollectionAssert.AreEqual(expectedEmpty, actualNotes.ToList());
        }

        [TestMethod]
        public void GivenNewNotesListContext_AddNote_ShouldAddTheNote_SoThatGetNotesReturnsIt()
        {
            var expectedNote = new Note();

            var context = new NotesListContext();

            context.AddNote(expectedNote);

            var actualNotes = context.ListAllNotes();

            CollectionAssert.Contains(actualNotes.ToList(), expectedNote);
        }

        [TestMethod]
        public void GivenNewNotesListContext_AddNote_ShouldReturnTheNoteWithIdPropertyEquals1()
        {
            var expectedNote = new Note();

            var context = new NotesListContext();

            var actualNote = context.AddNote(expectedNote);

            Assert.AreEqual(1, actualNote.Id);
        }
    }
}