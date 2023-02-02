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
using WPF_NavigationStore.MVVM.ViewModels;
using WPF_NavigationStore.Services;

namespace WPF_NavigationStore.MVVM.Views
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
