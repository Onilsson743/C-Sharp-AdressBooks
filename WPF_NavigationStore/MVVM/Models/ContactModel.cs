using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_NavigationStore.MVVM.Models
{
    public class ContactModel
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string DisplayName => $"{FirstName} {LastName}";
        public string DisplayAll => $"Namn: {DisplayName}\n" +
            $"Email: {Email}\n" +
            $"Telefonnummer: {PhoneNumber}\n" +
            $"Adress: {Address}\n";

    }
}
