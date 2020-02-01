using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class RandomGenerator
    {
        //Generate n random  double value beetween 0-1
        public static double[] Generate(int n)
        {
            Random rand = new Random();
            double[] rnd = new double[n];
            for (int i = 0; i < n; i++)
            {
                rnd[i] = rand.NextDouble();
            }
            return rnd;
        }
    }
}
