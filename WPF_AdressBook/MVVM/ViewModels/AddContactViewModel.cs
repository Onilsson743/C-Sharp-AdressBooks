using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_AdressBook.Helpers;
using WPF_AdressBook.MVVM.Models;
using WPF_AdressBook.Services;
using System;
using System.ComponentModel;
using System.Data.Common;

namespace WPF_AdressBook.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
       

        private readonly AdressBook _AdressBook;


        public ObservableCollection<ContactModel> ContactList { get; }
        public ICommand CancelCommand { get; }

        public ContactModel contact { get; set; } = new ContactModel();

        public AddContactViewModel(AdressBook AdressBook)
        {
            _AdressBook = AdressBook;

            ContactList = ContactServices.GetList();
            CancelCommand = Cancel();

        }
        private ICommand Cancel()
        {
            return new NavigateCommand<ContactsViewModel>(_AdressBook, () => new ContactsViewModel(_AdressBook));
        }
       
    }
}
