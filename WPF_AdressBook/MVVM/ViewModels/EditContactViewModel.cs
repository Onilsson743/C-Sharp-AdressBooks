using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using WPF_AdressBook.Helpers;
using WPF_AdressBook.Services;

namespace WPF_AdressBook.MVVM.ViewModels
{
    public class EditContactViewModel : ObservableObject
    {
        private readonly AdressBook _AdressBook;

        
        public string title { get; set; } = "Ändra kontakt";
        public string firstName { get; set; } = ContactServices.editContact.FirstName;
        public string lastName { get; set; } = ContactServices.editContact.LastName;
        public string email { get; set; } = ContactServices.editContact.Email;
        public string phoneNumber { get; set; } = ContactServices.editContact.PhoneNumber;
        public string adress { get; set; } = ContactServices.editContact.Address;
        public ICommand UpdateCommand { get; }



        public EditContactViewModel(AdressBook AdressBook)
        {
            _AdressBook = AdressBook;
            UpdateCommand = Update();
        }

        private ICommand Update()
        {
            return new NavigateCommand<ContactsViewModel>(_AdressBook, () => new ContactsViewModel(_AdressBook));
        }
    }
}
