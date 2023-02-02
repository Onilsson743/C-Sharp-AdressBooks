using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_NavigationStore.Helpers;
using WPF_NavigationStore.MVVM.Models;
using WPF_NavigationStore.Services;
using System;
using System.ComponentModel;
using System.Data.Common;

namespace WPF_NavigationStore.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
       

        private readonly NavigationStore _navigationStore;
        private readonly ContactServices _contactServices;


        private string firstName;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;











        public ObservableCollection<ContactModel> ContactList { get; }
        public ICommand CancelCommand { get; }
        public ICommand AddCommand { get; }

        public ContactModel contact { get; set; } = new ContactModel();

        public AddContactViewModel(NavigationStore navigationStore, ContactServices contactService)
        {
            _navigationStore = navigationStore;
            _contactServices= contactService;

            CancelCommand = Cancel();
            AddCommand = AddContact();
            _contactServices.ReadList();
            ContactList = _contactServices.GetList();
        }

        private ICommand AddContact()
        {
            FirstName = firstName;
            _contactServices.Add(new ContactModel
            {
                FirstName = FirstName,
                LastName = FirstName,
                Email = FirstName,
                PhoneNumber = FirstName,
                Address = FirstName,
            });
            return new NavigateCommand<AddContactViewModel>(_navigationStore, () => new AddContactViewModel(_navigationStore, _contactServices));
        }
        private ICommand Cancel()
        {
            return new NavigateCommand<ContactsViewModel>(_navigationStore, () => new ContactsViewModel(_navigationStore, _contactServices));
        }
       
    }
}
