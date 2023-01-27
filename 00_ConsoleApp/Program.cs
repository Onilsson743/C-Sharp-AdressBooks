using _00_ConsoleApp.Models;
using _00_ConsoleApp.Services;

//Sets title of the console
Console.Title = "Adress Book";

//Sets the color of the text
Console.ForegroundColor = ConsoleColor.Black;

//Sets the color of the background
Console.BackgroundColor = ConsoleColor.White;


MainMenu menu = new MainMenu();
FileService service = new FileService();

ContactInfo contactInfo = new ContactInfo()
{
    FirstName = "Firstname",
    LastName = "Lastname",
    Email = "email@domain.com",
    PhoneNumber = "070-1234567",
    Address = "Adress"
};

var contactList = new List<ContactInfo> { contactInfo };
service.SaveListToJson(contactList);
service.ReadList();

foreach (ContactInfo person in contactList)
{
    DisplayContactInfo.WriteInfo(person);
}
Console.ReadKey();
foreach (ContactInfo person in service.PersonList)
{
    DisplayContactInfo.WriteInfo(person);
}
Console.ReadKey();

//while (true)
//{
//    Console.Clear();
//    menu.MenuOptions();
//}