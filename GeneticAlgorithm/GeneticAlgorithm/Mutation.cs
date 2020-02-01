using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class Mutation
    {
        public static List<Chromosome> Mutate(List<Chromosome> population)
        {
            Random rnd = new Random();
            double[] p = RandomGenerator.Generate(Program.n);
            int a;
            for (int i = 0; i < Program.n; i++)
            {
                if (p[i] < Program.pM)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        a = rnd.Next(0, Program.size);

                        if (Convert.ToByte(1 - population[i].genes[a]) == 1)
                        {
                            if (population[i].weight + Program.weight[a] <= Program.capacity)
                            {
                                population[i].genes[a] = 1;
                            }
                            else
                            {
                                population[i].genes[a] = 0;
                            }
                        }
                        else
                        {
                            population[i].genes[a] = 0;
                        }
                        population[i].calcFitness();
                    }
                }
            }
            return population;
        }
    }
}
