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
    public class ContactServices
    {
        private string filePath = $@"{Directory.GetCurrentDirectory()}\adresslist.json";
        public ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>();

        public void SaveListToJson(ObservableCollection<ContactModel> personList)
        {
            using var sw = new StreamWriter(filePath);
            sw.Write(JsonConvert.SerializeObject(personList));
        }

        public void ReadList()
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

        public void Add(ContactModel content)
        {
            if (content.FirstName != null!)
            {
                MessageBox.Show(content.DisplayAll, "Test");
            }
            
            //contacts.Add(content);      
            //SaveListToJson(contacts);

        }
        public void Remove(ContactModel content)
        {
            contacts.Remove(content);
            SaveListToJson(contacts);
        }

        public ObservableCollection<ContactModel> GetList()
        {
            return contacts;
        }
    }
}
