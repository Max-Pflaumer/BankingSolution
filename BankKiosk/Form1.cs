using BankingDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankKiosk
{
    public partial class Form1 : Form
    {
        BankAccount _account;
        public Form1(BankAccount account)
        {
            InitializeComponent();
            _account = account;
            UpdateUi();
        }

        private void UpdateUi()
        {
            this.Text = $"Your balance is {_account.GetBalance():c}";
        }
        public void NotifyOfWithdrawl(BankAccount bankAccount, decimal amountToWithdrawal)
        {
            MessageBox.Show($"Notifying the feds of your withdrawal of {amountToWithdrawal:c}");
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Deposit);
        }

        private void btnWithdrawal_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Withdrawal);
        }

        private void DoTransaction(Action<decimal> op) // Actions can be used to send a specific function as a param
        {   //Must pass in a methods that returns a void and takes in a decimal
            //Doesn't have to return void, but this specific one does
          //Can create your delegate types to have different returns
           //Action can take up to 16 arguments
        //If you are returnng soemthing use Func keyword(same as action, just gives return value
            try
            {
                var amount = int.Parse(txtAmount.Text);
                op(amount);
                UpdateUi();
            }
            catch (FormatException)
            {

                MessageBox.Show("Enter a number genius", "Bad Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverdraftException)
            {
                MessageBox.Show("You don't have enough money", "Bad Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch(NoNegativeTransactionsException)
            {
                MessageBox.Show("Use positive numbers", "Bad Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {   //These actions will happen whethere there was an exception or not
                txtAmount.SelectAll();
                txtAmount.Focus();
            }
        }

        
    }
}
