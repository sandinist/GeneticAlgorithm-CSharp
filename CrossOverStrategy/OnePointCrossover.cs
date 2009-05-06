using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GA.Genome;

namespace GA.CrossOverStrategy
{
    /// <summary>一点交叉</summary>
    public class OnePointCrossover : ICrossOverStrategy
    {
        public List<IGene> CrossOver(IGene _gene1, IGene _gene2)
        {
            List<IGene> nextGeneration = new List<IGene>(2);
            int maskbit = R.Next(0, _gene1.Size);
            IGene meme1 = _gene1.Copy();
            IGene meme2 = _gene2.Copy();
            for (int j = maskbit; j < _gene1.Size; j++)
            {
                meme1[j] = _gene2[j];
                meme2[j] = _gene1[j];
            }
            nextGeneration.Add(meme1);
            nextGeneration.Add(meme2);
            return nextGeneration;
        }
    }
}
