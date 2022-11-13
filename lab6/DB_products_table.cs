using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class DB_products_table
    {
        private List<Product> products = new List<Product>();

        public DB_products_table Add(Product product)
        {
            products.Add(product);
            return this;
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public void Display()
        {
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
        }

        public List<Product> Filter(string name)
        {
            return products.Where(item => item.Name.Contains( name.ToLower() )).ToList();
        }

        public Product GetByName(string name)
        {
            return products.Find(item => item.Name == name);
        }
    }
}
