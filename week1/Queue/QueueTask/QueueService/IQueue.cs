using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueService
{
    public interface IQueue<T>
    {
        void Enqueue(T num);
        T Dequeue();
        T Peek();
    }
}
