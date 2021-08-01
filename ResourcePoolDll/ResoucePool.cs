using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcePoolDll
{
    public static class ResoucePool
    {
        static Queue<Resource> Pool;
        public static bool IsClosing { get; set; }
        public static int CurrentPoolSize { get => Pool?.Count ?? 0; }

        static ResoucePool()
        {
            Console.WriteLine("Pool Created");
            Pool = new Queue<Resource>();
        }

        public static Resource GetResouce()
        {
            if ((Pool?.Count ?? 0) > 0)
                return Pool.Dequeue();
            return new Resource();
            //var resources = new Resource();
            //return(Resource) Activator.CreateInstance(typeof(Resource),true);
        }

        public static void AddResouceToPool(Resource resource)
        {
            if ((!IsClosing)&&(!Pool.Contains(resource)))
                Pool.Enqueue(resource);
        }

        
    }
}
