using System;
using System.Collections.Generic;
using System.IO;

namespace inlamningsuppgift1
{
    class Program
    {
        // All addresses will be stored in this list.
        static List<Person> addressBook = new List<Person>();
        
        class Person
        {
            public string name;
            public string address;
            public string phone;
            public string email;

            // Lägg till contructor
            public Person(string inputName = "", string inputAddress = "", string inputPhone = "", string inputEmail = "")
            {
                name = inputName;
                address = inputAddress;
                phone = inputPhone;
                email = inputEmail;
            }
        }
        static string ReadUserInput()
        {
            Console.WriteLine("What would you like to do?\n" +
                              "Available commands: show, add, remove, save, exit.");

            bool savedWork = true;
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "show")
            {
                Console.WriteLine("Write the first name of the person you would like to show:");
                userInput = Console.ReadLine().ToLower();
                foreach (Person person in Program.addressBook)
                {
                    if (person.name.Split(" ")[0].ToLower() == userInput)
                    {
                        Console.WriteLine($"{person.name}, {person.address}, {person.phone}, {person.email}");
                        ReadUserInput();
                    }
                }
                Console.WriteLine("Could not find that person in the list.");
                ReadUserInput();
            }
            else if (userInput == "add")
            {
                Console.WriteLine("Write the name of the person you would like to show:");
                foreach (Person person in Program.addressBook)
                {

                }
            }
            else if (userInput == "remove")
            {
                Console.WriteLine("Write the name of the person you would like to show:");
            }
            else if (userInput == "save")
            {
                Console.WriteLine("Write the name of the person you would like to show:");
                savedWork = true;
            }
            else if (userInput == "exit")
            {
                Console.WriteLine("Write the name of the person you would like to show:");
            }
            else
            {
                Console.WriteLine("Unknown command. Please try again.");
            }

            // Lägg till olika
            if (savedWork == false)
            {
                Console.WriteLine("You have unsaved changes to the addressbook. Would you like to save them? Y/N");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "y") 
                {
                    Console.WriteLine("saved");
                    savedWork = true;
                }
                else if (userInput == "n")
                {
                    Console.WriteLine("not saved");
                    savedWork = true;
                }
                else
                {
                    Console.WriteLine("Unknown command. Please write Y/N.");
                }
            }
            return userInput;
        }

        static List<Person> ReadPersonsFromFile(string filePath)
        {
            // filePath string must begin with an '@' to avoid Unrecognized escape sequences
            List<Person> personList = new List<Person>();

            string line;
            // If you clone this from github, remember to change file path to 'adressbok.txt'.
            StreamReader textFile = new StreamReader(@filePath);
            while ((line = textFile.ReadLine()) != null)
            {
                var splitLine = line.Split(",");

                Person newPerson = new Person(splitLine[0], splitLine[1], splitLine[2], splitLine[3]);
                personList.Add(newPerson);
            }
            // Code fetched from https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-a-text-file-one-line-at-a-time
            return personList;
        }

        static void Main(string[] args)
        {
            Program.addressBook.AddRange(ReadPersonsFromFile(@"C:\Users\sebas\Dropbox\Programmering\vs\Progmet\inlamningsuppgift1\adressbok.txt"));
            Console.WriteLine("This is your address book.");
            do
            {
                ReadUserInput();
            } while (ReadUserInput() != "exit");

            // Gör en metod som läser in user input om den exemeplvis vill lägga till en person eller läsa av adressboken
        }
    }
}
