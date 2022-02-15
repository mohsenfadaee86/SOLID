using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.NoteBookSample.Before
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
    public class NoteBook
    {
        public List<Note> Notes;
        public string Password { get; set; }

        public Theme Theme { get; set; }

        public int fontSize { get; set; }
        public NoteBook()
        {
            Notes = new List<Note>();
            Password = "";
            Theme = Theme.Light;
            fontSize = 14;
        }

        public void CreateNewNote(string text = "")
        {
            Note note = new Note();
            note.Text = text;
            note.Id = new Guid();
            Notes.Add(note);
        }

        public void DeleteAllNote()
        {
            Notes.Clear();
        }
        public void DeleteNote(Guid noteId)
        {
            Note? targetNote = Notes.Find(match: note => note.Id == noteId);
            if (targetNote != null)
                Notes.Remove(targetNote);
        }

        public string getNoteText(Guid noteId)
        {
            Note? targetNote = Notes.Find(match: note => note.Id == noteId);
            if (targetNote != null)
                return targetNote.Text;
            return "";
        }

        public void editNoteText(Guid noteId, string newText)
        {
            int index = Notes.FindIndex(n => n.Id == noteId);
            if (index != -1)
            {
                Note targetNote = new Note();
                targetNote.Id = noteId;            
                targetNote.Text = newText;
                Notes[index] = targetNote;
            }
        }

        public void ChangePassword(string newPassword)
        {
            if (newPassword.Length >= 8 && newPassword.Length <= 32)
            {
                this.Password = newPassword;
            }
        }
        public void ToggleTheme()
        {
            if (Theme == Theme.Dark)
            {
                Theme = Theme.Light;
            }
            else
            {
                Theme = Theme.Dark;
            }
        }

        public void ChangeFontsize(int newFontSize)
        {
            if (newFontSize < 8)
            {
                fontSize = 8;
            }
            else if (newFontSize > 60)
            {
                fontSize = 60;
            }
            else
            {
                fontSize = newFontSize;
            }
        }

    }

    public enum Theme
    {
        Light,
        Dark
    }
}
