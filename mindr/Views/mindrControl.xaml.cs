using mindr.DAL;
using mindr.Models;
using mindr.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace mindr.Views
{
    /// <summary>
    /// Interaction logic for mindrControl.xaml
    /// </summary>
    public partial class mindrControl : UserControl
    {
        Presenter _viewmodel;
        public mindrControl()
        {
            InitializeComponent();
            _viewmodel = (Presenter)DataContext;
            _viewmodel.Reminders = ObjectPersistence.LoadReminders();
            //todo set timer for remindres
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                //display information from selected reminder
                _viewmodel.ResetSelected((Reminder)e.AddedItems[0]);
            }
        }


        private void SetTimer(Reminder minder)
        {
            TimeSpan ts = minder.Due - DateTime.Now;
            if (ts.TotalSeconds > 0)
            {
                Task.Delay(ts).ContinueWith(x => DisplayReminder(minder));
                Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)RemoveItem);
            }
        }

        private void RemoveItem()
        {
            _viewmodel.DeleteReminder();
        }

        private void DisplayReminder(Reminder minder)
        {
            MessageBoxResult result = MessageBox.Show(minder.Message + "\nSNOOZE?", "REMINDER -" + minder.Title, MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                minder.Due = new DateTime(minder.Due.Year, minder.Due.Month, minder.Due.Day, minder.Due.Hour, minder.Due.Minute + 9, minder.Due.Second);
                SetTimer(minder);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            SetTimer(_viewmodel.Selected);
        }

        private void ListBox_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var unboxedSender = (ListBox)sender;
            HitTestResult hr = VisualTreeHelper.HitTest(this, e.GetPosition(this));
            var hitType = hr.VisualHit.GetType();
            if (hitType != typeof(TextBlock))
            {
                ReminderListBox.SelectedItem = null;
                _viewmodel.ResetSelected();
            }
                
        }
    }
}
