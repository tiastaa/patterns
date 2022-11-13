using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class AccountManager
    {
         public DB_account_table DB_accounts = new DB_account_table()
            .Add(new Account("Nika", "nika@gmail.com", "84943"))
            .Add(new Account("Vitya", "vitya@gmail.com", "46777"))
            .Add(new Account("Sofi", "sofi@gmail.com", "46676"));

        public Account account = null;

        public AccountManager LogIn()
        {
            if (account == null)
            {
                Console.WriteLine("Username: ");
                string username = Console.ReadLine();
                string password;

                Account acc = DB_accounts.GetAccounts().Find(item => item._username == username);
                if (acc != null)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        Console.WriteLine("Password: ");
                        password = Console.ReadLine();
                        if (acc._password == password)
                        {
                            account = acc;
                            Console.WriteLine("Success!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong password");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Wrong username");
                }
            }
            else
            {
                Console.WriteLine("Already logged");
            }
            return this;
        }

        public AccountManager LogOut()
        {
            account = null;
            Console.WriteLine("Logged out succesfully");
            return this;
        }

        public AccountManager AddToBasket(Product product)
        {
            account.basket.Add(product);
            return this;
        }
    }
}
