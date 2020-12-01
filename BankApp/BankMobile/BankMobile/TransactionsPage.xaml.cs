using Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BankMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionsPage : ContentPage
    {
        private BankAccount _account;

        public BankAccount Account
        {
            get { return _account; }
            set { _account = value; }
        }

        public TransactionsPage(BankAccount account)
        {
            InitializeComponent();

            Title = "View Transaction";

            Account = account;

            BindingContext = Account;
        }
    }
}