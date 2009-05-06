using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA.Genome
{
    public interface IGene : IComparable<IGene>
    {
        bool IsFit { get; }
        double Fitness { get; }

        int Size { get; }
        int[] Gene { get; set; }
        int this[int _index] { get; set; }

        void Initialize();
        double Evaluation();
        IGene Mutate();
        IGene Copy();
    }
}