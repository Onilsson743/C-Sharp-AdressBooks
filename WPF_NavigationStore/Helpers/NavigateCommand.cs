using System;
using WPF_NavigationStore.MVVM.ViewModels;
using WPF_NavigationStore.Services;

namespace WPF_NavigationStore.Helpers
{
    public class NavigateCommand<T> : BaseCommand where T : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<T> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<T> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
