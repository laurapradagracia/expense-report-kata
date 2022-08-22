namespace ExpenseReports
{
    public enum ExpenseType
    {
        DINNER, BREAKFAST, CAR_RENTAL
    }

    public class Expense
    {
        public ExpenseType Type { get; set; }
        public int Amount { get; set; }
    }

    public class ExpenseReport
    {
        public void PrintReport(List<Expense> expenses)
        {
            PrintReport(expenses, DateTime.Now);
        }

        public void PrintReport(List<Expense> expenses, DateTime dateTime)
        {
            int total = 0;
            int mealExpenses = 0;

            Console.WriteLine("Expenses " + dateTime);

            foreach (Expense expense in expenses)
            {
                if (expense.Type == ExpenseType.DINNER || expense.Type == ExpenseType.BREAKFAST)
                {
                    mealExpenses += expense.Amount;
                }

                String expenseName = "";
                switch (expense.Type)
                {
                    case ExpenseType.DINNER:
                        expenseName = "Dinner";
                        break;
                    case ExpenseType.BREAKFAST:
                        expenseName = "Breakfast";
                        break;
                    case ExpenseType.CAR_RENTAL:
                        expenseName = "Car Rental";
                        break;
                }

                String mealOverExpensesMarker =
                    expense.Type == ExpenseType.DINNER && expense.Amount > 5000 ||
                    expense.Type == ExpenseType.BREAKFAST && expense.Amount > 1000
                        ? "X"
                        : " ";

                Console.WriteLine(expenseName + "\t" + expense.Amount + "\t" + mealOverExpensesMarker);

                total += expense.Amount;
            }

            Console.WriteLine("Meal expenses: " + mealExpenses);
            Console.WriteLine("Total expenses: " + total);
        }
    }
}
