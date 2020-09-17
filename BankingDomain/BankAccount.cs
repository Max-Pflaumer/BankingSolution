using System;
using System.Collections.Generic;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 1000M;
        private ICalculateBankAccountBonuses _bonusCalculator;
        private INotifyTheFeds _fedNotifier;

        public BankAccount(ICalculateBankAccountBonuses bonusCalculator, INotifyTheFeds fedNotifier)
        {
            _bonusCalculator = bonusCalculator;
            _fedNotifier = fedNotifier;
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            if(amountToDeposit < 0) { throw new NoNegativeTransactionsException(); }
            decimal bonus = _bonusCalculator.GetDepositBonusFor(_balance, amountToDeposit);
            _balance += amountToDeposit + bonus;
        }

        public void Withdrawal(decimal amountToWithdrawal)
        {
            if (amountToWithdrawal < 0) { throw new NoNegativeTransactionsException(); }
            if (amountToWithdrawal > _balance)
            {
                throw new OverdraftException();
            }
            _balance -= amountToWithdrawal;

            //Notify the feds
            _fedNotifier.NotifyOfWithdrawl(this, amountToWithdrawal);
        }
        

    }
}