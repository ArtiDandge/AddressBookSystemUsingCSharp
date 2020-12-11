using System;
using System.Collections.Generic;
namespace AddressBookSystemUsingCSharp
{
    class AddressBookMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address book System ! ");
            Dictionary<string, AddressBook> addressBookDict = new Dictionary<string, AddressBook>();
            string isRepeat = "yes";
            bool reLoop = false;
            do
            {
                try
                {
                    Console.WriteLine("\n\nHow many address Book you want to create ? ");
                    int numAddressBook = Convert.ToInt32(Console.ReadLine());

                    for (int i = 1; i <= numAddressBook; i++)
                    {
                        Console.WriteLine("Enter the name of address book " + i + ": ");
                        string addressBookName = Console.ReadLine();
                        AddressBook addressBook = new AddressBook();
                        addressBookDict.Add(addressBookName, addressBook);
                    }
                    reLoop = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("\n\nPlease enter only integer number of count of address book that you want to create, String not allowded here.\nAnd Make Sure you enter unique name for book, No duplicate name is allowded");

                }
            } while (reLoop != true);
            do
            {

                try
                {
                    Console.WriteLine("You have created following Address Books");

                    foreach (string k in addressBookDict.Keys)
                    {
                        Console.WriteLine(k);
                    }
                    Console.WriteLine("Choose option to procced further \n1.Add Contact \n2.Edit Contact \n3.Delete Contact  \n4.Display Contacts \n5.Find Person by Name \n6.Exit");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Address Book name where you want to add contacts");
                            string addContactInAddressBook = Console.ReadLine();
                            if (addressBookDict.ContainsKey(addContactInAddressBook))
                            {
                                Console.WriteLine("Enter how many contacts you want to add");
                                int numberOfContacts = Convert.ToInt32(Console.ReadLine());
                                for (int i = 1; i <= numberOfContacts; i++)
                                {
                                    takeInput(addressBookDict[addContactInAddressBook]);
                                }
                                addressBookDict[addContactInAddressBook].DisplayContacts();
                            }
                            else
                            {
                                Console.WriteLine("No AddressBook exist with name {0}", addContactInAddressBook);
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter Address Book name where you want to edit contact");
                            string editContactInAddressBook = Console.ReadLine();
                            if (addressBookDict.ContainsKey(editContactInAddressBook))
                            {
                                Console.WriteLine("Enter FirstName of Contact to be edited");
                                string firstNameOfContactToBeEdited = Console.ReadLine();
                                addressBookDict[editContactInAddressBook].EditContact(firstNameOfContactToBeEdited);
                                addressBookDict[editContactInAddressBook].DisplayContacts();
                            }
                            else
                            {
                                Console.WriteLine("No Address book exist with name {0} ", editContactInAddressBook);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter Address Book name where you want to delete contact");
                            string deleteContactInAddressBook = Console.ReadLine();
                            if (addressBookDict.ContainsKey(deleteContactInAddressBook))
                            {
                                Console.WriteLine("Enter FirstName of Contact to be deleted");
                                string firstNameOfContactToBeDeleted = Console.ReadLine();
                                addressBookDict[deleteContactInAddressBook].DeleteContact(firstNameOfContactToBeDeleted);
                                addressBookDict[deleteContactInAddressBook].DisplayContacts();
                            }
                            else
                            {
                                Console.WriteLine("No Address book exist with name {0} ", deleteContactInAddressBook);
                            }
                            break;
                        case 4:
                            Console.WriteLine("Enter Address Book name to display contacts");
                            string displayContactInAddressBook = Console.ReadLine();
                            addressBookDict[displayContactInAddressBook].DisplayContacts();
                            break;
                        case 5:
                            Console.WriteLine("Enter first name of person");
                            break;
                        case 6:
                            isRepeat = "no";
                            break;
                        default:
                            Console.WriteLine("Please enter valid option");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter integer options only");
                }
            } while (isRepeat.Equals("yes"));
        }
        public static void takeInput(AddressBook addressBook)
        {
            try
            {
                Console.WriteLine("Enter First Name : ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name : ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter Address : ");
                string address = Console.ReadLine();
                Console.WriteLine("Enter City : ");
                string city = Console.ReadLine();
                Console.WriteLine("Enter State : ");
                string state = Console.ReadLine();
                Console.WriteLine("Enter Zip : ");
                int zip = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Phone Number : ");
                long phoneNumber = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Email id :");
                string email = Console.ReadLine();
                addressBook.AddContact(firstName, lastName, address, city, state, zip, phoneNumber, email);

            }
            catch (Exception)
            {
                Console.WriteLine("Zip and Phone number must be integers only");
            }

        }
    }
}
