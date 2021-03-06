﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class Jaro
    {
        public Jaro() { }

        public double Func(string Str1, string Str2)
        {
            string str1 = Str1.ToLower();
            string str2 = Str2.ToLower();

            // первая строка по вертикали
            double[][] matrix = new double[str1.Count()][];
            for (int i = 0; i < str1.Count(); i++)
                matrix[i] = new double[str2.Count()];

            for (int i = 0; i < str1.Count(); i++)
            {
                for (int j = 0; j < str2.Count(); j++)
                {
                    if (str1[i] == str2[j])
                        matrix[i][j] = 1;
                    else
                        matrix[i][j] = 0;
                }
            }

            int dist = 0;
            if (str1.Count() >= str2.Count())
                dist = str1.Count() / 2 - 1;
            else
                dist = str2.Count() / 2 - 1;

            double m = 0;
            int t = 0;

            for (int i = 0; i < str1.Count() & i < str2.Count(); i++)
            {
                for (int k = i - dist; k <= i + dist; k++)
                {
                    if (k >= 0 & k < str2.Count())
                    {
                        if (matrix[k][i] == 1)
                        {
                            m++;
                            if (k != i)
                                t++;
                        }
                    }
                }
            }
            t = t / 2;

            if (m == 0)
                return 0;
            else
                return 1 - 1 / 3.0 * (m / str1.Count() + m / str2.Count() + (m - t) / m);
        }
    }
}
