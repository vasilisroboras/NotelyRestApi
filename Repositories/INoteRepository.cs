﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotelyRestApi.Models;

namespace NotelyRestApi.Repositories
{
    public interface INoteRepository
    {
        Note FindNoteById(long id);
        IEnumerable<Note> GetAllNotes();
        void SaveNote(Note noteModel);
        void EditNote(Note noteModel);
        void DeleteNote(Note noteModel);
    }
}
