using System;
using System.Collections.Generic;

// Interface for contact actions
public interface IContactManager
{
    void AddContact(Contact contact);
    void ListContacts();
}

// Contact class with properties
public class Contact
{
    public string Name { get; set; }
    public string Email { get; set; }

    public Contact(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public override string ToString() => $"Name: {Name}, Email: {Email}";
}

// Manager class implementing the interface
public class ContactManager : IContactManager
{
    private readonly List<Contact> _contacts = new();

    public void AddContact(Contact contact)
    {
        _contacts.Add(contact);
        Console.WriteLine("Contact added successfully.");
    }

    public void ListContacts()
    {
        if (_contacts.Count == 0)
        {
            Console.WriteLine("No contacts found.");
            return;
        }

        Console.WriteLine("Contacts:");
        foreach (var contact in _contacts)
        {
            Console.WriteLine(contact);
        }
    }
}

// Main program
class Program
{
    static void Main()
    {
        IContactManager manager = new ContactManager();
        while (true)
        {
            Console.WriteLine("\nContact Manager");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. List Contacts");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter name: ");
                    var name = Console.ReadLine();
                    Console.Write("Enter email: ");
                    var email = Console.ReadLine();
                    manager.AddContact(new Contact(name ?? "", email ?? ""));
                    break;
                case "2":
                    manager.ListContacts();
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}