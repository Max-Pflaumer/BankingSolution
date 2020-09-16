using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class StandardBonusCalculatorTests
    {
        //Balances below 1000 never get a bonus (Before or after the cutoff)
        //Balances over 1000
        //      - Before cutoff get 10%
        //      - After cutoff get 8%
        // These tests have a hidden input with Time so they can't all pass at once
        [Fact]
        public void BonusBeforeCutoff()
        {
            var cutoffClockStub = new Mock<IProvideTheCutoffClock>();
            cutoffClockStub.Setup(c => c.BeforeCutoff()).Returns(true);
            var calculator = new StandardBonusCalculator(cutoffClockStub.Object);
            var bonus = calculator.GetDepositBonusFor(1000, 100);
            Assert.Equal(10, bonus);
        }

        [Fact]
        public void BonusAfterCutoff()
        {
            var cutoffClockStub = new Mock<IProvideTheCutoffClock>();
            cutoffClockStub.Setup(c => c.BeforeCutoff()).Returns(false);
            var calculator = new StandardBonusCalculator(cutoffClockStub.Object);
            var bonus = calculator.GetDepositBonusFor(1000, 100);
            Assert.Equal(8, bonus);
        }
    }

    ////Helps fix the testing issue
    //public class BeforeCutoffBonusCalculator : StandardBonusCalculator
    //{
    //    protected override bool BeforeCutoff()
    //    {
    //        return true;
    //    }
    //}

    //public class AfterCutoffBonusCalculator : StandardBonusCalculator
    //{
    //    protected override bool BeforeCutoff()
    //    {
    //        return false;
    //    }
    //}
}
