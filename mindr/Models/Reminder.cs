using System;

namespace mindr.Models
{
    /// <summary>
    /// Class for storing Reminder data
    /// </summary>
    class Reminder
    {
        //Title that discribes the reminder
        public string Title { get; set; }

        //The information about the reminder displayed in the list
        public string DisplayName
        {
            get
            {
                return string.Format("{0} {1} {2}", Title, Due.ToShortDateString(), Due.ToShortTimeString());
            }
        }
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
