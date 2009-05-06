using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GA.Genome;

namespace GA.SelectionStrategy
{
    /// <summary>選択戦略</summary>
    public interface ISelectionStrategy
    {
        List<IGene> Selection(List<IGene> _gene);
    }
}
