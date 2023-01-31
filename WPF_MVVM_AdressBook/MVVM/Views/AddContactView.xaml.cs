using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using WPF_MVVM_AdressBook.MVVM.Models;
using WPF_MVVM_AdressBook.MVVM.ViewModels;
using WPF_MVVM_AdressBook.Services;

namespace WPF_MVVM_AdressBook.MVVM.Views
{
    /// <summary>
    /// Interaction logic for AddContactView.xaml
    /// </summary>
    public partial class AddContactView : UserControl
    {
        public AddContactView()
        {
            InitializeComponent();
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            ContactServices.Add(new ContactModel
            {
                FirstName = tb_FirstName.Text,
                LastName = tb_LastName.Text,
                Email = tb_Email.Text,
                PhoneNumber = tb_PhoneNumber.Text,
                Address = tb_Address.Text,
            });
            ClearForm();
        }

        private void ClearForm()
        {
            tb_FirstName.Text = string.Empty;
            tb_LastName.Text = string.Empty;
            tb_Email.Text = string.Empty;
            tb_PhoneNumber.Text = string.Empty;
            tb_Address.Text = string.Empty;
        }
    }
}
