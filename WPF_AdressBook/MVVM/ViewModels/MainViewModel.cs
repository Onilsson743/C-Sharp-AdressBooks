using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_AdressBook.Helpers;
using WPF_AdressBook.Services;

namespace WPF_AdressBook.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly AdressBook _AdressBook;
 

        public ICommand GoToContactsViewCommand { get; }
        public ICommand GoToAddContactViewCommand { get; }

        public MainViewModel(AdressBook AdressBook)
        {
            _AdressBook = AdressBook;
            
            _AdressBook.CurrentViewModelChanged += OnCurrentViewModelChanged;
            GoToContactsViewCommand = new NavigateCommand<ContactsViewModel>(AdressBook, () => new ContactsViewModel(_AdressBook));
            GoToAddContactViewCommand = new NavigateCommand<AddContactViewModel>(AdressBook, () => new AddContactViewModel(_AdressBook));
            
        }

        public ObservableObject CurrentViewModel => _AdressBook.CurrentViewModel;

        private void OnCurrentViewModelChanged() 
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }


    }
}
