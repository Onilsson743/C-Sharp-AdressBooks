using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WPF_MVVM_AdressBook.MVVM.Models;
using WPF_MVVM_AdressBook.Services;

namespace WPF_MVVM_AdressBook.MVVM.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = "Alla kontakter";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contactList = ContactServices.GetList();

        [ObservableProperty]
        public ContactModel selectedContact = null!;

   

    }
}
