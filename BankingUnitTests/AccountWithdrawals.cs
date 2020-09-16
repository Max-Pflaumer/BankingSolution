using BankingDomain;
using BankingUnitTests.TestDoubles;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class AccountWithdrawals
    {
        [Fact]
        public void WithdrawalDecreasesBalance()
        {
            var account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();
            var amountToWithdrawal = 1M;

            account.Withdrawal(amountToWithdrawal);

            Assert.Equal(openingBalance - amountToWithdrawal, account.GetBalance());
        }

        [Fact]
        public void CanTakeAllYourMoney()
        {
            var account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFeds>().Object);

            account.Withdrawal(account.GetBalance());

            Assert.Equal(0, account.GetBalance());
        }
    }
}
