using System.Windows;
using WPF_MVVM_AdressBook.MVVM.ViewModels;
using WPF_MVVM_AdressBook.Services;

namespace WPF_MVVM_AdressBook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ContactServices.ReadList();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };

            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
