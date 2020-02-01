using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithm
{
    class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        /// 

        public static int n, size, capacity;
        public static List<int> weight = new List<int>();
        public static List<int> value = new List<int>();
        public static double pM, pC;
        public static int itr;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
