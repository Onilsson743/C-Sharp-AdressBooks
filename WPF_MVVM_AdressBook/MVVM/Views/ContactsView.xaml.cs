using System.Windows;
using System.Windows.Controls;
using WPF_MVVM_AdressBook.MVVM.Models;
using WPF_MVVM_AdressBook.MVVM.ViewModels;

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

            //MessageBoxResult removebox = MessageBox.Show("Remove Contact", "Test", MessageBoxButton.YesNo);
            MessageBoxResult result = MessageBox.Show($"Are you sure you want to remove this contact? \n{contact.DisplayName}", "Remove Contact", MessageBoxButton.YesNo);

            if (MessageBoxResult.Yes == result)
            {
                MessageBox.Show("Contact succesfully removed!");
            }
            //MessageBox.Show(removebox.ToString());
        }
    }
}
