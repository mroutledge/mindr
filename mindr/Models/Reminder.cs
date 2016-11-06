using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mindr.Models
{
    class Reminder
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public DateTime Due { get; set; }

        public bool IsValid
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Title) && DateTime.Compare(Due, DateTime.Now) > 0;
            }
        }

        public Reminder(string title, string message, DateTime due)
        {
            Title = title;
            Message = message;
            Created = DateTime.Now;
            Due = due;
        }
    }
}
