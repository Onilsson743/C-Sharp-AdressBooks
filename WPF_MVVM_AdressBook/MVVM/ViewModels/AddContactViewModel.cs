using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_AdressBook.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = "Add Contactss";
    }
}
