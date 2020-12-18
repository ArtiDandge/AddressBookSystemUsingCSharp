using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBookSystemUsingCSharp
{
    public class FileIO
    {
        static String TextFilePath = @"C:\Users\HP\source\repos\AddressBookSystemUsingCSharp\AddressBookSystemUsingCSharp\TextFile1.txt";
       
        public static void WriteContactsInTxtFile(List<Contacts> contacts)
        {
            if (File.Exists(TextFilePath))
            {
                using (StreamWriter streamWriter = File.AppendText(TextFilePath))
                {
                    foreach (Contacts contact in contacts)
                    {
                        streamWriter.WriteLine(contact);
                    }
                    streamWriter.Close();
                }
                Console.WriteLine("Writting Contacts to the Text file is Complete !");
            }
            else
            {
                Console.WriteLine("No such file exists");
            }            
        }

        public static void ReadContactsInTxtFile()
        {
            if (File.Exists(TextFilePath))
            {
                using (StreamReader streamReader = File.OpenText(TextFilePath))
                {
                    String contactDetails = "";
                    while ((contactDetails = streamReader.ReadLine()) != null)
                        Console.WriteLine((contactDetails));
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No such file exists");
            }
        }
    }
}
