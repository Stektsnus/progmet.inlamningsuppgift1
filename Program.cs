using System;
using System.Collections.Generic;
using System.IO;

namespace inlamningsuppgift1
{
    class Program
    {
        

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
        }
        static void ReadUserIput ()
        {
            Console.WriteLine("Person successfully added!");
            // Lägg till olika
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
                Console.WriteLine(line);
                var splitLine = line.Split(",");

                Person newPerson = new Person(splitLine[0], splitLine[1], splitLine[2], splitLine[3]);
                personList.Add(newPerson);
            }
            // Code fetched from https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-a-text-file-one-line-at-a-time
            return personList;
        }

        static void Main(string[] args)
        {
            // All addresses will be stored in this list.
            List<Person> addressBook = new List<Person>();
            addressBook.AddRange(ReadPersonsFromFile(@"C:\Users\sebas\Dropbox\Programmering\vs\Progmet\inlamningsuppgift1\adressbok.txt"));
            
            foreach(Person person in addressBook)
            {
                Console.WriteLine($"{person.name}, {person.address}, {person.phone}, {person.email}");
            }

            // Gör en metod som läser in user input om den exemeplvis vill lägga till en person eller läsa av adressboken
        }
    }
}
