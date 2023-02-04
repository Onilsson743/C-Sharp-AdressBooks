using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using WPF_NavigationStore.Helpers;
using WPF_NavigationStore.Services;

namespace WPF_NavigationStore.MVVM.ViewModels
{
    public class EditContactViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;

        
        public string title { get; set; } = "Ändra kontakt";
        public string firstName { get; set; } = ContactServices.editContact.FirstName;
        public string lastName { get; set; } = ContactServices.editContact.LastName;
        public string email { get; set; } = ContactServices.editContact.Email;
        public string phoneNumber { get; set; } = ContactServices.editContact.PhoneNumber;
        public string adress { get; set; } = ContactServices.editContact.Address;
        public ICommand UpdateCommand { get; }



        public EditContactViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            UpdateCommand = Update();
        }

        private ICommand Update()
        {
            return new NavigateCommand<ContactsViewModel>(_navigationStore, () => new ContactsViewModel(_navigationStore));
        }
    }
}
