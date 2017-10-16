using System;

namespace ZopaHomework
{
    class Program
    {
        private static readonly int loanPeriodInMonths = 36;

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

            var loanCalculator = new LoanCalculator(new LoanDistributor(), new RepaymentsCalculator());
            var deal = loanCalculator.GetDeal(lenders, requestedLoan, loanPeriodInMonths);
            
            Console.WriteLine($"Requested amount: £{requestedLoan}");
            Console.WriteLine($"Rate: {Math.Round(deal.Rate * 100, 1, MidpointRounding.AwayFromZero).ToString("0.0")}%");
            Console.WriteLine($"Monthly repayment: £{Math.Round(deal.MonthlyRepayment, 2, MidpointRounding.AwayFromZero).ToString("0.00")}");
            Console.WriteLine($"Total repayment: £{Math.Round(deal.TotalRepayment, 2, MidpointRounding.AwayFromZero).ToString("0.00")}");
        }
    }
}
