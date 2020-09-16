using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class AccountNotifiesFedsOnWithdrawl
    {
        [Fact]
        public void FedIsNotifiedOnWithdrawl()
        {
            //GIven
            var mockedFed = new Mock<INotifyTheFeds>();
            var account = new BankAccount(new Mock<ICalculateBankAccountBonuses>().Object, mockedFed.Object);

            //WHen
            account.Withdrawal(1);

            //Then
            //Did this method get called with those arguments
            mockedFed.Verify(f => f.NotifyOfWithdrawl(account, 1M));
        }

    }
}
