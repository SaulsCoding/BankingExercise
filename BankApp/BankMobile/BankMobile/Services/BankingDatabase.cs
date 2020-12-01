using Banking;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankMobile.Services
{
    public class BankingDatabase
    {
        private SQLiteConnection _database;

        public BankingDatabase()
        {
            var path = GetDbPath();
            _database = new SQLiteConnection(path);

            _database.CreateTable<Bank>();
            _database.CreateTable<Customer>();
            _database.CreateTable<BankAccount>();
            _database.CreateTable<Transaction>();

            SeedDatabase();
        }

        public string GetDbPath()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "banking.db");
            return path;
        }

        public void SeedDatabase()
        {
            if (_database.Table<Bank>().Count() == 0)
            {
                Bank fnb = new Bank("First National Bank", 4324, "Kenilworth");
                Customer myNewCustomer = new Customer("7766445424", "10 me at home", "Bob", "The Builder");
                fnb.AddCustomer(myNewCustomer);

                _database.Insert(myNewCustomer);
                _database.Insert(fnb);

                _database.UpdateWithChildren(fnb);
                var account = myNewCustomer.ApplyForBankAccount();
                _database.Insert(account);
                _database.UpdateWithChildren(myNewCustomer);

            }
        }

    }
}