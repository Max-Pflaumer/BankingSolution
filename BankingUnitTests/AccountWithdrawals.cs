using BankingDomain;
using BankingUnitTests.TestDoubles;
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
            var account = new BankAccount(new DummyBonusCalculator());
            var openingBalance = account.GetBalance();
            var amountToWithdrawal = 1M;

            account.Withdrawal(amountToWithdrawal);

            Assert.Equal(openingBalance - amountToWithdrawal, account.GetBalance());
        }

        [Fact]
        public void CanTakeAllYourMoney()
        {
            var account = new BankAccount(new DummyBonusCalculator());

            account.Withdrawal(account.GetBalance());

            Assert.Equal(0, account.GetBalance());
        }
    }
}
