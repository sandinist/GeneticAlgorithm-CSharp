using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GA.Genome;

namespace GA.SelectionStrategy
{
    /// <summary>ランキング選択</summary>
    public class RankingSelection : ISelectionStrategy
    {
        public int firstRankPercent = 20;
        public double nextRankPercent = 0.8;
        public List<IGene> Selection(List<IGene> _gene)
        {
            if (P.TotalFitness == 0) return new RandomSelection().Selection(_gene);
            List<int>rankList = makeRank(_gene.Count);
            int totalRank = 0, currentRank = 0;
            int gene1 =-1, gene2=-1;
            int rank1 = R.Next(0, 100);
            int rank2 = R.Next(0, 100);

            for (int i = 0; i < rankList.Count; i++)
            {
                currentRank = Convert.ToInt32(rankList[i]);
                if (Hit(totalRank, rank1, currentRank)) gene1 = i;
                if (Hit(totalRank, rank2, currentRank)) gene2 = i;

                if (gene1 != -1 && gene2 != -1) break;
                totalRank += currentRank;
            }
            return new List<IGene> { _gene[gene1], _gene[gene2] };
        }
        private bool Hit(int _currentTotal, int _target, int _nextFitness)
        {
            return (_currentTotal <= _target &&
                _target <= _currentTotal + _nextFitness);
        }
        private List<int> makeRank(int _geneCount)
        {
            List<int> Rank = Rank = new List<int>();
            int totalPercent = firstRankPercent;
            int previousRank = firstRankPercent;
            int currentPercet = 0;
            Rank.Add(firstRankPercent);
            int i = 1;
            while (true)
            {
                if (Rank.Count - 1 < i) Rank.Add(0);
                currentPercet = Convert.ToInt32(Math.Round(previousRank * nextRankPercent));
                Rank[i] += currentPercet;
                totalPercent += currentPercet;
                if (totalPercent >= 100)
                {
                    Rank[i] -= totalPercent - 100;
                    break;
                }

                previousRank = Rank[i];
                if (previousRank == 2) previousRank = 1;
                i++;

                if (i > _geneCount) i = 0;
            }
            return Rank;
        }
    }
}
