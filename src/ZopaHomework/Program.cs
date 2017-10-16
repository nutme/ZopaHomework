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

            var loanCalculator = new LoanCalculator(new LoanDistributor());
            var deal = loanCalculator.GetDeal(lenders, requestedLoan);
            
            Console.WriteLine($"Requested amount: £{requestedLoan}");
            Console.WriteLine($"Rate: {deal.Rate}%");
            Console.WriteLine($"Monthly repayment: £{deal.MonthlyRepayment}");
            Console.WriteLine($"Total repayment: £{deal.TotalRepayment}");

            Console.ReadKey();
        }
    }
}
