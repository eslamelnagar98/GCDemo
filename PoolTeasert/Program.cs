using ResourcePoolDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolTeasert
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var resource = ResoucePool.GetResouce())
            {
                Console.WriteLine($"R01 {resource.GetHashCode()}");
                resource.DoSomeResouceWork();
            }
            //GC.Collect();
            //resource = null;

            int x = int.Parse(Console.ReadLine());
            ++x;
            Console.WriteLine(x);
            Console.ReadLine();

            using (var rresouce2 = ResoucePool.GetResouce())
            {
                Console.WriteLine($"R02 {rresouce2.GetHashCode()}");
                rresouce2.DoSomeResouceWork();
            }

            using (var rresouce3 = ResoucePool.GetResouce())
            {
                Console.WriteLine($"R03 {rresouce3.GetHashCode()}");
                rresouce3.DoSomeResouceWork();
            }

            ResoucePool.IsClosing = true;
        }

    }
}
