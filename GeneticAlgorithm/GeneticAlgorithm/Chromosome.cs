using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class Chromosome
    {
        public byte[] genes;//new byte[Program.weight.Count];
        public int lenGene = Program.weight.Count;
        public int weight = 0;
        public int value = 0;


        public Chromosome()
        {
            this.weight = 0;
            this.value = 0;
            genes=new byte[Program.weight.Count];
        }

        public void calcFitness()
        {
            weight = 0;
            value = 0;
            for (int i = 0; i < lenGene; i++)
            {
                if (genes[i]==1)
                {
                    weight += Program.weight[i];
                    value += Program.value[i];
                }
            }
        }
        public static void Fitness(List<Chromosome> pop)
        {
            Random rnd = new Random();
            double[] fit = new double[Program.n];
            
            int[] over = new int[Program.n];
            int index;
            int curKnapSize;
            int diff;
            for (int i = 0; i < Program.n; i++)
            {
                over[i] = IsCapacityOK(pop[i].genes);
            }
            for (int i = 0; i < Program.n; i++)
            {
                if (over[i] > 0)
                {
                    curKnapSize = pop[i].weight;
                    diff = Program.capacity - curKnapSize;
                    while (pop[i].weight>Program.capacity * (1 - (Math.Abs(diff) / curKnapSize)))
                    {
                        index = rnd.Next(0, pop[i].genes.Length);
                        if (pop[i].genes[index]==1) pop[i].genes[index] = 0;
                        pop[i].calcFitness();
                    }

                }

            }
            
        }

        //public static List<int> Fx(List<Chromosome> population)
        //{
        //    int sum;
        //    List<int> zvalues = new List<int>();
            
        //    for (int i = 0; i < population.Count; i++)
        //    {
        //        sum = 0;
        //        for (int j = 0; j < Program.size; j++)
        //        {
        //            if (population[i].genes[j] == 1)
        //            {
        //                sum += Program.value[j];
        //            }
        //        }
        //        zvalues.Add(sum);
        //    }
        //    return zvalues;
        //}

        // if over capacity (return how much)
        public static int IsCapacityOK(byte[] a)
        {
            int sum = 0;
            for (int i = 0; i < Program.size; i++)
            {
                if (a[i] != 0)
                    sum += Program.weight[i];
            }
            if (sum > Program.capacity)
                return sum - Program.capacity;

            return 0;
        }
    }
}
