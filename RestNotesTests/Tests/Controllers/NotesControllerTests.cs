using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestNotes.Controllers;
using RestNotes.Models;
using System.Collections.Generic;

namespace RestNotesTests.Tests.Controllers
{
    [TestClass()]
    public class NotesControllerTests
    {
        [TestMethod()]
        public void GetNotes_Return_ListAllNotes_FromContext()
        {
            var expectedNotes = new[]
            {
                new Note{ Id = 1 },
                new Note{ Id = 2 }
            };

            var notesContextMock = Mock.Of<INotesContext>(m => m.ListAllNotes() == expectedNotes);

            var notesController = new NotesController(notesContextMock);

            var actualNotes = notesController.GetNotes();

            Assert.AreSame(expectedNotes, actualNotes);
        }

        [TestMethod()]
        public void PostNote_Return_Note_FromAddNote_AtContext()
        {
            var expectedNote = new Note { Text = "Expected" };
            var notesContextMock = Mock.Of<INotesContext>(m => m.AddNote(It.IsAny<Note>()) == expectedNote);

            var notesController = new NotesController(notesContextMock);

            var actualResult = notesController.PostNote(new Note());

            Assert.AreSame(expectedNote, actualResult.Value);
        }

        [TestMethod()]
        public void PostNote_Return_StatusCode201()
        {
            var expectedNote = new Note { Text = "Expected" };
            var notesContextMock = Mock.Of<INotesContext>(m => m.AddNote(It.IsAny<Note>()) == expectedNote);

            var notesController = new NotesController(notesContextMock);

            var actualResult = notesController.PostNote(new Note());

            Assert.AreEqual(201, actualResult.StatusCode);
        }
    }
}