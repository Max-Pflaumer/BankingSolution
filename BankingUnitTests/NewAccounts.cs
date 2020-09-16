using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BankingDomain;
using BankingUnitTests.TestDoubles;

namespace BankingUnitTests
{
    public class NewAccounts
    {
        [Fact]
        public void NewAccountsHaveCorrectBalance()
        {
            //Given
            var account = new BankAccount(new DummyBonusCalculator());

            //When
            decimal balance = account.GetBalance();

            //Then

            Assert.Equal(1000M, balance);
        }
    }
}
