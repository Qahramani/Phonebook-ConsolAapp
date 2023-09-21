using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Hello from the Console Phonebook app!--");
            Console.WriteLine("Select operation");
            Console.WriteLine("1 Add contact");
            Console.WriteLine("2 Display contact by number");
            Console.WriteLine("3 View all contacts");
            Console.WriteLine("4 Search for contacts for a given name");
            Console.WriteLine("5 Delete contact ");
            Console.WriteLine("Press 'x' to exit");

            var userInput = Console.ReadLine();

            Phonebook phonebook = new Phonebook();


            while (true)
            {
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Contact name: ");
                        var name = Console.ReadLine();
                        Console.WriteLine("Contact number: ");
                        var number = Console.ReadLine();

                        Contact newContact = new Contact(name, number);
                        phonebook.AddContact(newContact);
                        break;
                    case "2":
                        Console.WriteLine("Contact number to search: ");
                        var searchNUmber = Console.ReadLine();
                        phonebook.DisplayContact(searchNUmber);
                        break;
                    case "3":
                        phonebook.DisplayAllContacts();
                        break;
                    case "4":
                        Console.WriteLine("Name search phrase:");
                        var searchPhrase = Console.ReadLine();

                        phonebook.DisplayMatchingContacts(searchPhrase);
                        break;
                     case "5":
                        Console.Write("How u want delete the contact?\n1 by it's name\n2 by it's number\nYour input: ");
                        int option = int.Parse(Console.ReadLine());
                        if(option == 1)
                        {
                            var delNumber = Console.ReadLine();
                            phonebook.DeleteContactByName(delNumber);
                        }
                        else if(option == 2)
                        {
                            var delNumber = Console.ReadLine();
                            phonebook.DeleteContactByNumber(delNumber);
                        }
                        break;
                    case "x":
                        return;
                    default:
                        Console.WriteLine("Select valid operation!");
                        break;
                }
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Select Option");
                userInput = Console.ReadLine();
            }
            
        }
    }
}
