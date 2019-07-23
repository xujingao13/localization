using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Algorithm
{
    public class Locate
    {
        public List<int> range;
        //row of beacon and length of d is m
        public int[] getLocation(string data, int[,] beacon, int m)
        {
            int[] d = analysizeDataString(data, m);
            int[] location = calculateLocation(d, beacon, m);
            return location;
        }
        public int[] analysizeDataString(string data, int m)
        {
            string[] mm = Regex.Split(data, "\\s+", RegexOptions.IgnoreCase);
            int[] d = new int[m];
            for(int i = 0; i < m; i++)
            {
                d[i] = Convert.ToInt32(mm[i + 2], 16);
                d[i] = d[i] * d[i];
            }
            return d;
        }

        public int[] calculateLocation(int[] d, int[,] beacon, int m)
        {
            Vector<double> location;
            //三维坐标
            int[] result = new int[3];
            //H矩阵
            double[,] x = new double[m - 1, 3];
            //b向量
            double[] y = new double[m - 1];
            for (int i = 0; i < m - 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    x[i, j] = beacon[i + 1, j] - beacon[0, j];
                }
            }
            Matrix<double> M = DenseMatrix.OfArray(x);

            var distance1 = beacon[0, 0] * beacon[0, 0] + beacon[0, 1] * beacon[0, 1] + beacon[0, 2] * beacon[0, 2];
            for (int i = 1; i < m; i++)
            {
                var distance2 = beacon[i, 0] * beacon[i, 0] + beacon[i, 1] * beacon[i, 1] + beacon[i, 2] * beacon[i, 2];
                y[i - 1] = 0.5 * (distance2 - d[i] - (distance1 - d[0]));
            }
            Vector<double> V = Vector<double>.Build.Dense(y);

            location = (M.Transpose() * M).PseudoInverse() * M.Transpose() * V;

            for (int i = 0; i < 3; i++)
            {
                result[i] = Convert.ToInt32(location[i]);
            }
            return result;
        }
    }
}
