using mindr.Models;
using mindr.ViewModels;
using System.Windows.Controls;
using mindr.DAL;

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
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                //display information from selected reminder
                _viewmodel.ResetSelected((Reminder)e.AddedItems[0]);
            }
        }
    }
}
