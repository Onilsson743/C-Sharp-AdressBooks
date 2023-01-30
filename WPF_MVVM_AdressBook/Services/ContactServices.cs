using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_AdressBook.MVVM.Models;

namespace WPF_MVVM_AdressBook.Services
{
    public static class ContactServices
    {
        private static string filePath = $@"{Directory.GetCurrentDirectory()}\adresslist.json";
        private static ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>
        {
            new ContactModel {FirstName = "Oscar", LastName = "nilsson", Email = "Email", Address = "Adress", PhoneNumber = "number"}
        
        };

        public static void SaveListToJson(ObservableCollection<ContactModel> personList)
        {
            using var sw = new StreamWriter(filePath);
            sw.Write(JsonConvert.SerializeObject(personList));
        }

        public static void ReadList()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                var List = JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(sr.ReadToEnd());

                if (List != null)
                {
                    contacts = List;
                }
                else { contacts = new ObservableCollection<ContactModel>(); }
            }
            catch { contacts = new ObservableCollection<ContactModel>(); }
        }

        public static void Add(ContactModel content)
        { 
            contacts.Add(content);
            SaveListToJson(contacts);

        }
        public static void Remove(ContactModel content)
        {
            contacts.Remove(content);
            SaveListToJson(contacts);
        }

        public static ObservableCollection<ContactModel> GetList()
        {
            return contacts;
        }
    }
}
