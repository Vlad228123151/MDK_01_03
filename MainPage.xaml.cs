using System.Collections.ObjectModel;

namespace ExpenseTracker;

public partial class MainPage : ContentPage
{
    private ExpenseManager _expenseManager = new ExpenseManager();
    private ObservableCollection<Expense> _expensesCollection = new ObservableCollection<Expense>();

    public MainPage()
    {
        InitializeComponent();

        // Инициализация списка категорий
        CategoryPicker.ItemsSource = new List<string> { "Еда", "Транспорт", "Развлечения", "Другое" };

        // Привязка ListView к ObservableCollection
        ExpensesListView.ItemsSource = _expensesCollection;

        UpdateTotalExpenses();
    }

    private async void OnAddExpenseClicked(object sender, EventArgs e)
    {
        if (decimal.TryParse(AmountEntry.Text, out decimal amount) && CategoryPicker.SelectedItem != null && DateEntry.Date != null)
        {
            string category = CategoryPicker.SelectedItem.ToString();
            DateTime date = DateEntry.Date;
            string notes = NotesEntry.Text;

            _expenseManager.AddExpense(amount, category, date, notes);

            // Обновление ObservableCollection для отображения в ListView
            _expensesCollection.Clear();
            foreach (var expense in _expenseManager.GetExpenses())
            {
                _expensesCollection.Add(expense);
            }

            UpdateTotalExpenses();

            // Очистка полей ввода
            AmountEntry.Text = string.Empty;
            CategoryPicker.SelectedItem = null;
            DateEntry.Date = DateTime.Now;
            NotesEntry.Text = string.Empty;
        }
        else
        {
            await DisplayAlert("Ошибка", "Пожалуйста, заполните все поля корректно.", "OK");
        }
    }

    private void UpdateTotalExpenses()
    {
        TotalExpensesLabel.Text = $"Всего потрачено: {_expenseManager.GetTotalExpenses():C}";
    }

    private async void OnDeleteExpenseClicked(object sender, EventArgs e)
    {
        var expenseToDelete = (Expense)((ImageButton)sender).CommandParameter;

        bool answer = await DisplayAlert("Удалить", "Вы уверены, что хотите удалить этот расход?", "Да", "Нет");
        if (answer)
        {
            _expensesCollection.Remove(expenseToDelete); // Удаляем из ObservableCollection
            _expenseManager.GetExpenses().Remove(expenseToDelete); // Удаляем из списка ExpenseManager
            UpdateTotalExpenses();
        }
    }
}