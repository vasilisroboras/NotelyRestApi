using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotelyRestApi.Models;
using NotelyRestApi.Repositories;

namespace NotelyRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpGet(template: "{id}")]

        public ActionResult<Note> GetNote(long id)
        {

            var note = _noteRepository.FindNoteById(id);
            return note;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetNotes()
        {
            var notes = _noteRepository.GetAllNotes().ToList();
            return notes;
        }

        [HttpPost]

        public ActionResult<Note> SaveNote(Note note)
        {
            var currentDate = DateTime.Now;
            note.CreatedDate = currentDate;
            note.LastModifiedDate = currentDate;
            _noteRepository.SaveNote(note);
            return note;
        }

        [HttpPut]
        public ActionResult<Note> PutNote(Note note)
        {
            var currentDate = DateTime.Now;
            note.LastModifiedDate = currentDate;
            _noteRepository.EditNote(note);
            return note;

        }

        [HttpDelete(template:"{id}")]
        public ActionResult<Note> DeleteNote(long id)
        {
            var note = _noteRepository.FindNoteById(id);
            _noteRepository.DeleteNote(note);
            return note;
        }
    }
}
