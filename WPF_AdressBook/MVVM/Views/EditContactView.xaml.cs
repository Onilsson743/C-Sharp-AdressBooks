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
using WPF_AdressBook.MVVM.Models;
using WPF_AdressBook.Services;

namespace WPF_AdressBook.MVVM.Views
{
    /// <summary>
    /// Interaction logic for EditContactView.xaml
    /// </summary>
    public partial class EditContactView : UserControl
    {
        public EditContactView()
        {
            InitializeComponent();
        }
        

        private void button_Update_Contact_Click(object sender, RoutedEventArgs e)
        {
            ContactServices.Update(new ContactModel
            {
                FirstName = tb_FirstName.Text,
                LastName = tb_LastName.Text,
                Email = tb_Email.Text,
                PhoneNumber = tb_PhoneNumber.Text,
                Address = tb_Address.Text,
            });
        }
    }
}
