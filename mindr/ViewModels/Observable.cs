using System.ComponentModel;

namespace mindr.ViewModels
{
    /// <summary>
    /// Implementation of INotifyPropertyChanged
    /// </summary>
    class Observable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
