﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestNotes.Controllers;
using RestNotes.Models;
using System;
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

            Assert.AreEqual(StatusCodes.Status201Created, actualResult.StatusCode);
        }

        [TestMethod()]
        public void PostNote_Return_Action_GetNote()
        {
            var expectedNote = new Note { Text = "Expected" };
            var notesContextMock = Mock.Of<INotesContext>(m => m.AddNote(It.IsAny<Note>()) == expectedNote);

            var notesController = new NotesController(notesContextMock);

            var actualResult = notesController.PostNote(new Note());

            Assert.AreEqual(nameof(NotesController.GetNote), actualResult.ActionName);
        }

        [TestMethod()]
        public void GetNote_WithValidId_Return_CorrespondingNote()
        {
            const int validId = 1;

            var expectedNote = new Note { Text = "Expected" };
            var notesContextMock = Mock.Of<INotesContext>(m => m.GetNote(validId) == expectedNote);

            var notesController = new NotesController(notesContextMock);

            var actualResult = notesController.GetNote(validId);

            Assert.AreSame(expectedNote, actualResult.Value);
        }

        [TestMethod()]
        public void GetNote_WhenContextThrowsException_Return_NotFound()
        {
            var notesContextMock = new Mock<INotesContext>(MockBehavior.Loose);
            notesContextMock.Setup(m => m.GetNote(It.IsAny<int>())).Throws<Exception>();

            var notesController = new NotesController(notesContextMock.Object);

            var actualResult = (NotFoundResult)notesController.GetNote(It.IsAny<int>()).Result;

            Assert.AreEqual(StatusCodes.Status404NotFound, actualResult.StatusCode);
        }
    }
}