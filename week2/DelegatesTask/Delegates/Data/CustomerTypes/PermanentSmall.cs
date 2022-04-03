using Data.Contracts;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CustomerTypes
{
    public class PermanentSmall : ICustomerType
    {
        public Func<decimal, decimal> Calculate(decimal amount)
        {
            return (x) => amount * 0.95m;
        }
    }
}
