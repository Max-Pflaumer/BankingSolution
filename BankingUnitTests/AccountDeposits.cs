using BankingDomain;
using BankingUnitTests.TestDoubles;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class AccountDeposits
    {
        [Fact]
        public void DepositIncreasesBalance()
        {
            //given
            var account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();
            var amountToDeposit = 5M;

            //When 
            account.Deposit(amountToDeposit);

            //Then
            Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());

        }
    }
}
