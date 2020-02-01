using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedAnnealing
{
    class RandomP
    {
        private static Random global = new Random();
        [ThreadStatic]
        private static Random local;

        public static double NextDouble()
        {
            Random instance = local;
            if(instance==null)
            {
                int seed;
                lock (global) seed = global.Next();
                local = instance = new Random(seed);
            }
            return instance.NextDouble();
        }
    }
}
