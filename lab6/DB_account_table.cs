using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class DB_account_table
    {
        private List<Account> accounts = new List<Account>();
        public DB_account_table Add(Account account)
        {
            accounts.Add(account);
            return this;
        }
        public List<Account> GetAccounts()
        {
            return accounts;
        }
    }
}
