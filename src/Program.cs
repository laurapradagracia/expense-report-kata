using ExpenseReports;

var worker = new Worker();
Console.WriteLine(worker.PrintFirstLine());

var expenses = new List<Expense>();

while(TryGetExpense(Console.ReadLine(), out Expense? expense))
{
    if(expense != null)
    {
        expenses.Add(expense);
    }
    
}
var expenseReport = new ExpenseReport();
expenseReport.PrintReport(expenses);

bool TryGetExpense(string input, out Expense? expense)
{
    var parts = input.Split(" ");
    if (string.IsNullOrWhiteSpace(input) ||
        !Enum.TryParse(parts.First(), true, out ExpenseType expenseType) ||
        ! int.TryParse(parts.Last(), out int amount))
    {
        expense = null;
        return false;
    }

    expense = new Expense { Amount = amount, Type = expenseType };
    return true;
}