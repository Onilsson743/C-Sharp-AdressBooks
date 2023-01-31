using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using WPF_MVVM_AdressBook.MVVM.Models;
using WPF_MVVM_AdressBook.Services;

namespace WPF_MVVM_AdressBook.MVVM.ViewModels
{
    public partial class EditContactViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = "Ändra följande kontakt";

        [ObservableProperty]
        private ContactModel selectedContact = null!;

    }
}
