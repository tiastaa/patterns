using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Site
    {
        private DB_products_table DB_products = new DB_products_table()
            .Add(new Product("short", "black", 570, "m"))
            .Add(new Product("pants", "white", 2000, "s"))
            .Add(new Product("hat", "brown", 150, "xs"));

        private AccountManager accountManager = new AccountManager();

        public Site()
        {

        }

        public void Display()
        {
            DB_products.Display();
        }

        public void LogIn()
        {
            accountManager.LogIn();
        }

        public void LogOut()
        {
            accountManager.LogOut();
        }

        public void AddToBasket(string name)
        {
            Product product = DB_products.GetByName(name);
            if (product != null)
            {
                accountManager.AddToBasket(product);
            }
            else
            {
                Console.WriteLine("no such product");
            }
        }
        public void AddToFavourite(string name)
        {
            Product product = DB_products.GetByName(name);
            if (product != null)
            {
                accountManager.AddToFavourite(product);
            }
            else
            {
                Console.WriteLine("no such product");
            }
        }
    }
}
