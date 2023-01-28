using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_AdressBook.MVVM.Models;

namespace WPF_MVVM_AdressBook.MVVM.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = "Contacts";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contactList = new ObservableCollection<ContactModel>()
        {
            new ContactModel() {FirstName="Oscar", LastName="Nilsson", Email = "O.nilsson743@gmail.com"},
            new ContactModel() {FirstName="Clara", LastName="Ekman", Email = "Clara.ekman37@gmail.com"},
        };
    }
}
