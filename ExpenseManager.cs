using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    public class ExpenseManager
    {
        private List<Expense> _expenses = new List<Expense>();

        public void AddExpense(decimal amount, string category, DateTime date, string notes)
        {
            Expense newExpense = new Expense(amount, category, date, notes);
            _expenses.Add(newExpense);
        }

        public List<Expense> GetExpenses()
        {
            return _expenses;
        }

        public List<Expense> GetExpensesByCategory(string category)
        {
            return _expenses.Where(e => e.Category == category).ToList();
        }

        public List<Expense> GetExpensesByDate(DateTime date)
        {
            return _expenses.Where(e => e.Date.Date == date.Date).ToList();
        }

        public decimal GetTotalExpenses()
        {
            return _expenses.Sum(e => e.Amount);
        }

        public decimal GetTotalExpensesByCategory(string category)
        {
            return _expenses.Where(e => e.Category == category).Sum(e => e.Amount);
        }

        public decimal GetTotalExpensesByDate(DateTime date)
        {
            return _expenses.Where(e => e.Date.Date == date.Date).Sum(e => e.Amount);
        }

        public void ClearExpenses()
        {
            _expenses.Clear();
        }
    }
}