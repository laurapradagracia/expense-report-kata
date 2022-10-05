namespace ExpenseReports.Test;

public class ExpenseReportShould
{
    private readonly ExpenseReport _expenseReport = new ExpenseReport();
    private readonly StringWriter _stringWriter = new StringWriter();
    public ExpenseReportShould()
    {
        Console.SetOut(_stringWriter);
    }

    [Fact]
    public void Print_Empty_List()
    {
        _expenseReport.PrintReport(new List<Expense>(), DateTime.Parse("2022-10-05"));
        Assert.Contains("Expenses 05-Oct-22 12:00:00 AM\r\nMeal expenses: 0\r\nTotal expenses: 0", _stringWriter.ToString());
    }

    [Fact]
    public void Print_Below_Min()
    {
        Expense minExpense = new Expense();
        minExpense.Amount = 1;
        minExpense.Type = ExpenseType.BREAKFAST;
        _expenseReport.PrintReport(new List<Expense> { minExpense }, DateTime.Parse("2022-10-05"));
        Assert.Contains("Expenses 05-Oct-22 12:00:00 AM\r\nBreakfast\t1\t \r\nMeal expenses: 1\r\nTotal expenses: 1\r\n", _stringWriter.ToString());
    }

    [Fact]
    public void Print_Above_Max()
    {
        Expense minExpense = new Expense();
        minExpense.Amount = 1001;
        minExpense.Type = ExpenseType.BREAKFAST;
        _expenseReport.PrintReport(new List<Expense> { minExpense }, DateTime.Parse("2022-10-05"));
        var output = _stringWriter.ToString();
        Assert.Contains("Expenses 05-Oct-22 12:00:00 AM\r\nBreakfast\t1001\tX\r\nMeal expenses: 1001\r\nTotal expenses: 1001\r\n", _stringWriter.ToString());
    }

}
