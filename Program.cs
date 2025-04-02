namespace OopsAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer c=new Customer();
            c.Display(1, "Anish", "Gupta", "anish@gmail.com", "8907654235", "23,indie nagar,delhi");

            Account a = new Account();
            a.accountNumber = 123;
            a.accountType = "Savings";
            a.accountBalance = 45000;

            a.Display();
            a.Deposit(1000);
            a.WithDraw(8000);
            a.CalculateInterest(4.5f);
            Console.WriteLine($"AccountBalance={a.accountBalance}");
        }

    }
}
