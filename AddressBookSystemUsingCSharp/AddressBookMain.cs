using System;
using System.Collections.Generic;
namespace AddressBookSystemUsingCSharp
{
    class AddressBookMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address book System ! ");
            string isRepeate = "Yes";
            try
            {
                do
                {
                    Console.WriteLine("\nHow do you you like to continue ? \n1.Continue Without Database \n2.Continue with Database \n3.Exit");
                    int choiceToContinue = Convert.ToInt32(Console.ReadLine());
                    switch (choiceToContinue)
                    {
                        case 1:
                            AddressBookCoreOperations.AddressBookCore();
                            break;
                        case 2:
                            AddressBookDatabase database = new AddressBookDatabase();
                            database.GetPersonDetailsfromDatabase();
                            break;
                        case 3:
                            isRepeate = "No";
                            break;
                        default:
                            Console.WriteLine("Please enter valid option...");
                            break;
                    }
                } while (isRepeate.Equals("Yes"));
            }
            catch
            {
                Console.WriteLine("Please enter integer option only.");
            }
        }
    }
}
