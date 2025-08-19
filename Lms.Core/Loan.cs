using System;

namespace Lms.Core
{
    public class Loan
    {
        public int Id { get; set; }
        public User Borrower { get; set; }
        public Book BorrowedBook { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Loan(int id, User borrower, Book borrowedBook, DateTime loanDate, DateTime dueDate)
        {
            Id = id;
            Borrower = borrower;
            BorrowedBook = borrowedBook;
            LoanDate = loanDate;
            DueDate = dueDate;
        }

        public bool IsReturned()
        {
            return ReturnDate.HasValue;
        }

        public override string ToString()
        {
            string status = IsReturned() ? $"Returned on {ReturnDate.Value.ToShortDateString()}" 
                                         : $"Due {DueDate.ToShortDateString()}";
            return $"{Id}: {Borrower.Name} borrowed '{BorrowedBook.Title}' on {LoanDate.ToShortDateString()} - {status}";
        }
    }
}
