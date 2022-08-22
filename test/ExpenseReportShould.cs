namespace ExpenseReports.Test;

public class ExpenseReportShould
{
    [Fact]
    public void Print_Empty_List()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var report = new ExpenseReport();
        report.PrintReport(new List<Expense>());
        Assert.Equal("Expenses 22/08/2022 12:23:39\r\nMeal expenses: 0\r\nTotal expenses: 0", stringWriter.ToString());
    }
}