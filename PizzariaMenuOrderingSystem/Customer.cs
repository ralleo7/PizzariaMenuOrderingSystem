using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaMenuOrderingSystem
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }


        public Customer(int id, string name, string email, string address)
        {
            Id = id;
            Name = name;
            Address = address;
            Email = email;
        }
    }
}
