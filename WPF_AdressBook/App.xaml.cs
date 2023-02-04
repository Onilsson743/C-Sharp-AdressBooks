using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_AdressBook.MVVM.ViewModels;
using WPF_AdressBook.Services;

namespace WPF_AdressBook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost app { get; private set; }

        public App()
        {
            app = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddSingleton<AdressBook>();
                
            }).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var AdressBook = app.Services.GetRequiredService<AdressBook>();
            ContactServices.ReadList();            
            AdressBook.CurrentViewModel = new ContactsViewModel(AdressBook);

            app.Start();

            var MainWindow = app.Services.GetRequiredService<MainWindow>();
            MainWindow.DataContext = new MainViewModel(AdressBook);
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
