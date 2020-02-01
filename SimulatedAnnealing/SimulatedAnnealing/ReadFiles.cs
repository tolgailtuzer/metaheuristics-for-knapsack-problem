using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedAnnealing
{
    class ReadFiles
    {
        public static string filename="";
        public void Read(int k)
        {
            Knapsack.weights.Clear();
            Knapsack.values.Clear();
            if(k!=0) filename = "../../../../Datasets/test" + k + ".txt";
            StreamReader sr = new StreamReader(filename);
            Knapsack.knapsize = Convert.ToInt32(sr.ReadLine());
            sr.ReadLine();
            string[] inputW = sr.ReadLine().Trim().Split(' ');
            for(int i = 0;i<inputW.Length;i++)
            {
                Knapsack.weights.Add(Convert.ToInt32(inputW[i]));
            }
            sr.ReadLine();
            string[] inputV = sr.ReadLine().Trim().Split(' ');
            for(int i = 0; i < inputV.Length; i++)
            {
                Knapsack.values.Add(Convert.ToInt32(inputV[i]));
            }
        }

        public static void Write(List<int> bests, List<double> times, string name)
        {
            string path = name + "_5_results.txt";
            StreamWriter sw = new StreamWriter(path);
            int max = -1, index = 0;
            Int64 sum = 0;
            for (int i = 0; i < bests.Count; i++)
            {
                sum += bests[i];
                if (max < bests[i])
                {
                    max = bests[i];
                    index = i;
                }
            }
            sw.WriteLine(sum / bests.Count + " " + max + " " + times[index] );

            sw.Close();
        }
    }
}
