using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mindr.Models;

namespace mindr.ViewModels
{
    class ReminderViewModel
    {
        public Reminder Minder { get; set; }

        public string Title
        {
            get { return Minder.Title; }
            set { Minder.Title = value; }
        }

        public string Message
        {
            get { return Minder.Message; }
            set { Minder.Message = value; }
        }

        public DateTime Created
        {
            get { return Minder.Created; }
            set { Minder.Created = value; }
        }

        public DateTime Due
        {
            get { return Minder.Due; }
            set { Minder.Due = value; }
        }
    }
}
