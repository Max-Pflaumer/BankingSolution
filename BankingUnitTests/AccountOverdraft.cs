using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class AccountOverdraft
    {
        /*
         * Given we have account with a balance
         * When I take out more money than the balance
         * Then
         *  -   The amount of the withdrawal should *not* be removed from the balance
         *  - There should be an exception thrown
         *  
         */

        [Fact]
        public void BalanceStaysTheSame()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            try
            {
                account.Withdrawal(openingBalance + 1M);
            }
            catch (OverdraftException)
            {

                throw new OverdraftException();
            }

            Assert.Equal(openingBalance, account.GetBalance());
        }

        [Fact]
        public void OverDraftGivesException()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            account.Withdrawal(openingBalance + 1M);

            Assert.Throws<OverdraftException>(() => account.Withdrawal(openingBalance + 1M));
        }
    }
}
