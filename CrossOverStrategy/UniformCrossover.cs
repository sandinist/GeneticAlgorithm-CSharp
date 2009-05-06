using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GA.Genome;

namespace GA.CrossOverStrategy
{
    /// <summary>一様交叉</summary>
    public class UniformCrossover:ICrossOverStrategy
    {
        public List<IGene> CrossOver(IGene _gene1, IGene _gene2)
        {
            List<IGene> nextGeneration = new List<IGene>(2);
            int[] mask = new int[_gene1.Size];

            for (int j = 0; j < _gene1.Size; j++)
            {
                mask[j] = R.Next(0, 2);
            }

            IGene meme1 = _gene1.Copy();
            IGene meme2 = _gene2.Copy();
            for (int j = 0; j < _gene1.Size; j++)
            {
                if (mask[j] == 1)
                {
                    meme1[j] = _gene2[j];
                    meme2[j] = _gene1[j];
                }
            }
            nextGeneration.Add(meme1);
            nextGeneration.Add(meme2);
            return nextGeneration;
        }
    }
}
