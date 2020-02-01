using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class Population
    {
        public List<Chromosome> curPopulation;
        
        public Population()
        {
            Random rand = new Random();
            curPopulation = new List<Chromosome>();
            byte[] temp = new byte[Program.size];
            int sum;
            int randomN;
            for (int i = 0; i < Program.n - 1; i++)
            {
                sum = 0;
                for (int j = 0; j < Program.size; j++)
                {
                    
                    randomN = Convert.ToByte(rand.Next(0, 2));
                    
                    if (randomN == 1)
                    {
                        if (sum + Program.weight[j] <= Program.capacity)
                        {
                            sum += Program.weight[j];
                            temp[j] = 1;
                        }
                        else
                        {
                            temp[j] = 0;
                        }
                    }
                    else
                    {
                        temp[j] = 0;
                    }
                }

                Chromosome chromosome = new Chromosome();
                Array.Copy(temp, chromosome.genes, temp.Length);
                chromosome.calcFitness();
                curPopulation.Add(chromosome);
            }

            Dictionary<int, double> ratios = new Dictionary<int, double>();
            for (int i = 0; i < Program.weight.Count; i++)
            {
                ratios[i] = Program.value[i] / Convert.ToDouble(Program.weight[i]);
            }

            byte[] knapsack = new byte[Program.weight.Count];
            sum = 0;
            foreach (KeyValuePair<int, double> item in ratios.OrderByDescending(key => key.Value))
            {
                if (sum + Program.weight[item.Key] <= Program.capacity)
                {
                    sum += Program.weight[item.Key];
                    knapsack[item.Key] = 1;
                }
                else
                {
                    break;
                }
            }
            Chromosome chromosomeBest = new Chromosome();
            Array.Copy(knapsack, chromosomeBest.genes, temp.Length);
            chromosomeBest.calcFitness();
            curPopulation.Add(chromosomeBest);
        }

        public Population(bool a)
        {
            curPopulation = new List<Chromosome>();
            for (int i = 0; i < Program.n; i++)
            {
                Chromosome chromosome = new Chromosome();
                curPopulation.Add(chromosome);
            }
        }

        public static int GetBest(double[] x)
        {
            double max = -1;
            int index = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] > max)
                {
                    max = x[i];
                    index = i;
                }
            }
            return index;
        }

        public static int GetWorst(double[] x)
        {
            double min = int.MaxValue;
            int index = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < min)
                {
                    min = x[i];
                    index = i;
                }
            }
            return index;
        }

        public static void Print(List<byte>[] pop)
        {
            for (int i = 0; i < Program.n; i++)
            {
                for (int j = 0; j < Program.size; j++)
                {
                    Console.Write("{0} ", pop[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------------------------------------------------");
        }

        // Normalize the data between 0-1
        public static double[] Normalize(List<Chromosome> population)
        {
            double[] norm = new double[Program.n];
            double sum = 0;
            for (int i = 0; i < population.Count; i++)
            {
                sum += population[i].value;
            }

            for (int i = 0; i < population.Count; i++)
            {
                norm[i] = (Convert.ToDouble(population[i].value) / sum);
            }
            return norm;
        }

        public static List<Chromosome> CopyToNew(int[] choosen, List<Chromosome> currentGeneration, List<Chromosome> newGeneration)
        {
            for (int i = 0; i < Program.n; i++)
            {
                Array.Copy(currentGeneration[choosen[i]].genes, newGeneration[i].genes, newGeneration[i].genes.Length);
                newGeneration[i].calcFitness();
            }

            return newGeneration;
        }

        /*public static bool checker(List<Chromosome> population)
        {
            for (int i = 0; i < population.Count; i++)
            {
                population[i].calcFitness();
                if (population[i].weight > Program.capacity) return false;
            }

            return true;
        }*/
    }
}
