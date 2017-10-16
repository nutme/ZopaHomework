using System;
using System.Linq;

namespace ZopaHomework
{
    public class RepaymentsCalculator
    {
        public double CalculateMonthlyRepaymentsWithCompoundInterest(double loan, double rate, int loanPeriodInMonths)
        {
            //  effective interest rate
            //  https://en.wikipedia.org/wiki/Effective_interest_rate#Calculation

            var monthlyRate = Math.Pow((1.0 + rate), (1.0 / 12)) - 1.0;

            // As debt is repayed amoung interest is calculated from is decreesing with the time
            // http://www.financeformulas.net/Loan_Payment_Formula.html
            // d = (r s)/(1 - (1 + r)^-n)
            // s = value of loan
            // d = periodic repayment
            // r = periodic interest rate
            // n = number of periods

            var monthlyRepayment = (monthlyRate * loan) / (1.0 - Math.Pow((1 + monthlyRate), loanPeriodInMonths * -1.0));

            return monthlyRepayment;
        }

        public double CalculateTotalRepayment(double monthlyRepayments, int loanPeriodInMonths)
        {
            return monthlyRepayments * loanPeriodInMonths;
        }

        public double AverageInterestCalculator(Lender[] lenders)
        {
            // weighted average 
            // https://www.wikihow.com/Calculate-Weighted-Average

            var allWeight = lenders.Select(l => l.Founds).Sum();
            var averageInterest = 0.0;

            foreach(var lender in lenders)
            {
                averageInterest += (lender.Rate * lender.Founds) / allWeight;
            }

            return averageInterest;
        }
    }
}
