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
        private readonly ContactServices _contactServices;
        

        public ICommand GoToContactsViewCommand { get; }
        public ICommand GoToAddContactViewCommand { get; }

        public MainViewModel(NavigationStore navigationStore, ContactServices contactServices)
        {
            _navigationStore = navigationStore;
            _contactServices = contactServices;
            _contactServices.ReadList();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            GoToContactsViewCommand = new NavigateCommand<ContactsViewModel>(navigationStore, () => new ContactsViewModel(_navigationStore, _contactServices));
            GoToAddContactViewCommand = new NavigateCommand<AddContactViewModel>(navigationStore, () => new AddContactViewModel(_navigationStore, _contactServices));
            
        }

        public ObservableObject CurrentViewModel => _navigationStore.CurrentViewModel;

        private void OnCurrentViewModelChanged() 
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }


    }
}
