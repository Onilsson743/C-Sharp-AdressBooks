using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_NavigationStore.Helpers;
using WPF_NavigationStore.Services;

namespace WPF_NavigationStore.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
 

        public ICommand GoToContactsViewCommand { get; }
        public ICommand GoToAddContactViewCommand { get; }

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            GoToContactsViewCommand = new NavigateCommand<ContactsViewModel>(navigationStore, () => new ContactsViewModel(_navigationStore));
            GoToAddContactViewCommand = new NavigateCommand<AddContactViewModel>(navigationStore, () => new AddContactViewModel(_navigationStore));
            
        }

        public ObservableObject CurrentViewModel => _navigationStore.CurrentViewModel;

        private void OnCurrentViewModelChanged() 
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }


    }
}
