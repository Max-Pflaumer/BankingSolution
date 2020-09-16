using System;
using System.Collections.Generic;
using System.Text;

namespace BankingDomain
{
    public class StandardBonusCalculator : ICalculateBankAccountBonuses
    {
        private IProvideTheCutoffClock _cutoffClock;

        public StandardBonusCalculator(IProvideTheCutoffClock cutoffClock)
        {
            _cutoffClock = cutoffClock;
        }

        public decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit)
        {
            //Accounts with at least 1000 AND it is before 5:00pm get 10%, otherwise 8%
            if (EligibleForBonus(balance))
            {
                if (_cutoffClock.BeforeCutoff())
                {
                    return amountToDeposit * 0.1M;
                }
                else
                {
                    return amountToDeposit * .08M;
                }
            }
            return 0;
        }
        //Virtual method allows us to override the method in the testing interface
        //Then we can override the method based on the test to test different scenarios
        protected virtual bool BeforeCutoff()
        {
            return DateTime.Now.Hour < 17; // This is the hidden variables tht could make a test fail
        }

        private bool EligibleForBonus(decimal balance)
        {
            return balance >= 1000;
        }
    }
}
