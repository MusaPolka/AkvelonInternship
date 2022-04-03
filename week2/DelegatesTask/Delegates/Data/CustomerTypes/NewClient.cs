using Data.Contracts;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CustomerTypes
{
    public class NewClient : ICustomerType
    {
        public Func<decimal, decimal> Calculate(decimal amount)
        {
            return (x) => amount;
        }
    }
}
