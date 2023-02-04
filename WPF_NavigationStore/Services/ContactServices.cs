using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_NavigationStore.MVVM.Models;

namespace WPF_NavigationStore.Services
{
    public static class ContactServices
    {
        private static string filePath = $@"{Directory.GetCurrentDirectory()}\adresslist.json";
        public static ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>();
        public static ObservableCollection<ContactModel> contact = new ObservableCollection<ContactModel>();
        public static ContactModel editContact = new ContactModel();

        public async static void SaveListToJson(ObservableCollection<ContactModel> personList)
        {
            using var sw = new StreamWriter(filePath);
            sw.Write(JsonConvert.SerializeObject(personList));
            sw.Close();
            ReadList();
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

        public static void Update(ContactModel content)
        {
            using var sr = new StreamReader(filePath);
            contacts = JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(sr.ReadToEnd()) ?? null!;
            sr.Close();

            ObservableCollection<ContactModel> newList = new ObservableCollection<ContactModel>();

            
            foreach (var contact in contacts)
            {
                
                if (contact.id == editContact.id)
                {
                    newList.Add(content);
                } else { newList.Add(contact); }
            }
            
            if (newList != null)
            {
                SaveListToJson(newList);
                MessageBox.Show("Kontakten Uppdaterad");
            }
            else MessageBox.Show("Kontakten lyckades inte uppdateras. Vänligen försök igen.", "Varning!");
            
            
        }

        public static ObservableCollection<ContactModel> GetList()
        {
            return contacts;
        }
    }
}
