using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BankingDomain;

namespace BankingUnitTests
{
    public class NewAccounts
    {
        [Fact]
        public void NewAccountsHaveCorrectBalance()
        {
            //Given
            var account = new BankAccount();

            //When
            decimal balance = account.GetBalance();

            //Then

            Assert.Equal(1000M, balance);
        }
    }
}
