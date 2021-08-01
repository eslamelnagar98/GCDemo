using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResourcePoolDll
{
    public class Resource:IDisposable
    {
        static int Counter;
        public string Name { get; set; }
        public DateTime TimeStamp { get; } = DateTime.Now;
        
        internal Resource()
        {
            Console.WriteLine("Ctor Started");
            Name = $"Resource {++Counter}";
            Thread.Sleep(2000);
            Console.WriteLine($"Ctor {Name} finsihed");

        }

        public void DoSomeResouceWork()
        {
                Console.WriteLine($"Using Resource {Name} {TimeStamp.ToLongTimeString()}");
        }

        public void Dispose()
        {
            ResoucePool.AddResouceToPool(this);
            GC.SuppressFinalize(this);
        }

        ~ Resource()
        {
            if (!ResoucePool.IsClosing)
            {
                ResoucePool.AddResouceToPool(this);
                //Re Add This To Finalization List
                GC.ReRegisterForFinalize(this);
                Console.WriteLine("Dest");
            }
        }
    }
}
