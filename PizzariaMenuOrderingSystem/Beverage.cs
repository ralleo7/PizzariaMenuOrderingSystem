using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaMenuOrderingSystem
{
    public class Beverage
    {
        public string Name { get; set; }


        public double Price { get; set; }

        public int Id { get; set; }

        public Beverage(string name, double price, int id)
        {
            Name = name;
            Price = price;
            Id = id;
        }
    }
}
