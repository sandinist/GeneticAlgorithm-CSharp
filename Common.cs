using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    /// <summary>乱数生成クラス</summary>
    public static class R
    {
        private static Random ran = new Random();
        public static int Next(int _seed, int _max)
        {
            return ran.Next(_seed, _max);
        }
    }

    /// <summary>共通パラーメータクラス</summary>
    public static class P
    {
        /// <summary>個体数</summary>
        public static int GeneNumber { get; set; }
        /// <summary>世代数</summary>
        public static int GenerationNumber { get; set; }
        /// <summary>エリート保存率</summary>
        public static int EletePercent { get; set; }
        /// <summary>交叉率</summary>
        public static int CrossOverPercent { get; set; }
        /// <summary>変異率</summary>
        public static int MutatePercent { get; set; }
        /// <summary>世代合計適応度</summary>
        public static double TotalFitness;
    }
}
