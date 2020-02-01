using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimulatedAnnealing
{
    class SimulatedAnnealing
    {
        public bool[] knapsack;
        Knapsack process;
        public SimulatedAnnealing()
        {
            process = new Knapsack();
            Random rnd = new Random();
            Dictionary<int, double> ratios = new Dictionary<int, double>();
            for (int i = 0; i < Knapsack.weights.Count; i++)
            {
                ratios[i] = Knapsack.values[i] / Convert.ToDouble(Knapsack.weights[i]);
            }
            knapsack = new bool[Knapsack.weights.Count];
            int sum = 0;
            foreach (KeyValuePair<int, double> item in ratios.OrderByDescending(key => key.Value))
            {
                if (sum + Knapsack.weights[item.Key] <= Knapsack.knapsize)
                {
                    sum += Knapsack.weights[item.Key];
                    knapsack[item.Key] = true;
                }
                else
                {
                    break;
                }
            }
        }
       
        public bool[] doIt()
        {
            double T = Knapsack.startTemp;
            bool[] bestSolution = new bool[knapsack.Length];
            Random rnd = new Random();
            int delta = 0;
            while (T > Knapsack.endTemp)
            {
                bool[] temp = new bool[knapsack.Length];
                
                for (int i = 0; i < 10; i++)
                {
                    bool[] nextElement = process.FindNeighbor(knapsack, rnd.Next(1,Convert.ToInt32(knapsack.Length*0.5)));
                    delta = process.CalculateFitness(knapsack) - process.CalculateFitness(nextElement);
                    if (delta < 0)
                    {
                        Array.Copy(nextElement, knapsack, knapsack.Length);
                    }
                    else
                    {
                        double prob = RandomP.NextDouble();
                        if (prob < Math.Exp(-1 * delta / T))
                        {
                            Array.Copy(nextElement, knapsack, knapsack.Length);
                        }
                    }
                    if (process.CalculateFitness(knapsack) > process.CalculateFitness(temp))
                    {
                        Array.Copy(knapsack, temp, knapsack.Length);
                    }
                }

                Array.Copy(temp, knapsack, knapsack.Length);
                T *= Knapsack.coolingRate;
                if (process.CalculateFitness(knapsack) > process.CalculateFitness(bestSolution))
                {
                    Array.Copy(knapsack, bestSolution, knapsack.Length);
                }
                
            }

            return bestSolution;
        }

        
    }
}
