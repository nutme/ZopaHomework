using System.Collections.Generic;
using System.Linq;

namespace ZopaHomework
{
    public class LoanDistributor
    {
        public LendersList GetLowestInterestLenders(LendersList availableLenders, double loanRequested)
        {
            double cashReserved = 0;
            var lenders = new List<Lender>();

            var lendersSortedByInterest = availableLenders.Lenders.OrderBy(l => l.Rate).ToList();

            while (cashReserved < loanRequested)
            {
                var cashNeeded = loanRequested - cashReserved;
                var lender = lendersSortedByInterest.First();

                if (lender.Founds >= cashNeeded)
                {
                    lenders.Add(new Lender(lender.Name, lender.Rate, cashNeeded));
                    cashReserved += cashNeeded;
                }
                else
                {
                    lenders.Add(lender);
                    cashReserved += lender.Founds;
                }

                lendersSortedByInterest.Remove(lender);
            }

            return new LendersList(lenders);
        }
    }
}
