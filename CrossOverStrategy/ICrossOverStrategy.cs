using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GA.Genome;

namespace GA.CrossOverStrategy
{
    /// <summary>交叉戦略</summary>
    public interface ICrossOverStrategy
    {
        List<IGene> CrossOver(IGene _gene1, IGene _gene2);
    }
}
