using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ZopaHomework.Test
{
    [TestFixture]
    public class LoanDistributorTests
    {
        LendersList lendersList;

        [SetUp]
        public void TestSetup()
        {
            var lenders = new List<Lender>();
            lenders.Add(new Lender("Eve", 0.2, 2000));
            lenders.Add(new Lender("Ada", 0.1, 1000));
            lenders.Add(new Lender("Oto", 0.4, 4000));
            lendersList = new LendersList(lenders);
        }

        [Test]
        public void GetOnlyOneLenderWhenLenderHasEnougthFoundsForLoan()
        {
            var loan = 500;
            var distributor = new LoanDistributor();

            var reservedLenders = distributor.GetLowestInterestLenders(lendersList, loan);
            Assert.That(reservedLenders.Lenders.Count, Is.EqualTo(1));

            var reservedLender = reservedLenders.Lenders.First();
            Assert.That(reservedLender.Name, Is.EqualTo("Ada"));
            Assert.That(reservedLender.Founds, Is.EqualTo(500));
        }

        [Test]
        public void GetBestLendersRatesForLoan()
        {
            var loan = 1500;
            var distributor = new LoanDistributor();

            var reservedLenders = distributor.GetLowestInterestLenders(lendersList, loan);
            Assert.That(reservedLenders.Lenders.Count, Is.EqualTo(2));
            
            Assert.That(reservedLenders.Lenders.Any(l => l.Name == "Ada"), Is.True);
            Assert.That(reservedLenders.Lenders.Any(l => l.Name == "Eve"), Is.True);
        }

        [Test]
        public void ReservesOnlyNecessaryFounds()
        {
            var loan = 1500;
            var distributor = new LoanDistributor();

            var reservedLenders = distributor.GetLowestInterestLenders(lendersList, loan);
            Assert.That(reservedLenders.Lenders.Count, Is.EqualTo(2));
            
            Assert.That(reservedLenders.Lenders.Single(l => l.Name == "Eve").Founds, Is.EqualTo(500));
        }
    }
}
