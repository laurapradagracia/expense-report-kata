namespace ExpenseReports.Test;

public class ExpenseReportShould
{
    private readonly ExpenseReport _expenseReport = new ExpenseReport();
    private readonly StringWriter _stringWriter = new StringWriter();
    private readonly DateTime _currentDate = new DateTime(2022, 08, 01);
    public ExpenseReportShould()
    {
        Console.SetOut(_stringWriter);
    }
    [Fact]
    public void Print_Empty_List()
    {
        var expectedDate = _currentDate.ToString();
        _expenseReport.PrintReport(new List<Expense>(), _currentDate);
        Assert.Equal($"Expenses {expectedDate}\r\nMeal expenses: 0\r\nTotal expenses: 0\r\n", _stringWriter.ToString());
    }
}