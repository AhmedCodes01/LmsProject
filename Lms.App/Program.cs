using System;
using System.Collections.Generic;
using Lms.Core;
using Lms.Data;

namespace Lms.App
{
    class Program
    {
        static List<Book> books = new List<Book>();
        static List<User> users = new List<User>();
        static List<Loan> loans = new List<Loan>();

        static int nextBookId = 1;
        static int nextUserId = 1;
        static int nextLoanId = 1;

        static void Main(string[] args)
        {
            DatabaseHelper.InitializeDatabase();

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Library Management System ===");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Search for a Book");
                Console.WriteLine("4. Register User");
                Console.WriteLine("5. Borrow a Book");
                Console.WriteLine("6. Return a Book");
                Console.WriteLine("7. Exit");
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
                        SearchBook();
                        break;
                    case "4":
                        RegisterUser();
                        break;
                    case "5":
                        BorrowBook();
                        break;
                    case "6":
                        ReturnBook();
                        break;
                    case "7":
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

        static void SearchBook()
        {
            Console.Clear();
            Console.WriteLine("=== Search for a Book ===");
            Console.Write("Enter title or author: ");
            string keyword = Console.ReadLine().ToLower();

            var results = books.FindAll(b =>
                b.Title.ToLower().Contains(keyword) ||
                b.Author.ToLower().Contains(keyword));

            if (results.Count == 0)
            {
                Console.WriteLine("No matching books found.");
            }
            else
            {
                foreach (var book in results)
                {
                    Console.WriteLine(book);
                }
            }

            Pause();
        }

        static void RegisterUser()
        {
            Console.Clear();
            Console.WriteLine("=== Register New User ===");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            User newUser = new User(nextUserId++, name, email);
            users.Add(newUser);

            Console.WriteLine("\nUser registered successfully!");
            Pause();
        }

        static void BorrowBook()
        {
            Console.Clear();
            Console.WriteLine("=== Borrow a Book ===");

            if (users.Count == 0)
            {
                Console.WriteLine("No users registered.");
                Pause();
                return;
            }

            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
                Pause();
                return;
            }

            Console.Write("Enter User ID: ");
            int userId = int.Parse(Console.ReadLine());
            var user = users.Find(u => u.Id == userId);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                Pause();
                return;
            }

            Console.Write("Enter Book ID: ");
            int bookId = int.Parse(Console.ReadLine());
            var book = books.Find(b => b.Id == bookId);

            if (book == null || !book.IsAvailable)
            {
                Console.WriteLine("Book not available.");
                Pause();
                return;
            }

            DateTime loanDate = DateTime.Now;
            DateTime dueDate = loanDate.AddDays(14);

            Loan loan = new Loan(nextLoanId++, user, book, loanDate, dueDate);
            loans.Add(loan);
            book.IsAvailable = false;

            Console.WriteLine("\nBook borrowed successfully!");
            Pause();
        }

        static void ReturnBook()
        {
            Console.Clear();
            Console.WriteLine("=== Return a Book ===");

            Console.Write("Enter Loan ID: ");
            int loanId = int.Parse(Console.ReadLine());
            var loan = loans.Find(l => l.Id == loanId);

            if (loan == null || loan.IsReturned())
            {
                Console.WriteLine("Invalid Loan ID or book already returned.");
                Pause();
                return;
            }

            loan.ReturnDate = DateTime.Now;
            loan.BorrowedBook.IsAvailable = true;

            Console.WriteLine("\nBook returned successfully!");
            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}
