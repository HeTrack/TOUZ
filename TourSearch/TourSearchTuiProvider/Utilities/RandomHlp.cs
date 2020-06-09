using System;
using System.Collections.Generic;
using System.Text;

namespace TourSearchTuiProvider.Utilities
{
    public static class RandomHlp
    {
        public static double NextDouble(this Random rnd, double min, double max)
        {
            return min + (max - min) * rnd.NextDouble();
        }
    }
}
