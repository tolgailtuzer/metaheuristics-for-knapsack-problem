using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class ReadFile
    {     
        public static string path="";
        public static void Read()
        {
            StreamReader sr = new StreamReader(path);
            Program.weight.Clear();
            Program.value.Clear();          
            Program.capacity = Convert.ToInt32(sr.ReadLine());
            sr.ReadLine();
            string[] inputW = sr.ReadLine().Trim().Split(' ');
            for (int i = 0; i < inputW.Length; i++)
            {
                Program.weight.Add(Convert.ToInt32(inputW[i]));
            }
            sr.ReadLine();
            string[] inputV = sr.ReadLine().Trim().Split(' ');
            for (int i = 0; i < inputV.Length; i++)
            {
                Program.value.Add(Convert.ToInt32(inputV[i]));
            }
            sr.Close();
        }

        public static void Write(List<int> bests, List<double> times,string name)
        {
            string path = name.Split('.')[0] + "_5_results.txt";
            StreamWriter sw = new StreamWriter(path);
            int max = -1,index = 0;
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
            sw.WriteLine(sum/bests.Count + " " + max + " " + times[index] );

            sw.Close();
        }
    }
}
