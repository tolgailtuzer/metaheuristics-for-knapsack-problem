using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class CrossingOver
    {

        // Create 2 children for choosen 2 parents (two point method)
        public static List<Chromosome> Crossover(List<Chromosome> newGen, int choice)
        {

            double[] p = RandomGenerator.Generate(Program.n);
            List<byte[]> childs = new List<byte[]>();
            int bound;
            if (Program.n % 2 == 0) bound = Program.n;
            else bound = Program.n - 1;
            for (int i = 0; i < bound; i += 2)
            {
                if (p[i] <= Program.pC)
                {
                    if (choice == 1) childs = Onepoint(newGen[i].genes, newGen[i + 1].genes);
                    else if (choice == 2) childs = Twopoint(newGen[i].genes, newGen[i + 1].genes);
                    Array.Copy(childs[0].ToArray(), newGen[i].genes, newGen[i].genes.Length);
                    Array.Copy(childs[1].ToArray(), newGen[i + 1].genes, newGen[i].genes.Length);
                    newGen[i].calcFitness();
                    newGen[i + 1].calcFitness();
                }
              
            }
            return newGen;
        } 
        

        //one point crossover
        public static List<byte[]> Onepoint(byte[] parentOne, byte[] parentTwo)
        {
            int size = Program.size;
            Random rnd = new Random();
            int point = rnd.Next(0, size);
            byte[] child1 = new byte[size];
            byte[] child2 = new byte[size];

            Array.Copy(parentOne,child1,point);
            Array.Copy(parentTwo,child2,point);
            Array.Copy(parentTwo,point,child1,point,size-point);
            Array.Copy(parentOne, point, child2, point, size - point);

            List<byte[]> childs = new List<byte[]>();
            childs.Add(child1);
            childs.Add(child2);
            return childs;
        }

        //two point crossover
        public static List<byte[]> Twopoint(byte[] parentOne, byte[] parentTwo)
        {
            int size = Program.size;
            Random rnd = new Random();
            int point1 = rnd.Next(0, size - 2);
            int point2 = rnd.Next(point1, size);
            byte[] child1 = new byte[size];
            byte[] child2 = new byte[size];

            Array.Copy(parentOne,child1,size);
            Array.Copy(parentTwo,child2,size);

            for (int i = point1; i < point2; i++)
            {
                child1[i] = parentTwo[i];
                child2[i] = parentOne[i];
            }

            List<byte[]> childs = new List<byte[]>();
            childs.Add(child1);
            childs.Add(child2);
            return childs;
        }

    }
}
