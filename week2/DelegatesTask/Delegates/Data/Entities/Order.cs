using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; } = 0;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();
    }
}
