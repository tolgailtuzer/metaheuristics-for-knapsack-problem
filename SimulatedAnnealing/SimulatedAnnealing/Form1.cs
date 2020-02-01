using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatedAnnealing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void choose_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            ReadFiles.filename = openFileDialog1.FileName;
            if (!openFileDialog1.CheckFileExists) MessageBox.Show("Check your file and choose a valid file!!!");
        }
        CultureInfo culture = new CultureInfo("en");
        private void runAll_Click(object sender, EventArgs e)
        {
            GC.Collect();
            List<int> bests = new List<int>();
            List<double> times = new List<double>();
            Knapsack.startTemp = Double.Parse(startTemp.Text, culture);
            Knapsack.endTemp = Double.Parse(endTemp.Text, culture);
            int rptCount = Convert.ToInt32(repeat.Text);
            Stopwatch sw = new Stopwatch();
            ReadFiles read = new ReadFiles();
            Knapsack process = new Knapsack();
            Random a = new Random();
            string path = "";
            for (int i = 1; i <= 10; i++)
            {
                read.Read(i);
                //Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
                for (int j = 0; j < rptCount; j++)
                {
                    sw.Start();
                    SimulatedAnnealing start = new SimulatedAnnealing();
                    bool[] result = start.doIt();
                    sw.Stop();
                    path = "../../../../Datasets/test" + i;
                    Console.WriteLine(path + " Try:" + (j + 1) + " " + process.CalculateFitness(result) + " " + sw.ElapsedMilliseconds +" ms");
                    bests.Add(process.CalculateFitness(result));
                    times.Add(sw.ElapsedMilliseconds);
                    sw.Reset();
                }
                //ReadFiles.Write(bests, times, path);
                bests.Clear();
                times.Clear();
            }
            Console.WriteLine("Process Completed...");
        }

        private void startAlgorithm_Click(object sender, EventArgs e)
        {
            GC.Collect();
            List<int> bests = new List<int>();
            List<double> times = new List<double>();
            Knapsack.startTemp = Double.Parse(startTemp.Text, culture);
            Knapsack.endTemp = Double.Parse(endTemp.Text, culture);
            int rptCount = Convert.ToInt32(repeat.Text);
            Stopwatch sw = new Stopwatch();
            ReadFiles read = new ReadFiles();
            Knapsack process = new Knapsack();
            Random a = new Random();
            string path = "";
            int i = 0;
            read.Read(i);
            for (int j = 0; j < rptCount; j++)
            {
                sw.Start();
                SimulatedAnnealing start = new SimulatedAnnealing();
                bool[] result = start.doIt();
                sw.Stop();
                path = "../../../../Datasets/test" + i;
                Console.WriteLine(path + " Try:" + (j + 1) + " " + process.CalculateFitness(result) + " " + sw.ElapsedMilliseconds + " ms");
                bests.Add(process.CalculateFitness(result));
                times.Add(sw.ElapsedMilliseconds);
                sw.Reset();
            }
            //ReadFiles.Write(bests, times, path);
            bests.Clear();
            times.Clear();
            Console.WriteLine("Process Completed...");
        }
    }
}
