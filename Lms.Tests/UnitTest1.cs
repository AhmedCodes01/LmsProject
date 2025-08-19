using System;
using Lms.Core;
using Xunit;

namespace Lms.Tests
{
    public class CoreTests
    {
        [Fact]
        public void CanCreateBook()
        {
            var book = new Book(1, "1984", "George Orwell", "123456789", 1949);
            Assert.Equal("1984", book.Title);
            Assert.True(book.IsAvailable);
        }

        [Fact]
        public void BorrowedBookIsNotAvailable()
        {
            var book = new Book(1, "Dune", "Frank Herbert", "987654321", 1965);
            var user = new User(1, "Alice", "alice@example.com");
            var loan = new Loan(1, user, book, DateTime.Now, DateTime.Now.AddDays(14));
            book.IsAvailable = false;

            Assert.False(book.IsAvailable);
            Assert.False(loan.IsReturned());
        }

        [Fact]
        public void ReturnedBookBecomesAvailable()
        {
            var book = new Book(1, "Dune", "Frank Herbert", "987654321", 1965);
            var user = new User(1, "Alice", "alice@example.com");
            var loan = new Loan(1, user, book, DateTime.Now, DateTime.Now.AddDays(14));
            book.IsAvailable = false;

            loan.ReturnDate = DateTime.Now;
            book.IsAvailable = true;

            Assert.True(loan.IsReturned());
            Assert.True(book.IsAvailable);
        }
    }
}
