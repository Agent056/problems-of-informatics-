﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Method3
    {
        string str1;
        string str2;

        public Method3(string Str1, string Str2)
        {
            str1 = " " + Str1.ToUpper();
            str2 = " " + Str2.ToUpper();
        }

        private double[][] table()
        {
            //условимся, строка - 1, столбец - 2
            double[][] d = new double[str2.Count()][];
            for(int i = 0; i < str2.Count(); i++)
                d[i] = new double[str1.Count()];

            for (int i = 0; i < str1.Count(); i++)
                d[0][i] = i;
            for (int i = 0; i < str2.Count(); i++)
                d[i][0] = i;

            char[] t1 = str1.ToArray();
            char[] t2 = str2.ToArray();

            //столбец
            for (int i = 1; i < str2.Count(); i++)
            {
                //строка
                for (int j = 1; j < str1.Count(); j++)
                {
                    if (t2[i] == t1[j])
                        d[i][j] = d[i - 1][j - 1];
                    else
                    {
                        double left = d[i][j-1];
                        double left_top = d[i-1][j-1];
                        double top = d[i-1][j];

                        double min = 0;
                        if (left <= left_top)
                        {
                            if (left <= top)
                                min = left;
                            else
                                min = top;
                        }
                        else
                        {
                            if (left_top <= top)
                                min = left_top;
                            else
                                min = top;
                        }

                        d[i][j] = min + 1;
                    }
                }
            }

            return d;
        }

        public double Func()
        {
            double[][] tab = table();

            double rez = tab[str2.Count() - 1][str1.Count() - 1];
            return rez;
        }
    }
}