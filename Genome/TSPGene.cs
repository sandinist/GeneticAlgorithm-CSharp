using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA.Genome
{
    /// <summary>
    /// Traveling Salesperson Problem 
    /// </summary>
    public class TSPGene : IGene
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
            for (int i = 0; i < Towns.Count; i++)
            {
                Gene[i] = R.Next(0, Towns.Count - i);
            }
        }
        public double Evaluation()
        {
            List<Point> map = new List<Point>(Towns);
            double totalDistance = 0;

            Point first = map[Gene[0]];
            Point current = first, next;
            map.RemoveAt(Gene[0]);
            for (int i = 1; i <= Towns.Count; i++)
            {
                if (i == Towns.Count)
                {
                    next = first;
                }
                else
                {
                    next = map[Gene[i]];
                    map.RemoveAt(Gene[i]);
                }
                totalDistance += Measure(current, next);
                current = next;
            }

            IsFit = true;
            Distance = totalDistance;

            //少ない方が適応度が高いので逆数をとる
            Fitness = (totalDistance == 0) ? 0 : 1 / totalDistance * 100;
            return Fitness;
        }
        public IGene Mutate()
        {
            for (int i = 0; i < Towns.Count; i++)
            {
                if (R.Next(0, 100) <= P.MutatePercent)
                {
                    Gene[i] = R.Next(0, Towns.Count - i);
                }
            }
            return this;
        }
        public IGene Copy()
        {
            IGene meme = new TSPGene();
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

        public static List<Point> Towns = new List<Point>();
        public double Distance { get; private set; }
        public TSPGene()
        {
            IsFit = false;
            Gene = new int[Towns.Count];
        }
        public double Measure(Point _from, Point _to)
        {
            return Math.Sqrt(Math.Pow(_to.x - _from.x, 2) +
                     Math.Pow(_to.y - _from.y, 2));
        }
        public override string ToString()
        {
            List<Point> map = new List<Point>(Towns);
            Point current = map[Gene[0]];
            StringBuilder ret = new StringBuilder();
            map.RemoveAt(Gene[0]);
            ret.Append(current);
            for (int i = 1; i < Towns.Count; i++)
            {
                ret.Append(map[Gene[i]]);
                map.RemoveAt(Gene[i]);
            }
            
            return String.Format("Distance:{0} Fitnss:{1} Pathway:{2}",
                Distance, Fitness, ret);
        }
        public class Point
        {
            public int x = 0, y = 0;
            public override string ToString()
            {
                return String.Format("(x:{0},y:{1})", x, y);
            }
        }
    }
}
