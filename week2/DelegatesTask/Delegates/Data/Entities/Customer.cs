using Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICustomerType CustomerType { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
