using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace Lms.Data
{
    public static class DatabaseHelper
    {
        private static string DbPath = Path.Combine(AppContext.BaseDirectory, "library.db");

        public static void InitializeDatabase()
        {
            if (!File.Exists(DbPath))
            {
                using var connection = new SqliteConnection($"Data Source={DbPath}");
                connection.Open();

                string schema = File.ReadAllText(
                    Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "schema.sql")
                );

                using var command = connection.CreateCommand();
                command.CommandText = schema;
                command.ExecuteNonQuery();
            }
        }
    }
}

