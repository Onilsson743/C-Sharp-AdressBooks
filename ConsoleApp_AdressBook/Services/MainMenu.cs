using _00_ConsoleApp.Interfaces;
using _00_ConsoleApp.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace _00_ConsoleApp.Services;

internal class MainMenu
{

    

    private FileService file = new();

    public void MenuOptions()
    {
        Console.WriteLine("" +
            "1. Skapa en kontakt\n" +
            "2. Visa alla kontakter \n" +
            "3. Visa en specifik kontakt\n" +
            "4. Ta bort en specifik kontakt\n" +
            "\nVälj ett av alternativen ovan (1-4): ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1": CreateNewContact(); break;
            case "2": ShowAllContacts(); break;
            case "3": ShowOneContact(); break;
            case "4": RemoveOneContact(); break;
        }
    }
    private void CreateNewContact()
    {
        Console.Clear();
        Console.WriteLine("Skapa en ny kontakt.");
        ContactInfo person = new ContactInfo();

        Console.WriteLine("Ange förnamn: ");
        person.FirstName = Console.ReadLine() ?? "";

        Console.WriteLine("Ange efternamn: ");
        person.LastName = Console.ReadLine() ?? "";

        Console.WriteLine("Ange email: ");
        person.Email = Console.ReadLine() ?? "";

        Console.WriteLine("Ange telefonnummer: ");
        person.PhoneNumber = Console.ReadLine() ?? "";

        Console.WriteLine("Ange adress: ");
        person.Address = Console.ReadLine() ?? "";


        file.SaveToList(person);
        Console.ReadKey();
    }
    private void ShowAllContacts()
    {
        Console.Clear();
        Console.WriteLine("Visar alla kontakter. \n");
        file.ReadAndDisplay();

        Console.ReadKey();
    }
    private void ShowOneContact()
    {
        Console.Clear();
        Console.WriteLine("Vänligen sök efter förnamn.");
        var input = Console.ReadLine();
        if (input != null)
        {
            file.ReadOneByName(input);
        }
        Console.ReadKey();
    }
    private void RemoveOneContact()
    {
        Console.Clear();
        file.ReadAndDisplay();
        Console.WriteLine("Vänligen skriv in Förnamnet på kontakten du vill ta bort.");
        var firstName = Console.ReadLine();
        file.Delete(firstName);
    }
}
