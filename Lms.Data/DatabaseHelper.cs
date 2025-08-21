using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using Lms.Core;

namespace Lms.Data
{
    public static class DatabaseHelper
    {
        private const string ConnectionString = "Data Source=library.db";

        public static void InitializeDatabase()
        {
            string schema = System.IO.File.ReadAllText("schema.sql");
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = schema;
            command.ExecuteNonQuery();
        }

        public static void AddBook(Book book)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
                "INSERT INTO Books (Title, Author, ISBN, Year, IsAvailable) VALUES ($title, $author, $isbn, $year, $isAvailable)";
            command.Parameters.AddWithValue("$title", book.Title);
            command.Parameters.AddWithValue("$author", book.Author);
            command.Parameters.AddWithValue("$isbn", book.ISBN);
            command.Parameters.AddWithValue("$year", book.Year);
            command.Parameters.AddWithValue("$isAvailable", book.IsAvailable ? 1 : 0);

            command.ExecuteNonQuery();
        }

        public static List<Book> GetAllBooks()
        {
            var books = new List<Book>();

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Title, Author, ISBN, Year, IsAvailable FROM Books";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                books.Add(new Book(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetInt32(4)
                )
                {
                    IsAvailable = reader.GetInt32(5) == 1
                });
            }

            return books;
        }

        public static List<Book> SearchBooks(string keyword)
        {
            var books = new List<Book>();

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
                "SELECT Id, Title, Author, ISBN, Year, IsAvailable FROM Books WHERE Title LIKE $keyword OR Author LIKE $keyword";
            command.Parameters.AddWithValue("$keyword", "%" + keyword + "%");

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                books.Add(new Book(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetInt32(4)
                )
                {
                    IsAvailable = reader.GetInt32(5) == 1
                });
            }

            return books;
        }

        public static void AddUser(User user)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
                "INSERT INTO Users (Name, Email) VALUES ($name, $email)";
            command.Parameters.AddWithValue("$name", user.Name);
            command.Parameters.AddWithValue("$email", user.Email);

            command.ExecuteNonQuery();
        }

        public static List<User> GetAllUsers()
        {
            var users = new List<User>();

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name, Email FROM Users";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new User(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2)
                ));
            }

            return users;
        }
    }
}



