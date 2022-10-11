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
        Expense maxExpense = new Expense();
        maxExpense.Amount = 1001;
        maxExpense.Type = ExpenseType.BREAKFAST;
        _expenseReport.PrintReport(new List<Expense> { maxExpense }, DateTime.Parse("2022-10-05"));
        var output = _stringWriter.ToString();
        Assert.Contains("Expenses 05-Oct-22 12:00:00 AM\r\nBreakfast\t1001\tX\r\nMeal expenses: 1001\r\nTotal expenses: 1001\r\n", _stringWriter.ToString());
    }

    [Fact]
    public void Print_Permutation()
    {
        //OPT Adria: create a list with expense objects instead of independent objects
        var expenses = new List<Expense>
        {
            new Expense { Amount = 999, Type = ExpenseType.BREAKFAST},
            new Expense { Amount = 1001, Type= ExpenseType.BREAKFAST},
            new Expense {Amount = 4999, Type = ExpenseType.DINNER},
            new Expense {Amount = 5001, Type = ExpenseType.DINNER},
            new Expense {Amount = 50, Type = ExpenseType.CAR_RENTAL }
        };
        _expenseReport.PrintReport(expenses, DateTime.Parse("2022-10-11"));
        var output = _stringWriter.ToString();
        Assert.Contains("Expenses 11-Oct-22 12:00:00 AM\r\nBreakfast\t999\t \r\nBreakfast\t1001\tX\r\nDinner\t4999\t \r\nDinner\t5001\tX\r\nCar Rental\t50\t \r\nMeal expenses: 12000\r\nTotal expenses: 12050\r\n", _stringWriter.ToString());

        //OPT mine
        //Expense belowBoundary = new Expense();
        //belowBoundary.Amount = 999;
        //belowBoundary.Type = ExpenseType.BREAKFAST;
        //Expense overBoundary = new Expense();
        //overBoundary.Amount = 1001;
        //overBoundary.Type = ExpenseType.BREAKFAST;
        //_expenseReport.PrintReport(new List<Expense> { belowBoundary,overBoundary }, DateTime.Parse("2022-10-11"));
        //Assert.Contains("Expenses 11-Oct-22 12:00:00 AM\r\nBreakfast\t999\t \r\nBreakfast\t1001\tX\r\nMeal expenses: 2000\r\nTotal expenses: 2000\r\n", _stringWriter.ToString());
    }

}
