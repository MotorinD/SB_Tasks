using System;

namespace Task10
{
    public class MessageModel
    {
        public long Id { get; private set; }

        public string Text { get; private set; }

        public DateTime Date { get; private set; }

        public string FullName { get; private set; }

        public MessageModel(long id, string text, DateTime date, string fullName)
        {
            this.Id = id;
            this.Text = text;
            this.Date = date;
            this.FullName = fullName;
        }
    }
}
