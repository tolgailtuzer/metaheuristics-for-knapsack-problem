using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedAnnealing
{
    class Knapsack
    {
        public static double startTemp =100;
        public static double endTemp=0.05;
        public static double coolingRate =0.951;
        public static List<int> values = new List<int>();
        public static List<int> weights = new List<int>();
        public static int knapsize;

        public int CalculateWeight(bool[] knapsack)
        {
            int sum = 0;
            for(int i = 0;i< knapsack.Length;i++)
            {
                if(knapsack[i])
                {
                    sum += weights[i];
                }
            }
            return sum;
        }

        public int CalculateFitness(bool[] knapsack)
        {
            int sum = 0;
            for (int i = 0; i < knapsack.Length; i++)
            {
                if (knapsack[i])
                {
                    sum += values[i];
                }
            }
            return sum;
        }

        public bool [] checkKnapsack(bool[] knapsack)
        {
            bool[] checkedKnapsack = new bool[knapsack.Length];
            Array.Copy(knapsack, checkedKnapsack, knapsack.Length);
            
            Random rnd = new Random();
            int curKnapSize = CalculateWeight(checkedKnapsack);
            int diff = knapsize - curKnapSize;
            int index;
            if(diff<0)
            {
                while (CalculateWeight(checkedKnapsack) > knapsize * (1 - (Math.Abs(diff) / curKnapSize)))
                {
                    index = rnd.Next(0, checkedKnapsack.Length);
                    if (checkedKnapsack[index]) checkedKnapsack[index] = false;
                }
            }
            return checkedKnapsack;
        }

        public bool isWeightOK(bool[] knapsack)
        {
            if(CalculateWeight(knapsack) < knapsize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool [] FindNeighbor(bool[] knapsack, int chance)
        {
            bool[] newElement = new bool[knapsack.Length];
            Array.Copy(knapsack, newElement, knapsack.Length);
            Random rnd = new Random();
            int index;
            for (int i=0;i<chance;i++)
            {
                index = rnd.Next(0, newElement.Length);
                if(!newElement[index])
                {
                    if(CalculateWeight(newElement)+weights[index]<=knapsize)
                    {
                        newElement[index] = !newElement[index];
                    }
                }
                else
                {
                    newElement[index] = !newElement[index];
                }
            }

            return newElement;
        }
    }
}
