using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    public class Expense
    {
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public string Notes { get; set; }

        public Expense(decimal amount, string category, DateTime date, string notes)
        {
            Amount = amount;
            Category = category;
            Date = date;
            Notes = notes;
        }
    }
}