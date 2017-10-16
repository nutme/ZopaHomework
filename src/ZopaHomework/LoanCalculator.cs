namespace ZopaHomework
{
    public class LoanCalculator
    {
        private LoanDistributor loanDistributor;

        public LoanCalculator(LoanDistributor loanDistributor)
        {
            this.loanDistributor = loanDistributor;
        }

        public dynamic GetDeal(LendersList lenders, int requestedLoan)
        {
            var reservedLenders = loanDistributor.GetLowestInterestLenders(lenders, requestedLoan);

            return null;
        }
    }
}
