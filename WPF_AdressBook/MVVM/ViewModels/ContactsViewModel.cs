using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WPF_AdressBook.Helpers;
using WPF_AdressBook.MVVM.Models;
using WPF_AdressBook.Services;

namespace WPF_AdressBook.MVVM.ViewModels
{
    public class ContactsViewModel : ObservableObject
    {
        private readonly AdressBook _AdressBook;
        public ObservableCollection<ContactModel> ContactList { get; }
        public ObservableCollection<ContactModel> contact { get; }
        public ICommand GoToAddViewModelCommand { get; }
        public ICommand GoToEditCommand { get; }

        public ContactsViewModel(AdressBook AdressBook)
        {
            _AdressBook = AdressBook;
            GoToAddViewModelCommand = new NavigateCommand<AddContactViewModel>(AdressBook, () => new AddContactViewModel(_AdressBook));
            GoToEditCommand = GoToEdit();
            ContactList = ContactServices.GetList();
            contact = ContactServices.contact;
        }

        public ICommand GoToEdit()
        {
            return new NavigateCommand<EditContactViewModel>(_AdressBook, () => new EditContactViewModel(_AdressBook));
        }
    }
}
