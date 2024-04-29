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
        /// <summary>
        /// Checks if a given number is prime
        /// Precondition: n is 2 or larger
        /// </summary>
        /// <param name="n">the number to check prime status</param>
        /// <returns>a boolean, true if and only if the number is prime</returns>
        public static bool IsPrime(int n)
        {
            if(n <= 1)
            {
                return false;
            }
            int max = (int)Math.Ceiling(Math.Sqrt(n));
            for(int i = 2; i < max; i++)
            {
                if(n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
