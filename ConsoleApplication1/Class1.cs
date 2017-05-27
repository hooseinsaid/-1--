using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class GridProblems
    {
        int m;
        int n;
        int k;
        int[,] Points;
        public GridProblems(int[] points, int k, int m, int n)
        {
            this.m = m;
            this.n = n;
            this.k = k;
        }
        /*bool VerifyPoint(int x, int y)
        {
            bool goodpoint = false;
            bool found1 = false;
            bool found2 = false;
            for (int i = x; i < m; i++)
            {
                for (int j = y; j < n; y++)
                {
                    if (Points[i, j] == 1)
                    {
                        found1 = true;
                        break;
                    }
                }
                for (int j = 0; j < y; y++)
                {
                    if (Points[i, j] == 1)
                    {
                        found2 = true;
                        break;
                    }
                }
                if ((found1 && found2) || !(found1 && found2))
                {
                    return false;
                }
                else
                {
                    for (int i = x; i < m; i++)
                    {
                        for (int j = y; j < n; y++)
                        {
                            if (Points[i, j] == 1)
                            {
                                found1 = true;
                                break;
                            }
                        }
                        for (int j = 0; j < y; y++)
                        {
                            if (Points[i, j] == 1)
                            {
                                found2 = true;
                                break;
                            }
                        }
                }
                
            }
            return true;
        }*/
    }
}
