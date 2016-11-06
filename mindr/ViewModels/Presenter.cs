using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mindr.Models;

namespace mindr.ViewModels
{
    class Presenter
    {
        public IEnumerable<Reminder> Reminders
        {
            get;set;
        }

        private Reminder NextDue
        {
            get
            {
                return Reminders.OrderByDescending(x => x.Due).FirstOrDefault();
            }
        }

        public string Title
        {
            get
            {
                return NextDue.Title;
            }
        }
    }
}
