using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSolutions
{
    internal class MathPlus
    {
        /// <summary>
        /// Finds the greatest common factor between 2 numbers
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        public static int GCF(int n1, int n2)
        {
            if(n1 % n2 == 0)
            {
                return n2;
            }else if(n1 < n2)
            {
                return GCF(n2,n1);
            }
            else
            {
                return GCF(n2, n1 % n2);
            }
        }
    }
}
