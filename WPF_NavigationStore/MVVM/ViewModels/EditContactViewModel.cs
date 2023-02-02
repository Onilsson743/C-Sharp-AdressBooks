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


        public EditContactViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

        }
    }
}
