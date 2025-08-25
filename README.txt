Library Management System (C# Console + SQL)

Overview
This is a simple Library Management System built using C# (.NET), with SQL for data storage.
It allows adding, searching, viewing, borrowing, and returning books, as well as registering users.

Features
1. Add new books to the library
2. View all books
3. Search books by title or author
4. Register new users
5. Borrow a book (creates a loan record, sets book as unavailable)
6. Return a book (updates loan record, makes book available again)
7. Exit

Technology Stack
- C# (.NET 6/7)
- SQL(local database)
- Console-based UI

Project Structure
- Lms.Core   Contains core entities (Book, User, Loan)
- Lms.Data   Handles database setup and connections (DatabaseHelper.cs)
- Lms.App    Console application (Program.cs)

Database
The database is stored in `library.db`.  
Tables:
- Books
- Users
- Loans

The schema is defined in `schema.sql` and is automatically applied on first run.

How to Run
1. Clone the repository.
2. Ensure .NET 6/7 SDK is installed.
3. Open CMD inside the project folder.
4. Run the app: using this command 
dotnet run --project Lms.App

5. Use the menu to interact with the system.
here is an example of what I had to add in the system to test it. you will screenshots of how it worked on my side in the report.
Add a Book title:The Great Gatsby, Author: F. Scott Fitzgerald, ISBN: 1234567890, Year: 1925
you can trying adding a book of your choice once you go to view all the books you should be able to see the book you just added.
- Register User; Name: John Doe, Email: john@gmail.com
with the user registerd and the book added you should be able to borrow the book with the id below.
- Borrow the book using User ID 1 and Book ID 1
- Return the book using Loan ID 1


