
using _02_WPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography.Pkcs;

namespace _02_WPF.Services;

internal class FileService
{
    public string FilePath { get; set; } = null!;


    public void Save(ObservableCollection<Employee> content)
    {
        using var sw = new StreamWriter(FilePath);
        sw.Write(JsonConvert.SerializeObject(content));
    }

    public ObservableCollection<Employee> Read()
    {
        
        using var sr = new StreamReader(FilePath);
        var PersonList = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(sr.ReadToEnd());

        if (PersonList != null)
        {
            return PersonList;
        }
        else return null!;  
    }
}
