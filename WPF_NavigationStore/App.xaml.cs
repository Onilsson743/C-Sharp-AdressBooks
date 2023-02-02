﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_NavigationStore.MVVM.ViewModels;
using WPF_NavigationStore.Services;

namespace WPF_NavigationStore
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
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<ContactServices>();
            }).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var navigationStore = app.Services.GetRequiredService<NavigationStore>();
            var contactServices = app.Services.GetRequiredService<ContactServices>();
            navigationStore.CurrentViewModel = new ContactsViewModel(navigationStore, contactServices);

            app.Start();

            var MainWindow = app.Services.GetRequiredService<MainWindow>();
            MainWindow.DataContext = new MainViewModel(navigationStore, contactServices);
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
