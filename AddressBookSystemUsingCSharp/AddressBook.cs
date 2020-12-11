using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookSystemUsingCSharp
{
    class AddressBook
    {
        List<Contacts> contactList;
        public AddressBook()
        {
            this.contactList = new List<Contacts>();
        }
        public void AddContact(string first_name, string LastName, string address, string city, string state, int zip, long phone_number, string email)
        {
            bool duplicate = equals(first_name);
            if (duplicate)
            {
                Console.WriteLine("Can not add Contact with duplicate first name. '{0}' is already exit in this address book", first_name);
            }
            else
            {
                Contacts contact = new Contacts(first_name, LastName, address, city, state, zip, phone_number, email);
                contactList.Add(contact);
                Console.WriteLine("Contact added Successfully !");

            }

        }
        public bool equals(string first_name)
        {
            if (this.contactList.Any(e => e.first_name == first_name))
                return true;
            else
                return false;
        }
        public void EditContact(string first_name)
        {
            if (contactList.Count() > 0)
            {
                int thereExist = 1;
                foreach (Contacts contact in contactList)
                {
                    if (first_name.Equals(contact.first_name))
                    {
                        thereExist = 0;
                        Console.WriteLine("Enter Last Name : ");
                        contact.last_name = Console.ReadLine();
                        Console.WriteLine("Enter Address: ");
                        contact.address = Console.ReadLine();
                        Console.WriteLine("Enter City : ");
                        contact.city = Console.ReadLine();
                        Console.WriteLine("Enter State : ");
                        contact.state = Console.ReadLine();
                        Console.WriteLine("Enter Zip code : ");
                        contact.zip = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Phone Number : ");
                        contact.phone_number = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter Email : ");
                        contact.email = Console.ReadLine();
                        Console.WriteLine("Contact Updated Successfully !");
                    }
                }
                if (thereExist == 1)
                {
                    Console.WriteLine("Contact not found with first name '{0}'!", first_name);
                }
            }
            else
            {
                Console.WriteLine("This contact address book is empty. First add contact then try Editing");
            }
        }
        public void DeleteContact(string first_name)
        {
            if (contactList.Count() > 0)
            {
                int thereExist = 1;
                foreach (Contacts contact in contactList)
                {
                    if (first_name.Equals(contact.first_name))
                    {
                        thereExist = 0;
                        contactList.Remove(contact);
                        Console.WriteLine("Contact Deleted Successfully !");
                        break;
                    }
                }
                if (thereExist == 1)
                {
                    Console.WriteLine("Contact not foundwith first name '{0}'!", first_name);
                }
            }
            else
            {
                Console.WriteLine("This contact address book is empty. First add contact then try Deleting");
            }
        }
        public void DisplayContacts()
        {
            if (contactList.Count() > 0)
            {
                foreach (Contacts contact in contactList)
                {
                    Console.WriteLine("First Name : " + contact.first_name);
                    Console.WriteLine("Last Name : " + contact.last_name);
                    Console.WriteLine("Address : " + contact.address);
                    Console.WriteLine("City : " + contact.city);
                    Console.WriteLine("State : " + contact.state);
                    Console.WriteLine("Zip : " + contact.zip);
                    Console.WriteLine("Phone Number : " + contact.phone_number);
                    Console.WriteLine("Email : " + contact.email);
                }
            }
            else
            {
                Console.WriteLine("This contact address book is empty. First add contact then try Displaying");
            }
        }

        public void FindPersonByName(string first_name)
        {

        }
    }
}
