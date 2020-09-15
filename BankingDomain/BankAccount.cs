using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 1000M;
        public decimal GetBalance()
        {
            return _balance;
        }

        public virtual void Deposit(decimal amountToDeposit)
        {
            _balance += amountToDeposit;
        }

        public void Withdrawal(decimal amountToWithdrawal)
        {
            if(amountToWithdrawal > _balance)
            {
                throw new OverdraftException();
            }
            _balance -= amountToWithdrawal;

        }
    }
}