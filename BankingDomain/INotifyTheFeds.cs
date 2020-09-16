namespace BankingDomain
{
    public interface INotifyTheFeds
    {
        void NotifyOfWithdrawl(BankAccount bankAccount, decimal amountToWithdrawal);
    }
}