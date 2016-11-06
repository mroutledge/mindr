﻿using mindr.Models;
using mindr.ViewModels;
using System.Windows.Controls;

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
            _viewmodel = (Presenter)base.DataContext;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                _viewmodel.ResetSelected((Reminder)e.AddedItems[0]);
            }
        }
    }
}
