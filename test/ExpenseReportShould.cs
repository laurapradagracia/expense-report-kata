namespace ExpenseReports.Test;

public class ExpenseReportShould
{
    private readonly StringWriter _stringWriter = new StringWriter();
    public ExpenseReportShould()
    {
        Console.SetOut(_stringWriter);
    }

    [Fact]
    public void Print_Empty_List()
    {
        
        Assert.True(false);
    }

}