using System;
using TIA_Selection_Tool.Core;

namespace TIA_Selection_Tool.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand MenuViewCommand { get; set; }
        public RelayCommand ContentViewCommand { get; set; }

        public MenuViewModel MenuVM { get; set; }
        public ContentViewModel ContentVM { get; set; }

        private object _menuView;
        public object MenuView
        {
            get { return _menuView; }
            set 
            {
                _menuView = value;
                OnPropertyChanged();
            }
        }

        private object _contentView;
        public object ContentView
        {
            get { return _contentView; }
            set
            {
                _contentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel() 
        {
            MenuVM = new MenuViewModel();
            ContentVM = new ContentViewModel();

            MenuView = MenuVM;

            MenuViewCommand = new RelayCommand(o =>
            {
                MenuView = MenuVM;
            });

            ContentViewCommand = new RelayCommand(o =>
            {
                ContentView = ContentVM;
            });
        }
    }
}
