using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableTask
{
    public class Customer : IDisposable
    {
        private StringReader _reader;
        private bool disposed;

        public Customer(string s)
        {
            this._reader = new StringReader(s);
        }

        public void Print()
        {
            if (disposed)
            {
                Console.WriteLine("Reference has already disposed");
            }
            else
            {
                Console.WriteLine(_reader.ReadToEnd());
            } 
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (disposed)
            {
                return;
            }

            if (dispose)
            {
                _reader.Dispose();
            }

            disposed = true;
        }

        ~Customer()
        {
            _reader.Dispose();
        }
    }
}
