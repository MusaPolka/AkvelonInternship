using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface ICustomerType
    {
        Func<decimal, decimal> Calculate(decimal amount);
    }
}
