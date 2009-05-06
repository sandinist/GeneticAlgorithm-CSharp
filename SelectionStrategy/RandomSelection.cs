using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GA.Genome;

namespace GA.SelectionStrategy
{
    /// <summary>ランダム選択</summary>
    public class RandomSelection : ISelectionStrategy
    {
        public List<IGene> Selection(List<IGene> _gene)
        {
            int gene1, gene2;
            gene1 = R.Next(0, (_gene.Count - 1));
            do { gene2 = R.Next(0, (_gene.Count - 1)); }
            while (gene1 == gene2);

            return new List<IGene> { _gene[gene1], _gene[gene2] };
        }
    }
}
