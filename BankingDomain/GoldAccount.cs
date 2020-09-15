namespace BankingDomain
{
    public class GoldAccount : BankAccount //Gold account inherits bank account
    {
        public override void Deposit(decimal amountToDeposit)
        {
            base.Deposit(amountToDeposit * 1.10M);
        }
    }
}