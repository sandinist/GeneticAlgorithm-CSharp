using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GA.Genome;
using GA.CrossOverStrategy;
using GA.SelectionStrategy;

namespace GA
{
    public class Generation
    {
        public List<IGene> Generations = new List<IGene>();
        public ICrossOverStrategy CrossOverStrategy { private get; set; }
        public ISelectionStrategy SelectionStrategy { private get; set; }
        public bool DispOn { get; set; }

        /// <summary>評価</summary>
        /// <returns>最適遺伝子</returns>
        public IGene Evaluation()
        {
            for (int i = 0; i < P.GenerationNumber; i++)
            {
                P.TotalFitness = 0;
                Generations.ForEach((IGene _gene) => { P.TotalFitness += _gene.Evaluation(); });
                Generations.Sort();
                if (DispOn) Console.WriteLine("Count{0} MostFit {1} Total {2}", 
                    Generations.Count, Generations[0], P.TotalFitness);
                Selection();
            }

            Generations.ForEach((IGene _gene) => { _gene.Evaluation(); });
            Generations.Sort();
            return Generations[0];
        }

        /// <summary>選択・淘汰</summary>
        public void Selection()
        {
            List<IGene> OffSpring = new List<IGene>();
            List<IGene> eletes = new SelectionElete().Selection(Generations);

            while (Generations.Count > OffSpring.Count + eletes.Count)
            {
                List<IGene> selectGenes = SelectionStrategy.Selection(Generations);
                OffSpring.AddRange(CrossOver(selectGenes));
            }
            if (Generations.Count < OffSpring.Count + eletes.Count)
            {
                OffSpring.RemoveAt(OffSpring.Count - 1);
            }

            OffSpring.ForEach((IGene _gene) => { _gene.Mutate(); });
            OffSpring.AddRange(eletes);

            Generations.Clear();
            Generations.AddRange(OffSpring);
        }

        /// <summary>
        /// 交叉処理
        /// </summary>
        /// <param name="_targetGene">交叉処理対象の遺伝子2つリストを指定します</param>
        /// <returns>交叉確率に従った処理後の遺伝子リスト</returns>
        private List<IGene> CrossOver(List<IGene> _targetGene)
        {
            if (R.Next(0, 100) <= P.CrossOverPercent)
            {
                return CrossOverStrategy.CrossOver(_targetGene[0], _targetGene[1]);
            }
            else
            {
                return _targetGene;
            }
        }
    }
}
