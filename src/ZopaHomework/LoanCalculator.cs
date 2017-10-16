using System.Linq;

namespace ZopaHomework
{
    public class LoanCalculator
    {
        private LoanDistributor loanDistributor;
        public RepaymentsCalculator repaymentsCalculator;

        public LoanCalculator(LoanDistributor loanDistributor, RepaymentsCalculator repaymentsCalculator)
        {
            this.loanDistributor = loanDistributor;
            this.repaymentsCalculator = repaymentsCalculator;
        }

        public dynamic GetDeal(LendersList lenders, int requestedLoan, int loanPeriodInMonths)
        {
            var reservedLenders = loanDistributor.GetLowestInterestLenders(lenders, requestedLoan);

            var totalMonthlyRepayment = reservedLenders.Lenders.Select(
                    l => repaymentsCalculator.CalculateMonthlyRepaymentsWithCompoundInterest(l.Founds, l.Rate, loanPeriodInMonths)
                ).Sum();

            var totalRepayment = repaymentsCalculator.CalculateTotalRepayment(totalMonthlyRepayment, loanPeriodInMonths);

            var averageRate = repaymentsCalculator.AverageInterestCalculator(reservedLenders.Lenders.ToArray());

            return new {
                Rate = averageRate,
                MonthlyRepayment = totalMonthlyRepayment,
                TotalRepayment  = totalRepayment
            };
        }
    }
}