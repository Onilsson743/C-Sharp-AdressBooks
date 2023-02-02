using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using WPF_MVVM_AdressBook.MVVM.Models;
using WPF_MVVM_AdressBook.Services;

namespace WPF_MVVM_AdressBook.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = "Lägg till en ny kontakt";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contactList = ContactServices.GetList();
        
    }
}
