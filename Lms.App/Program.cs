using System;
using System.Collections.Generic;
using Lms.Core;

namespace Lms.App
{
    class Program
    {
        static List<Book> books = new List<Book>();
        static int nextBookId = 1;

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Library Management System ===");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        ViewBooks();
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

        static void AddBook()
        {
            Console.Clear();
            Console.WriteLine("=== Add a New Book ===");
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Author: ");
            string author = Console.ReadLine();
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());

            Book newBook = new Book(nextBookId++, title, author, isbn, year);
            books.Add(newBook);

            Console.WriteLine("\nBook added successfully!");
            Pause();
        }

        static void ViewBooks()
        {
            Console.Clear();
            Console.WriteLine("=== List of Books ===");

            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
            }
            else
            {
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }

            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}
