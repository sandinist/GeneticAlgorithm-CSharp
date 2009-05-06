using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA.Genome
{
    /// <summary>
    /// Cutting Stock Problem
    /// </summary>
    public class CSPGene : IGene
    {
        #region IGene
        public bool IsFit { get; private set; }
        public double Fitness { get; private set; }
        public int Size { get { return Gene.Count(); } }
        public int[] Gene { get; set; }
        public int this[int _index]
        {
            get
            {
                return Gene[_index];
            }
            set
            {
                Gene[_index] = value;
            }
        }

        public void Initialize()
        {
            for (int i = 0; i < Material.Count; i++)
            {
                Gene[i] = R.Next(0, Material.Count - i); // 遺伝子情報の設定
            }
            for (int i = Material.Count; i < Size; i++)
            {
                Gene[i] = R.Next(0, Size - i); // 遺伝子情報の設定
            }
        }
        public double Evaluation()
        {
            List<int> mat = new List<int>(Material);
            List<int> pro = new List<int>(Product);

            double zan = 0;
            double proc = 0;
            int pidx = 0;
            for (int i = 0; i < Material.Count; i++)
            {
                int curzan = mat[Gene[i]];
                mat.RemoveAt(Gene[i]);
                for (int j = pidx; j < Product.Count; j++)
                {
                    int curpro = pro[Gene[j + Material.Count]];
                    if (curzan >= curpro)
                    {
                        pro.RemoveAt(Gene[j + Material.Count]);
                        curzan -= curpro;
                        proc += curpro;
                        pidx++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (curzan != Material[Gene[i] + i])
                {
                    zan += curzan;
                }
            }

            IsFit = (pidx >= Product.Count);
            Fitness = Fitness = proc / (zan + proc);
            return Fitness;
        }
        public IGene Mutate()
        {
            for (int i = 0; i < Material.Count; i++)
            {
                if (R.Next(0, 100) <= P.MutatePercent)
                {
                    Gene[i] = R.Next(0, Material.Count - i);
                }
            }
            for (int j = Material.Count; j < (Product.Count + Material.Count); j++)
            {
                if (R.Next(0, 100) <= P.MutatePercent)
                {
                    Gene[j] = R.Next(0, (Product.Count + Material.Count) - j);
                }
            }
            return this;
        }
        public IGene Copy()
        {
            IGene meme = new CSPGene();
            for (int i = 0; i < meme.Gene.GetUpperBound(0); i++)
            {
                meme[i] = this.Gene[i];
            }
            return meme;
        }
        public int CompareTo(IGene _other)
        {
            return this.Fitness.CompareTo(_other.Fitness) * -1;
        }
        #endregion

        public static List<int> Material = new List<int>();
        public static List<int> Product = new List<int>();
        public CSPGene()
        {
            IsFit = false;
            Gene = new int[Material.Count + Product.Count];
        }
        public override string ToString()
        {
            string ret = Fitness.ToString() + ": ";
            for (int i = 0; i < Size; i++)
            {
                ret += Gene[i];
            }
            return ret;
        }
    }
}
