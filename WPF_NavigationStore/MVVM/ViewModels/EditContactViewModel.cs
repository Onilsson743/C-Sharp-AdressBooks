using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_NavigationStore.Services;

namespace WPF_NavigationStore.MVVM.ViewModels
{
    public class EditContactViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        private readonly ContactServices _contactServices;

        public EditContactViewModel(NavigationStore navigationStore, ContactServices contactServices)
        {
            _navigationStore = navigationStore;
            _contactServices = contactServices;
        }
    }
}
