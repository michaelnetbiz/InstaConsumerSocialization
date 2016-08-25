using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace InstaConsumerSocialization
{
    /// <summary>
    /// Data to represent an item in the nav menu.
    /// </summary>
    public class PaneItem : INotifyPropertyChanged
    {
        public string Label { get; set; }

        public Symbol Symbol { get; set; }

        public char SymbolAsChar
        {
            get
            {
                return (char)this.Symbol;
            }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                SelectedVis = value ? Visibility.Visible : Visibility.Collapsed;
                this.OnPropertyChanged("IsSelected");
            }
        }

        private void OnPropertyChanged(string v)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(v));
        }

        private Visibility _selectedVis = Visibility.Collapsed;

        public Visibility SelectedVis {
            get
            {
                return _selectedVis;
            }
            set
            {
                _selectedVis = value;
                this.OnPropertyChanged("SelectedVis");
            }
        }

        public Type DestPage { get; set; }

        public object Arguments { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
