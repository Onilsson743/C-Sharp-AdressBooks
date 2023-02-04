using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_AdressBook.MVVM.ViewModels;

namespace WPF_AdressBook.Services
{
    public class AdressBook
    {
        public event Action? CurrentViewModelChanged;

        private ObservableObject? _currentViewModel;
        public ObservableObject? CurrentViewModel
        {
            get { return _currentViewModel; }
            set 
            { 
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
