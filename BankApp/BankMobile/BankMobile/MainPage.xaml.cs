using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Banking;

namespace BankMobile
{
    public partial class MainPage : ContentPage
    {

        
        private BankAccount _account;
        public MainPage()
        {
            InitializeComponent();

            Bank fnb = new Bank("First National Bank", 4324, "Kenilworth");
            Customer myNewCustomer = new Customer("7766445424", "10 me at home", "Bob", "The Builder");
            fnb.AddCustomer(myNewCustomer);
            
            _account = myNewCustomer.ApplyForBankAccount();

        }

        private void DepositButton_Clicked(object sender, EventArgs e)
        {
            decimal depositAmountEntry = 0;
            var valid = decimal.TryParse(depositAmount.Text, out depositAmountEntry);
            var reason = depositReason.Text;

            if (valid)
            {
                _account.DepositMoney(depositAmountEntry, DateTime.Now, reason);
            }
            else
            {
                DisplayAlert("Validation Error", "Please Enter Number", "Cancel");
            }
        }

        private void DisplayTransactionsButton_Clicked(object sender, EventArgs e)
        {
            
            //DisplayTransactionsLabel.Text = _account.GetTransactionHistory();
            Navigation.PushAsync(new TransactionsPage(_account));//give page some context and some data
        }

       
    }
}
