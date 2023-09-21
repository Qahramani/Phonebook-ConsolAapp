using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookConsole
{
    internal class Phonebook
    {
        private List<Contact> _contacts { get; set; } = new List<Contact>();
        //refactoring
        private void DisplayContactDetails(Contact contact)
        {
            Console.WriteLine($"Contact: {contact.Name}, {contact.Number}");
        }

        private void DisplayContactsDetails(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                DisplayContactDetails(contact);
            }
        }
        
        public void AddContact(Contact contact)
        {
            if(contact.Number.Count() != 10)
                Console.WriteLine("Invalid number!Your number should consists of 10 digits.");
            else
            _contacts.Add(contact);
        }

        public void DisplayContact(string number)
        {
            var contact = _contacts.FirstOrDefault(c => c.Number == number);
            if(contact == null)
            {
                Console.WriteLine("Contact not found");
            }
            else
            {
                DisplayContactDetails(contact);
            }
        }

        public void DisplayAllContacts()
        {
            DisplayContactsDetails(_contacts);
        }

        public void DisplayMatchingContacts(string searchPhrase)
        {
            var matchingContacts = _contacts.Where(c => c.Name.Contains(searchPhrase)).ToList();
            DisplayContactsDetails(matchingContacts);
        }

        public void DeleteContactByName(string name)
        {
            var index = _contacts.FindIndex(c => c.Name.Contains(name));
            _contacts.RemoveAt(index);
            Console.WriteLine("Contact deleted succesfully.");
        }

        public void DeleteContactByNumber(string number)
        {
            var index = _contacts.FindIndex(c => c.Number.Contains(number));
            _contacts.RemoveAt(index);
            Console.WriteLine("Contact deleted succesfully.");
        }
    }
}
