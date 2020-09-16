using BankingDomain;
using BankingUnitTests.TestDoubles;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class AccountUsesBonusCalculator
    {
        [Fact]
        public void BonusIsAppliedToTheDeposit()
        {
            var stubbedBonusCalculator = new Mock<ICalculateBankAccountBonuses>();
            stubbedBonusCalculator.Setup(c => c.GetDepositBonusFor(1000, 500)).Returns(42);
            var account = new BankAccount(stubbedBonusCalculator.Object, new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();

            account.Deposit(500);

            Assert.Equal(openingBalance + 500 + 42, account.GetBalance()); 

        }
    }
}
