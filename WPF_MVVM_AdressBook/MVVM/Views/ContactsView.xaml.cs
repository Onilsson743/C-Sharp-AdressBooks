using System.Windows;
using System.Windows.Controls;
using WPF_MVVM_AdressBook.MVVM.Models;
using WPF_MVVM_AdressBook.MVVM.ViewModels;
using WPF_MVVM_AdressBook.Services;

namespace WPF_MVVM_AdressBook.MVVM.Views
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
        }
        private void button_Remove_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var contact = (ContactModel)button.DataContext;

            MessageBoxResult result = MessageBox.Show($"Är du säker på att du vill ta bort den här kontakten? \n \n{contact.DisplayAll}", "Radera kontakt", MessageBoxButton.YesNo);

            if (MessageBoxResult.Yes == result)
            {
                ContactServices.Remove(contact);
                MessageBox.Show("Contact removed!");
            }
            
        }
    }
}
