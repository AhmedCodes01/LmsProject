using System;

namespace Lms.App
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Library Management System ===");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. Search for a Book");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Adding a new book (not implemented yet).");
                        Pause();
                        break;
                    case "2":
                        Console.WriteLine("Searching for a book (not implemented yet).");
                        Pause();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        Pause();
                        break;
                }
            }
        }

        static void Pause()
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}

