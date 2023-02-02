using System;
using System.Collections.Generic;
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
using WPF_NavigationStore.MVVM.Models;
using WPF_NavigationStore.Services;

namespace WPF_NavigationStore.MVVM.Views
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


            ContactServices.contact.Add(contact);
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
