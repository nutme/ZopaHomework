using NUnit.Framework;
using System.Collections.Generic;

namespace ZopaHomework.Test
{
    [TestFixture]
    public class LendersListTests
    {
        [Test]
        public void ShouldCalculateTotalMoneyAvailable()
        {
            var lenders = new List<Lender>();
            lenders.Add(new Lender("Ada", 0.1, 1000));
            lenders.Add(new Lender("Oto", 0.4, 4000));
            var lendersList = new LendersList(lenders);

            Assert.That(lendersList.TotalMoneyAvailable(), Is.EqualTo(5000));
        }

        [Test]
        public void ShouldCalculateTotalMoneyAvailableWithNoLenders()
        {
            var lenders = new List<Lender>();
            var lendersList = new LendersList(lenders);

            Assert.That(lendersList.TotalMoneyAvailable(), Is.EqualTo(0));
        }
    }
}
