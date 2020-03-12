using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class Selection
    {
        // Choose a parent id in pop  
        public static int[] RouletChart(double[] fit)
        {
            double sum = 0;
            double[] p = RandomGenerator.Generate(Program.n);
            int[] choosen = new int[Program.n];
            for (int i = 0; i < Program.n; i++)
            {
                sum = 0;
                for (int j = 0; j < Program.n; j++)
                {
                    sum += fit[j];
                    if (sum > p[i])
                    {
                        choosen[i] = j;
                        break;
                    }

                }
            }
            return choosen;
        }

        // Choose a parent id in pop 
        public static int[] TournamentSelection(double [] fit)
        {
            int k = 3; // Tournament Size
            int[] choosenId = new int[Program.n];
            ArrayList ran = new ArrayList();
            Random rnd = new Random();
            int temp = 0;
            int choose;
            for (int i = 0; i < Program.n; i++)
            {
                temp = rnd.Next(0, Program.n);
                choose = temp;
                for (int j = 0; j < k - 1; j++)
                {
                    var ras = rnd.Next(0, Program.n);

                    if (fit[ras] >= fit[temp])
                    {
                        choose = ras;
                    }
                    temp = ras;
                }
                choosenId[i] = choose;
            }

            return choosenId;
        }
    }
}
