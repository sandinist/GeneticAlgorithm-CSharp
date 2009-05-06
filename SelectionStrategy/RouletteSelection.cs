using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GA.Genome;

namespace GA.SelectionStrategy
{
    /// <summary>ルーレット選択</summary>
    public class RouletteSelection : ISelectionStrategy
    {
        public List<IGene> Selection(List<IGene> _gene)
        {
            if (P.TotalFitness == 0) return new RandomSelection().Selection(_gene);

            int iTotalFitness = (Int32)Math.Floor(Convert.ToDecimal(P.TotalFitness * 100));
            int fitness1, fitness2;
            int gene1 = -1, gene2 = -1;

            fitness1 = R.Next(0, iTotalFitness);
            do { fitness2 = R.Next(0, (iTotalFitness)); }
            while (fitness1 == fitness2);

            int currentTotal = 0, currentFitness = 0;
            for (int i = 0; i < _gene.Count; i++)
            {
                currentFitness = (Int32)Math.Ceiling(Convert.ToDecimal(_gene[i].Fitness * 100));
                if (Hit(currentTotal, fitness1, currentFitness)) gene1 = i;
                if (Hit(currentTotal, fitness2, currentFitness)) gene2 = i;

                if (gene1 != -1 && gene2 != -1) break;
                currentTotal += currentFitness;
            }
            return new List<IGene> { _gene[gene1], _gene[gene2] };
        }
        private bool Hit(int _currentTotal, int _target, int _nextFitness)
        {
            return (_currentTotal <= _target &&
                _target <= _currentTotal + _nextFitness);
        }
    }
}
