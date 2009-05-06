using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GA.Genome;

namespace GA.SelectionStrategy
{
    /// <summary>エリート選択</summary>
    public class SelectionElete
    {
        public List<IGene> Selection(List<IGene> _gene)
        {
            int eleteNumber = Convert.ToInt32(_gene.Count * P.EletePercent / 100);
            List<IGene> elete = new List<IGene>();
            _gene.GetRange(0, eleteNumber).ForEach((IGene _meme) => { elete.Add(_meme.Copy()); });
            return elete;
        }
    }
}
