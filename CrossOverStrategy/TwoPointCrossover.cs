using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GA.Genome;

namespace GA.CrossOverStrategy
{
    /// <summary>二点交叉</summary>
    public class TwoPointCrossover : ICrossOverStrategy
    {
        public List<IGene> CrossOver(IGene _gene1, IGene _gene2)
        {
            List<IGene> nextGeneration = new List<IGene>(2);
            int maskbit1 = R.Next(0, _gene1.Size);
            int maskbit2 = R.Next(maskbit1, _gene1.Size);

            IGene meme1 = _gene1.Copy();
            IGene meme2 = _gene2.Copy();
            for (int i = maskbit1; i <= maskbit2; i++)
            {
                meme1[i] = _gene2[i];
                meme2[i] = _gene1[i];
            }
            nextGeneration.Add(meme1);
            nextGeneration.Add(meme2);
            return nextGeneration;
        }
    }
}
