using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mindr.Models
{
    /// <summary>
    /// Class for storing Reminder data
    /// </summary>
    class Reminder
    {
        //Title that discribes the reminder
        public string Title { get; set; }
        //Discription of the reminder
        public string Message { get; set; }
        //When the reminder was created
        public DateTime Created { get; set; }
        //When the reminder is due
        public DateTime Due { get; set; }

        /// <summary>
        /// Checks if title is blank and that the due date hasn't passed
        /// </summary>
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
