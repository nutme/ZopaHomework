using System;

namespace ZopaHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvFileName = args[0].ToString();
            var requestedLoan = int.Parse(args[1]);
            
            var lenders = LendersList.LoadFromCsvFile(csvFileName);

            if (requestedLoan <= 0 || requestedLoan > lenders.TotalMoneyAvailable())
            {
                Console.WriteLine($"it is not possible to provide a quote at this time");
                return;
            }

            var rate = "unknown";
            var monthlyRepayment = "unknown";
            var totalRepayment = "unknown";

            Console.WriteLine($"Requested amount: £{requestedLoan}");
            Console.WriteLine($"Rate: {rate}%");
            Console.WriteLine($"Monthly repayment: £{monthlyRepayment}");
            Console.WriteLine($"Total repayment: £{totalRepayment}");

            Console.ReadKey();
        }
    }
}
