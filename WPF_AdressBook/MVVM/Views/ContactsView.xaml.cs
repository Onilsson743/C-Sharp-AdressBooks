using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_AdressBook.MVVM.Models;
using WPF_AdressBook.MVVM.ViewModels;
using WPF_AdressBook.Services;

namespace WPF_AdressBook.MVVM.Views
{
    /// <summary>
    /// Interaction logic for ContactsView.xaml
    /// </summary>
    public partial class ContactsView : UserControl
    {
        public ContactsView()
        {
            InitializeComponent();
        }

        private void button_Edit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var contact = (ContactModel)button.DataContext;

            ContactServices.editContact = contact;
        }
        private void button_Remove_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var contact = (ContactModel)button.DataContext;

            MessageBoxResult result = MessageBox.Show($"Är du säker på att du vill ta bort den här kontakten? \n \n{contact.DisplayAll}", "Radera kontakt", MessageBoxButton.YesNo);

            if (MessageBoxResult.Yes == result)
            {
                ContactServices.Remove(contact);
                MessageBox.Show("Kontakted Raderad!");
            }

        }

        private void ListView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var button = (Border)sender;
            var contact = (ContactModel)button.DataContext;
            ContactServices.contact.Clear();
            ContactServices.contact.Add(contact);
        }
    }
}
