using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_AdressBook.MVVM.Models;
using WPF_MVVM_AdressBook.Services;

namespace WPF_MVVM_AdressBook.MVVM.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = "Testar";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contactList = ContactServices.GetList();

        [ObservableProperty]
        public ContactModel selectedContact = null!;
        
    }
}
