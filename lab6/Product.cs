using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Product
    {
        public int _id { get; }
        public string Name { get; }
        public string Colour { get; }
        public float Price { get; }
        public string Size { get;}

        public Product(string name, string colour, float price, string size)
        {
            Name = name;
            Colour = colour;
            Price = price;
            Size = size;
        }

        public override string ToString()
        {
            return $"Product: {Name}, costs: {Price}";
        }
    }
}
