using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WPF_MVVM_AdressBook.MVVM.ViewModels
{
    partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel = new ContactsViewModel();

        [RelayCommand]
        private void GoToAddContactViewModel() => CurrentViewModel = new AddContactViewModel();

        [RelayCommand]
        private void GoToContactsViewModel() => CurrentViewModel = new ContactsViewModel();

        [RelayCommand]
        private void Test() => CurrentViewModel = new EditContactViewModel();
    }
}
