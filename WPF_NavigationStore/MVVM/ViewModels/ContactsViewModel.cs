using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_NavigationStore.Helpers;
using WPF_NavigationStore.MVVM.Models;
using WPF_NavigationStore.Services;

namespace WPF_NavigationStore.MVVM.ViewModels
{
    public class ContactsViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        private readonly ContactServices _contactServices;

        public ObservableCollection<ContactModel> ContactList { get; }
        public ICommand GoToAddViewModelCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand RemoveCommand { get; }


        public ContactModel SelectedContact = null!;


        public ContactsViewModel(NavigationStore navigationStore, ContactServices contactServices)
        {
            _navigationStore = navigationStore;
            _contactServices = contactServices;
            ContactList = _contactServices.GetList();

            GoToAddViewModelCommand = new NavigateCommand<AddContactViewModel>(navigationStore, () => new AddContactViewModel(_navigationStore, _contactServices));
            EditCommand = new NavigateCommand<EditContactViewModel>(navigationStore, () => new EditContactViewModel(_navigationStore, _contactServices));
            RemoveCommand = Remove();
            
        }

        private ICommand Remove()
        {
            //_contactServices.Remove();
            return new NavigateCommand<ContactsViewModel>(_navigationStore, () => new ContactsViewModel(_navigationStore, _contactServices)); ;
        }




    }
}
