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

namespace GeneticAlgorithm
{
    public partial class Form1 : Form
    {
        CultureInfo culture = new CultureInfo("en");
        public Form1()
        {
            InitializeComponent();

        }
        private void chooseFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            ReadFile.path = openFileDialog1.FileName;
            if (!openFileDialog1.CheckFileExists) MessageBox.Show("Check your file and choose a valid file!!!");
        }

        private void start_Click(object sender, EventArgs e)
        {
            ReadFile.Read();

            Program.itr = 1000;
            Program.pM = Double.Parse(mutationRate.Text, culture);
            Program.pC = Double.Parse(crossoverRate.Text, culture);
            int tryCount = Convert.ToInt32(repeatTime.Text);
            Program.size = Program.weight.Count;
            Program.n = Convert.ToInt32(populationSize.Text);

            for (int k = 0; k < tryCount; k++)
            {
                double[] fit = new double[Program.n]; // (fx/overall) or fx values
                double[] norm = new double[Program.n]; // fitness values get norm
                int[] choosenId = new int[Program.n];  // choose for new generation
                int bestId = 0;
                int worstId = 0;
                int bestFx = 0;
                int max;
                int index;
                Stopwatch stopw = new Stopwatch();
                stopw.Start();

                // Generate Population
                Population population = new Population();
                    
                bool gotcha = true;
                Population newGeneration = new Population(gotcha);

                for (int i = 0; i < Program.itr; i++)
                {

                    // Normalize
                    norm = Population.Normalize(population.curPopulation);

                    // Select from population
                    switch (selectionMethod.SelectedItem.ToString())
                    {
                        case "Tournament Selection":
                            choosenId = Selection.TournamentSelection(norm);
                            break;
                        case "Roulet Selection":
                            choosenId = Selection.RouletChark(norm);
                            break;
                    }

                    // Keep best
                    bestId = Population.GetBest(norm);

                    newGeneration.curPopulation = Population.CopyToNew(choosenId, population.curPopulation, newGeneration.curPopulation);

                    switch (crossoverMethod.SelectedItem.ToString())
                    {
                        case "One Point Crossover":
                            newGeneration.curPopulation = CrossingOver.Crossover(newGeneration.curPopulation, 1);
                            break;
                        case "Two Point Crossover":
                            newGeneration.curPopulation = CrossingOver.Crossover(newGeneration.curPopulation, 2);
                            break;
                    }

                    // Mutation
                    newGeneration.curPopulation = Mutation.Mutate(newGeneration.curPopulation);

                    norm = Population.Normalize(newGeneration.curPopulation);

                    // Get worst
                    worstId = Population.GetWorst(norm);

                    // Copy the best element to new gen
                    Array.Copy(population.curPopulation[bestId].genes, newGeneration.curPopulation[worstId].genes, newGeneration.curPopulation[worstId].genes.Length);

                    newGeneration.curPopulation[worstId].calcFitness();

                    Chromosome.Fitness(newGeneration.curPopulation);

                    // Copy new generation
                    max = -1;
                    for (int p = 0; p < population.curPopulation.Count; p++)
                    {
                        Array.Copy(newGeneration.curPopulation[p].genes, population.curPopulation[p].genes, population.curPopulation[p].genes.Length);

                        population.curPopulation[p].calcFitness();

                        if (population.curPopulation[p].value > max)
                        {
                            max = population.curPopulation[p].value;
                            index = p;
                        }
                    }

                    if (max > bestFx)
                    {
                        bestFx = max;
                    }

                }

                Console.WriteLine(bestFx);
                stopw.Stop();
                TimeSpan ts = stopw.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                Console.WriteLine("RunTime " + elapsedTime);
                Console.WriteLine("---------------------");
                
            }
            Console.WriteLine("Process Completed...");

        }

        private void advanced_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Height == 250) this.Height = 350;
            else if (this.Height == 350) this.Height = 250;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            selectionMethod.SelectedIndex = 0;
            crossoverMethod.SelectedIndex = 0;
        }

        private void RunAll_Click(object sender, EventArgs e)
        {
            string[] txts = new string[] { "test1.txt", "test2.txt", "test3.txt", "test4.txt", "test5.txt", "test6.txt", "test7.txt", "test8.txt", "test9.txt", "test10.txt" };

            foreach (string k in txts)
            {
                ReadFile.path = "../../../../Datasets/" + k;
                Console.WriteLine(ReadFile.path);
                ReadFile.Read();
                List<int> bests = new List<int>();
                List<double> times = new List<double>();
                Program.itr = 1000;
                Program.pM = Double.Parse(mutationRate.Text, culture);
                Program.pC = Double.Parse(crossoverRate.Text, culture);
                int tryCount = Convert.ToInt32(repeatTime.Text);
                Program.size = Program.weight.Count;
                Program.n = Convert.ToInt32(populationSize.Text);

                for (int t = 0; t < tryCount; t++)
                {

                    double[] fit = new double[Program.n]; // (fx/overall) or fx values
                    double[] norm = new double[Program.n]; // fitness values get norm
                    int[] choosenId = new int[Program.n];  // choose for new generation
                    int bestId = 0;
                    int worstId = 0;
                    int bestFx = 0;
                    int max;
                    int index;
                    Stopwatch stopw = new Stopwatch();
                    stopw.Start();

                    // Create Population
                    Population population = new Population();

                    bool gotcha = true;
                    Population newGeneration = new Population(gotcha);

                    for (int i = 0; i < Program.itr; i++)
                    {

                        // Normalize
                        norm = Population.Normalize(population.curPopulation);

                        switch (selectionMethod.SelectedItem.ToString())
                        {
                            case "Tournament Selection":
                                choosenId = Selection.TournamentSelection(norm);
                                break;
                            case "Roulet Selection":
                                choosenId = Selection.RouletChark(norm);
                                break;
                        }
                        // Keep best of population
                        bestId = Population.GetBest(norm);

                        newGeneration.curPopulation = Population.CopyToNew(choosenId, population.curPopulation, newGeneration.curPopulation);

                        switch (crossoverMethod.SelectedItem.ToString())
                        {
                            case "One Point Crossover":
                                newGeneration.curPopulation = CrossingOver.Crossover(newGeneration.curPopulation, 1);
                                break;
                            case "Two Point Crossover":
                                newGeneration.curPopulation = CrossingOver.Crossover(newGeneration.curPopulation, 2);
                                break;
                        }

                        // Mutation
                        newGeneration.curPopulation = Mutation.Mutate(newGeneration.curPopulation);

                        norm = Population.Normalize(newGeneration.curPopulation);

                        worstId = Population.GetWorst(norm);

                        // Copy the best of prev generation to new generation
                        Array.Copy(population.curPopulation[bestId].genes, newGeneration.curPopulation[worstId].genes, newGeneration.curPopulation[worstId].genes.Length);

                        newGeneration.curPopulation[worstId].calcFitness();

                        Chromosome.Fitness(newGeneration.curPopulation);

                        // Copy the new generation to old generation
                        max = -1;
                        for (int p = 0; p < population.curPopulation.Count; p++)
                        {
                            Array.Copy(newGeneration.curPopulation[p].genes, population.curPopulation[p].genes, population.curPopulation[p].genes.Length);

                            population.curPopulation[p].calcFitness();

                            if (population.curPopulation[p].value > max)
                            {
                                max = population.curPopulation[p].value;
                                index = p;
                            }
                        }

                        if (max > bestFx)
                        {
                            bestFx = max;
                        }

                    }

                    stopw.Stop();
                    Console.WriteLine(k.Split('.')[0] + " Try:" + (t + 1) + " " + bestFx + " " + stopw.ElapsedMilliseconds + " ms");

                    bests.Add(bestFx);
                    times.Add(stopw.ElapsedMilliseconds);

                }
                //Optional write file
                //ReadFile.Write(bests,times,k);

            }
            Console.WriteLine("Process Completed...");
        }
    }
}
