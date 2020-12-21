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
            var expectedNotes = new []
            {
                new Note{ Id = 1 },
                new Note{ Id = 2 }
            };

            var notesContextMock = Mock.Of<INotesContext>(m => m.ListAllNotes() == expectedNotes);

            var notesController = new NotesController(notesContextMock);

            var actualNotes = notesController.GetNotes();

            Assert.AreSame(expectedNotes, actualNotes);
        }
    }
}