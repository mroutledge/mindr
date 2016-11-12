﻿using mindr.DAL;
using mindr.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.Threading.Tasks;

namespace mindr.ViewModels
{
    /// <summary>
    /// Viewmodel for the mindr Control
    /// </summary>
    class Presenter : Observable
    {
        /// <summary>
        /// Current List of reminders
        /// </summary>
        private ObservableCollection<Reminder> _reminders = new ObservableCollection<Reminder>();
        public IEnumerable<Reminder> Reminders
        {
            get { return _reminders; }
            set
            {
                foreach (var item in value)
                {
                    if (!_reminders.Contains(item))
                    {
                        _reminders.Add(item);
                        SetTimer(item);
                    }
                }
            }
        }

        /// <summary>
        /// Reminder that is selected in the GUI
        /// </summary>
        private Reminder _selected = new Reminder("Add Text Here", "Add Message Here", DateTime.Now);
        public Reminder Selected
        {
            get { return _selected; }
            set { _selected = value; }
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
            if (_selected.IsValid)
            {
                Reminder minder = new Reminder(_selected.Title, _selected.Message, _selected.Due);
                _reminders.Add(minder);
                SetTimer(minder);
                ResetSelected();
            }
        }

        public ICommand RemoveReminderCommand
        {
            get { return new DelegateCommand(DeleteReminder); }
        }

        /// <summary>
        /// Removes the selected Reminder from the list of reminders
        /// </summary>
        private void DeleteReminder()
        {
            if (_reminders.Contains(Selected))
            {
                _reminders.Remove(Selected);
                ResetSelected();
            }
        }

        /// <summary>
        /// Resets Select to default values
        /// </summary>
        public void ResetSelected()
        {
            Selected = new Reminder("", "", DateTime.Now);
            ObjectPersistence.SaveReminders(Reminders);
        }

        /// <summary>
        /// Reset Select Reminder to passed Reminder
        /// </summary>
        /// <param name="minder"></param>
        public void ResetSelected(Reminder minder)
        {
            Selected = minder;
            RaisePropertyChangedEvent("Selected");
            ObjectPersistence.SaveReminders(Reminders);
        }

        private void SetTimer(Reminder minder)
        {
            TimeSpan ts = minder.Due - DateTime.Now;
            Task.Delay(ts).ContinueWith(x => DisplayReminder(minder));
        }

        private void DisplayReminder(Reminder minder)
        {
            MessageBoxResult result = MessageBox.Show(minder.Message, "REMINDER -" + minder.Title);
        }

    }
}
