using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaMenuOrderingSystem
{
    public class Pizza
    {
       public string Name { get; set; }
       public List<string> Toppings { get; set; }
       
       public double Price { get; set; }

        public int Id { get; set; }

        public Pizza(string name, List<string> toppings, double price, int id)  
        {
            Name = name;
            Toppings = toppings;
            Price = price;
            Id = id;
        }
        

    }
}
