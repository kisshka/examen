using System;
using System.Collections.Generic;
using System.Text;

namespace MinDistanceFounder
{
    public class WaysFounder
    {
        private int n = 10;

        public double DistanceFounder(double[,] ways, int firstPoint, int secondPoint)
        {
            return ways[firstPoint - 1, secondPoint - 1];
        }

        //Функция для нахождения кратчайших путей
        public double[,] Floyd(double[,] a)
        {
            double[,] d = new double[n, n];
            d = (double[,])a.Clone();
            for (int i = 1; i <= n; i++)
                for (int j = 0; j <= n - 1; j++)
                    for (int k = 0; k <= n - 1; k++)
                        if (d[j, k] > d[j, i - 1] + d[i - 1, k])
                            d[j, k] = d[j, i - 1] + d[i - 1, k];
            return d;
        }
    }
}
