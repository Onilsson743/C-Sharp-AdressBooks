using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
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
        public ICommand EditCommand { get; }
        public ICommand SetContactCommand { get; }
       
        public ContactsViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            GoToAddViewModelCommand = new NavigateCommand<AddContactViewModel>(navigationStore, () => new AddContactViewModel(_navigationStore));
            EditCommand = new NavigateCommand<EditContactViewModel>(navigationStore, () => new EditContactViewModel(_navigationStore)); 
            ContactList = ContactServices.GetList();
            contact = ContactServices.contact;
        }
    }
}
