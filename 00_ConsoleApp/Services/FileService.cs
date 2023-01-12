using _00_ConsoleApp.Interfaces;
using _00_ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _00_ConsoleApp.Services
{
    internal class FileService
    {
        public string FilePathdesktop = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
        public string FilePath = $@"{Directory.GetCurrentDirectory()}\adresslist.json";
        private List<ContactInfo> PersonList = new();
        public void SaveToList(ContactInfo content)
        {

            PersonList.Add(content);
            SaveList(PersonList);
        }

        public void SaveList(List<ContactInfo> personList) 
        {
            using var sw = new StreamWriter(FilePath);
            sw.Write(JsonConvert.SerializeObject(personList));
            Console.WriteLine("Adressboken har uppdaterats. Vänligen tryck på någon knapp för att gå tillbaka till huvudmenyn.");
        }
        public void ReadList()
        {
            try
            {
                using var sr = new StreamReader(FilePath);
                var List = JsonConvert.DeserializeObject<List<ContactInfo>>(sr.ReadToEnd());

                if (List != null)
                {
                    PersonList = List;
                }
                else { };
            }
            catch { }
        }
        public void ReadAndDisplay()
        {
            using var sr = new StreamReader(FilePath);
            PersonList = JsonConvert.DeserializeObject<List<ContactInfo>>(sr.ReadToEnd()) ?? null!;
 
            if (PersonList!= null)
            {
                foreach (ContactInfo person in PersonList)
                {
                    DisplayContactInfo.WriteInfo(person);
                }
            } else { Console.WriteLine("Adressboken är tom. Vänligen lägg till nya kontakter."); }            
        }

        public void ReadOneByName(string firstName)
        {
            using var sr = new StreamReader(FilePath);
            PersonList = JsonConvert.DeserializeObject<List<ContactInfo>>(sr.ReadToEnd()) ?? null!;
            var person = PersonList.FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower() || x.LastName.ToLower() == firstName.ToLower() || x.Email.ToLower() == firstName.ToLower());
            if (person != null)
            {
                DisplayContactInfo.WriteInfo(person);
            }
            else Console.WriteLine($"Person with name {firstName} was not found.");
           
        }
        public void Delete(string firstName) 
        {
            Console.Clear();
            var persons = PersonList.Where(x => x.FirstName.ToLower() == firstName.ToLower()).ToList();

            if (persons.Count > 1) 
            {
                byte count = 0;
                
                foreach (ContactInfo person in persons)
                {

                    Console.WriteLine($"Nr: {count}");
                    DisplayContactInfo.WriteInfo(person);
                    count++;
                }
                Console.WriteLine($"Flera personer med samma namn hittade. Vänligen skriv in nummret på den kontakt du vill radera. (0 - {persons.Count - 1})\n");

                string input = Console.ReadLine() ?? null!;
                
                try
                {
                    byte result = Byte.Parse(input);
                    Console.WriteLine(result.GetType() + "Input");

                    Console.Clear();
                    Console.WriteLine();
                    DisplayContactInfo.WriteInfo(persons[result]);

                    Console.WriteLine("\nVill du radera följande kontakt? (y/n)\n");
                    string anwser = Console.ReadLine() ?? string.Empty;

                    if (anwser.ToLower() == "y") 
                    {
                        try
                        {
                            PersonList.Remove(persons[result]);
                            SaveList(PersonList);
                            foreach (ContactInfo x in PersonList)
                            {
                                DisplayContactInfo.WriteInfo(x);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Någonting gick fel.");
                        }

                    } else
                    {
                        Console.WriteLine("Kontakten lyckades inte tas bort. Tryck på någon knapp för att gå tillbaka till huvudmenyn");
                        Console.ReadKey();
                    }

                } catch 
                {
                    Console.WriteLine("En kontakt med den siffran hittades inte. Tryck på någon knapp för att gå tillbaka till huvudmenyn");
                    Console.ReadKey();
                }
                
            } else            
            {
                
                foreach (ContactInfo person in persons)
                {
                    DisplayContactInfo.WriteInfo(person);
                }
                Console.WriteLine("\nEn kontakt hittad hittad. Vill du ta bort denna kontakt? (y/n): \n");

                string anwser = Console.ReadLine() ?? string.Empty;

                if (anwser.ToLower() == "y")
                {
                    try
                    {
                        PersonList.Remove(persons[0]);
                        SaveList(PersonList);
                        foreach (ContactInfo x in PersonList)
                        {
                            DisplayContactInfo.WriteInfo(x);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Någonting gick fel.");
                    }
                }
                else
                {
                    Console.WriteLine("Kontakten lyckades inte tas bort. Tryck på någon knapp för att gå tillbaka till huvudmenyn");
                    Console.ReadKey();
                }
            }
        }

       
    }
}
