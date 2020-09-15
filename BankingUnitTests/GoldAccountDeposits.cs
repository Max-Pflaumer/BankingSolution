using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class GoldAccountDeposits
    {
        [Fact]
        public void GoldAccountGetBonus()
        {
            var account = new GoldAccount();//Gold Deposit is the exact same as normal besides deposit
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100M;

            account.Deposit(amountToDeposit);

            Assert.Equal(openingBalance + amountToDeposit + 10M, account.GetBalance());

        }
    }
}
