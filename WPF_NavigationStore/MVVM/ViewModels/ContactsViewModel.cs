using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WPF_NavigationStore.Helpers;
using WPF_NavigationStore.MVVM.Models;
using WPF_NavigationStore.Services;

namespace WPF_NavigationStore.MVVM.ViewModels
{
    public class ContactsViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        public ObservableCollection<ContactModel> ContactList { get; }
        public ObservableCollection<ContactModel> contact { get; }
        public ICommand GoToAddViewModelCommand { get; }
        public ICommand GoToEditCommand { get; }

        public ContactsViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            GoToAddViewModelCommand = new NavigateCommand<AddContactViewModel>(navigationStore, () => new AddContactViewModel(_navigationStore));
            GoToEditCommand = GoToEdit();
            ContactList = ContactServices.GetList();
            contact = ContactServices.contact;
        }

        public ICommand GoToEdit()
        {
            return new NavigateCommand<EditContactViewModel>(_navigationStore, () => new EditContactViewModel(_navigationStore));
        }
    }
}
