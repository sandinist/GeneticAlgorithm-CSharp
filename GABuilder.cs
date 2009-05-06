using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GA.Genome;
using GA.CrossOverStrategy;
using GA.SelectionStrategy;


namespace GA
{
    class GABuilder
    {
        public static Generation Create()
        {
            P.GeneNumber = 10;
            P.GenerationNumber = 100;
            P.EletePercent = 5;
            P.CrossOverPercent = 90;
            P.MutatePercent = 20;

            Generation ga = CSPGeneration2();
            ga.DispOn = false;
            ga.CrossOverStrategy = new UniformCrossover();
            ga.SelectionStrategy = new RankingSelection();
            return ga;
        }

        private static void Genesis(Generation _ga, Func<IGene> _func)
        {
            for (int i = 0; i < P.GeneNumber; i++)
            {
                _ga.Generations.Add(_func());
                _ga.Generations[i].Initialize();
            }
        }
        #region Problems
        private static Generation CSPGeneration1()
        {
            Generation ga = new Generation();
            CSPGene.Product = new List<int> { 22, 22, 22, 32, 32, 32, 42, 42, 42 };
            CSPGene.Material = new List<int> { 100, 100, 100 };
            Genesis(ga, (() => ((IGene)new CSPGene())));
            return ga;
        }
        private static Generation CSPGeneration2()
        {
            Generation ga = new Generation();
            for (int i = 0; i < 500; i++) { CSPGene.Product.Add(2300); }
            for (int i = 0; i < 200; i++) { CSPGene.Product.Add(1870); }
            for (int i = 0; i < 300; i++) { CSPGene.Product.Add(1850); }
            for (int i = 0; i < 270; i++) { CSPGene.Product.Add(1270); }
            for (int i = 0; i < 157; i++) { CSPGene.Product.Add(800); }
            for (int i = 0; i < 254; i++) { CSPGene.Product.Add(723); }
            for (int i = 0; i < 50; i++) { CSPGene.Product.Add(302); }
            for (int i = 0; i < 2; i++) { CSPGene.Product.Add(300); }
            for (int i = 0; i < 240; i++) { CSPGene.Product.Add(250); }
            for (int i = 0; i < 4; i++) { CSPGene.Product.Add(125); }
            
            //517
            for (int i = 0; i < 600; i++) { CSPGene.Material.Add(5500); }

            Genesis(ga, (() => ((IGene)new CSPGene())));
            return ga;
        }
        private static Generation TSPGeneration1()
        {
            Generation ga = new Generation();
            TSPGene.Towns = new List<TSPGene.Point> {
                new TSPGene.Point{x =1,y=1},
                new TSPGene.Point{x =1,y=2},
                new TSPGene.Point{x =3,y=4},
                new TSPGene.Point{x =4,y=2}
            };
            Genesis(ga, (() => ((IGene)new TSPGene())));
            return ga;
        }
        private static Generation TSPGeneration2()
        {
            Generation ga = new Generation();
            TSPGene.Towns = new List<TSPGene.Point> {
                new TSPGene.Point{x =1,y=2},
                new TSPGene.Point{x =1,y=3},
                new TSPGene.Point{x =2,y=5},
                new TSPGene.Point{x =3,y=7},
                new TSPGene.Point{x =5,y=11},
                new TSPGene.Point{x =8,y=13},
                new TSPGene.Point{x =13,y=17},
                new TSPGene.Point{x =21,y=19},
                new TSPGene.Point{x =34,y=23},
                new TSPGene.Point{x =55,y=29},
                new TSPGene.Point{x =89,y=31},
                new TSPGene.Point{x =144,y=37},
                new TSPGene.Point{x =233,y=41},
                new TSPGene.Point{x =377,y=43},
                new TSPGene.Point{x =610,y=47}
            };
            Genesis(ga, (() => ((IGene)new TSPGene())));
            return ga;
        }
        #endregion
    }
}
