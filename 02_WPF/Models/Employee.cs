using System;

namespace _02_WPF.Models;


internal interface IEmployee
{
    Guid Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
}
internal class Employee : IEmployee
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string DisplayName => $"{FirstName} {LastName}";
}
