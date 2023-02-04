using _00_ConsoleApp.Interfaces;
using _00_ConsoleApp.Models;

namespace _00_ConsoleApp.Services;

internal class DisplayContactInfo
{
    public static void WriteInfo(ContactInfo person)
    {
        Console.WriteLine($"" +
            $"Förnamn: {person.FirstName}\n" +
            $"Efternamn: {person.LastName}\n" +
            $"Epost-adress: {person.Email}\n" +
            $"Telefonnummer: {person.PhoneNumber}\n" +
            $"Adress: {person.Address}\n");
    }
}
