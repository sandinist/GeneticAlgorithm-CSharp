using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GA.Genome;
using GA.CrossOverStrategy;
using GA.SelectionStrategy;
using GA.Presentation;

namespace GA.Presentation
{
    public class Start
    {
        public static void GAloop()
        {
            DateTime t1 = DateTime.Now;
            Generation G = GABuilder.Create();
            IGene g = G.Generations[0];

            Console.WriteLine("Start at {0}", DateTime.Now.ToString("hh:mm:ss"));
            while (!g.IsFit)
            {
                G.Evaluation();
                g = G.Generations[0];
                Console.WriteLine("Fit {0}, Time {1}, MostFit {2}",
                    g.IsFit, DateTime.Now.ToString("hh:mm:ss"), g.Fitness);
            }

            DateTime t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            Console.WriteLine(string.Format("Total Time {0}ms, {1}ms per evaluate", ts.TotalMilliseconds, ts.TotalMilliseconds / P.GenerationNumber));
            Console.WriteLine(g);
            Console.ReadLine();
        }
    }
}
