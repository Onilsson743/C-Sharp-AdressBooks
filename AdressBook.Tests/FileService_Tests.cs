using _00_ConsoleApp.Models;
using _00_ConsoleApp.Services;
using Newtonsoft.Json;

namespace AdressBook.Tests
{
    public class FileService_Tests
    {
        private ContactInfo contactInfo = new ContactInfo() 
        {
            FirstName = "Firstname",
            LastName = "Lastname",
            Email = "email@domain.com",
            PhoneNumber = "070-1234567",
            Address = "Adress"
        };

        private FileService fileService = new FileService();

        [Fact]
        public void Save_One_Contact_And_Create_JSON_File_Containing_The_List()
        {
            //Act
            //Saves a contact to the list and creates a JSON file
            fileService.SaveToList(contactInfo);


            //Assert
            //Checks if list contains the added contact
            Assert.Contains(contactInfo, fileService.PersonList);
            
            //Checks if file exists
            Assert.True(File.Exists(fileService.FilePath));
        }
    }
}