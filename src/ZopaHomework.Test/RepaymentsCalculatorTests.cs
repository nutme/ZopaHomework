using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ZopaHomework.Test
{
    [TestFixture]
    public class RepaymentsCalculatorTests
    {
        RepaymentsCalculator repaymentsCalculator;

        [SetUp]
        public void TestSetup()
        {
            repaymentsCalculator = new RepaymentsCalculator();
        }

        [Test]
        public void CanCalculateMonthlyRepaymentsWithCompoundInterest()
        {
            // conditions given by task:
            // Requested amount: £1000
            // Rate: 7.0 %
            // Monthly repayment: £30.78
            // Total repayment: £1108.10

            var loan = 1000.0;
            var rate = 0.07;
            var numberOfMonths = 36;

            var monthlyRepayment = repaymentsCalculator.CalculateMonthlyRepaymentsWithCompoundInterest(loan, rate, numberOfMonths);

            Assert.That(Math.Round(monthlyRepayment, 2), Is.EqualTo(30.78));
        }

        [Test]
        public void CanCalculateCalculateTotalRepayment()
        {
            var numberOfMonths = 36;
            var monthlyRepayment = 50;

            var totalRepayment = repaymentsCalculator.CalculateTotalRepayment(monthlyRepayment, numberOfMonths);

            Assert.That(totalRepayment, Is.EqualTo(1800));
        }

        [Test]
        public void CanCalculateWeightedAverageRate()
        {
            var lenders = new List<Lender>();
            lenders.Add(new Lender("Ada", 0.069, 460));
            lenders.Add(new Lender("Oto", 0.075, 4540));
            
            var average = repaymentsCalculator.AverageInterestCalculator(lenders.ToArray());

            Assert.That(Math.Round(average, 3), Is.EqualTo(0.074));
        }
    }
}
