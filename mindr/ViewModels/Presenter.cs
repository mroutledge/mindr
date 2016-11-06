using mindr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace mindr.ViewModels
{
    class Presenter
    {
        private ObservableCollection<Reminder> _reminders = new ObservableCollection<Reminder>();
        public IEnumerable<Reminder> Reminders
        {
            get { return _reminders; }
        }

        private Reminder _selected = new Reminder("Add Text Here", "Add Message Here", DateTime.Now);
        public Reminder Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        private Reminder NextDue
        {
            get
            {
                return Reminders?.OrderByDescending(x => x.Due).FirstOrDefault();
            }
        }

        public string Title
        {
            get
            {
                return NextDue?.Title ?? "none yet";
            }
        }

        public ICommand AddReminderCommand
        {
            get { return new DelegateCommand(AddReminder); }
        }

        /// <summary>
        /// Add reminder to list if it's vaild and not already in the list
        /// </summary>
        private void AddReminder()
        {
            if (_selected.IsValid && !_reminders.Contains(_selected))
            {
                _reminders.Add(_selected);
            }
        }
    }
}
