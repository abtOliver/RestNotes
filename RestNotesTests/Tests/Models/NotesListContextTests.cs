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
    }
}