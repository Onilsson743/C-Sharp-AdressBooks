using System;
using WPF_AdressBook.MVVM.ViewModels;
using WPF_AdressBook.Services;

namespace WPF_AdressBook.Helpers
{
    public class NavigateCommand<T> : BaseCommand where T : ObservableObject
    {
        private readonly AdressBook _AdressBook;
        private readonly Func<T> _createViewModel;

        public NavigateCommand(AdressBook AdressBook, Func<T> createViewModel)
        {
            _AdressBook = AdressBook;
            _createViewModel = createViewModel;
        }

        public override void Execute(object? parameter)
        {
            _AdressBook.CurrentViewModel = _createViewModel();
        }
    }
}
