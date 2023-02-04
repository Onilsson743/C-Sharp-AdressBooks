using System.Collections.ObjectModel;
using WPF_AdressBook.MVVM.Models;
using WPF_AdressBook.MVVM.ViewModels;
using WPF_AdressBook.Services;

namespace Wpf_Adressbook.Tests
{
    public class UnitTest1
    {
        private ContactModel contact = new ContactModel()
        {
            FirstName = "Firstname",
            LastName = "Lastname",
            Email = "email@domain.com",
            PhoneNumber = "070-1234567",
            Address = "Adress"
        };

        [Fact]
        public void Add_Contact_And_Save_To_List()
        {
            //Arrange
            ContactServices.contacts = new ObservableCollection<ContactModel>();
            ContactServices.Add(contact);


            //Act
            ContactServices.ReadList();

            //Assert
            Assert.Single(ContactServices.contacts);

        }
    }
}