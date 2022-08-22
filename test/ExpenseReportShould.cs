namespace ExpenseReports.Test;

public class ExpenseReportShould
{
    [Fact]
    public void Print_Empty_List()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        var date = new DateTime(2022, 08, 01);
        var expectedDate = date.ToString();
        var report = new ExpenseReport();
        report.PrintReport(new List<Expense>(), date);
        Assert.Equal($"Expenses {expectedDate}\r\nMeal expenses: 0\r\nTotal expenses: 0\r\n", stringWriter.ToString());
    }
}