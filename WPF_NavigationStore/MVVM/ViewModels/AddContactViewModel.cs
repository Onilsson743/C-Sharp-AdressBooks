using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_NavigationStore.Helpers;
using WPF_NavigationStore.MVVM.Models;
using WPF_NavigationStore.Services;
using System;
using System.ComponentModel;
using System.Data.Common;

namespace WPF_NavigationStore.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
       

        private readonly NavigationStore _navigationStore;


        public ObservableCollection<ContactModel> ContactList { get; }
        public ICommand CancelCommand { get; }

        public ContactModel contact { get; set; } = new ContactModel();

        public AddContactViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            ContactList = ContactServices.GetList();
            CancelCommand = Cancel();

        }
        private ICommand Cancel()
        {
            return new NavigateCommand<ContactsViewModel>(_navigationStore, () => new ContactsViewModel(_navigationStore));
        }
       
    }
}
