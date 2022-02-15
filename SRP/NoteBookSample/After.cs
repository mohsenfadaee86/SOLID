using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.NoteBookSample.After
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public Note(string text)
        {
            Id = new Guid();
            Text = text;
        }
        public string getText()
        {
            return Text;
        }
        public void EditText(string newText)
        {
            Text = newText;
        }
    }

    public class Setting
    {
        private string? Password { get; set; }

        private Theme Theme { get; set; }

        private int fontSize { get; set; }

        public Setting()
        {
            Password = null;
            Theme = Theme.Dark;
            fontSize = 14;

        }
        private bool ValidatedPassword(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }
            else if (password.Length > 32)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ChangePassword(string newPassword)
        {
            if (ValidatedPassword(newPassword))
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

    public class NoteBook
    {
        private List<Note> Notes;
        private Setting setting;
        public NoteBook()
        {
            Notes = new List<Note>();
            setting = new Setting();
        }
        public void CreateNewNote(Note newnote)
        {
        
            Notes.Add(newnote);
        }
        public void DeleteAllNote()
        {
            Notes.Clear();
        }

        public void DeleteNote(Guid noteId)
        {
            Note targetNote = getNoteById(noteId);
            if (targetNote != null)
                Notes.Remove(targetNote);
        }

        public Note? getNoteById(Guid noteId)
        {
            return Notes.Find(match: note => note.Id == noteId);
           
        }
    }

    public enum Theme
    {
        Light,
        Dark
    }
}
