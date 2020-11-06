using System;
using System.Collections.Generic;
using System.IO;

namespace inlamningsuppgift1
{
    class Program
    {
        // All addresses will be stored in this list.
        static List<Person> addressBook = new List<Person>();

        // This is the path to the txt-file that will store the addressbook.
        // Make sure to change this path if you wish to use this script for your own needs.
        static string filePath = @"C:\Users\sebas\Dropbox\Programmering\vs\Progmet\inlamningsuppgift1\adressbok.txt";
        // Variable for keeping tack if the user saved his/her changes to the addressbook.
        static bool savedWork = true;

        class Person
        {
            public string name;
            public string address;
            public string phone;
            public string email;

            // Lägg till contructor
            public Person(string inputName, string inputAddress, string inputPhone, string inputEmail)
            {
                name = inputName;
                address = inputAddress;
                phone = inputPhone;
                email = inputEmail;
            }

            public string PrintInformation()
            {
                return ($"{name}, {address}, {phone}, {email}");
            }
        }
        static string ReadUserInput()
        {
            Console.WriteLine("What would you like to do?\n" +
                              "Available commands: show, add, remove, change, save, exit.");
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "show")
            {
                Console.WriteLine("Write the first name of the person you would like to show or if you would like to show 'all':");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "all")
                {
                    foreach (Person person in addressBook)
                    {
                        Console.WriteLine(person.PrintInformation());
                    }
                    return "show";
                }
                else
                {
                    foreach (Person person in addressBook)
                    {
                        if (person.name.Split(" ")[0].ToLower() == userInput || person.name.Split(" ")[1].ToLower() == userInput)
                        {
                            Console.WriteLine(person.PrintInformation());
                        }
                    }
                }
                Console.WriteLine("Could not find that person in the list.");
                return "show";
            }
            else if (userInput == "add")
            {
                Console.WriteLine("Write the information about the person on the format:" +
                                  "<Name>,<Address>,<Phone>,<Email>. If you do not have all the information, please include the comma anyway.");
                try
                {
                    var personInformation = Console.ReadLine().Split(",");
                    Person p = new Person(personInformation[0], personInformation[1], personInformation[2], personInformation[3]);
                    addressBook.Add(p);
                    Console.WriteLine("Person successfully added!");
                    savedWork = false;
                    return "add";
                }
                catch
                {
                    Console.WriteLine("Something went wrong. Please try again.");
                    return "add";
                }
            }
            else if (userInput == "remove")
            {
                Console.WriteLine("Write the full name of the person you would like to remove:");
                userInput = Console.ReadLine().ToLower();
                foreach (Person person in addressBook)
                {
                    if (userInput == person.name.ToLower())
                    {
                        addressBook.Remove(person);
                        Console.WriteLine("Person successfully removed from addressbook.");
                        savedWork = false;
                        return "remove";
                    }
                }
                Console.WriteLine("Something went wrong. Please try again.");
                return "Remove";
            }
            else if (userInput == "change")
            {
                Console.WriteLine("Write the name of the person that you would like to change:");
                userInput = Console.ReadLine().ToLower();
                foreach (Person person in addressBook)
                {
                    if (userInput == person.name.ToLower())
                    {
                        Console.WriteLine(person.PrintInformation());
                        Console.WriteLine("What information would you like to change? <Name>, <Address>, <Phone>, <Email>?");
                        userInput = Console.ReadLine().ToLower();
                        switch (userInput)
                        {
                            case "name":
                                Console.WriteLine("Write the changed name:");
                                person.name = Console.ReadLine();
                                Console.WriteLine("Changes successfully applied!");
                                savedWork = false;
                                return "change";

                            case "address":
                                Console.WriteLine("Write the changed address:");
                                person.address = Console.ReadLine();
                                Console.WriteLine("Changes successfully applied!");
                                savedWork = false;
                                return "change";

                            case "phone":
                                Console.WriteLine("Write the changed phone:");
                                person.phone = Console.ReadLine();
                                Console.WriteLine("Changes successfully applied!");
                                savedWork = false;
                                return "change";

                            case "email":
                                Console.WriteLine("Write the changed email:");
                                person.email = Console.ReadLine();
                                Console.WriteLine("Changes successfully applied!");
                                savedWork = false;
                                return "change";

                            default:
                                Console.WriteLine("Something went wrong. Please try again.");
                                return "change";
                        }
                    }
                }
                Console.WriteLine("Could not find any person with that name. Please try again.");
                return "change";
            }
            else if (userInput == "save")
            {
                SaveWork();
                Console.WriteLine("Saved.");
                savedWork = true;
                return "save";
            }
            else if (userInput == "exit")
            {
                if (savedWork == false)
                {
                    Console.WriteLine("You have unsaved changes to the addressbook. Press 'Y' to save or any other key to not save.");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "y")
                    {
                        SaveWork();
                        Console.WriteLine("Your changes to the addressbooks are saved.");
                        return "exit";
                    }
                    else
                    {
                        Console.WriteLine("Your changes to the addressbook are not saved.");
                        return "exit";
                    }
                }
                return "exit";
            }
            else
            {
                Console.WriteLine("Unknown command. Please try again.");
                return null;
            }
        }

        static List<Person> ReadPersonsFromFile(string filePath)
        {
            // filePath string must begin with an '@' to avoid Unrecognized escape sequences
            List<Person> personList = new List<Person>();

            string line;
            // If you clone this from github, remember to change file path to 'adressbok.txt'.
            using (StreamReader textFile = new StreamReader(filePath))
            {
                while ((line = textFile.ReadLine()) != null)
                {
                    var splitLine = line.Split(",");

                    Person newPerson = new Person(splitLine[0], splitLine[1], splitLine[2], splitLine[3]);
                    personList.Add(newPerson);
                }
            }
            // Source: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-a-text-file-one-line-at-a-time
            return personList;
        }

        static void SaveWork()
        {
            // Remove all contents from file first.
            File.WriteAllText(filePath, String.Empty);
            // Source: https://stackoverflow.com/questions/2695444/clearing-content-of-text-file-using-c-sharp
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Person person in addressBook)
                {
                    writer.WriteLine($"{person.name},{person.address},{person.phone},{person.email}");
                }
            }
            // Source: https://www.c-sharpcorner.com/article/c-sharp-write-to-file/
        }

        static void Main(string[] args)
        {
            addressBook.AddRange(ReadPersonsFromFile(filePath));
            //File.Close(filePath);
            Console.WriteLine("This is your address book.");
            string returnValue = "";
            do
            {
                returnValue = ReadUserInput();
            } while (returnValue != "exit");
        }
    }
}
