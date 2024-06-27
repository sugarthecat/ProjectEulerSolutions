using System.Runtime.CompilerServices;

namespace ProjectEulerSolutions
{
    internal class p69
    {
        public static void Run()
        {
            int max = 1000000;
            int maxN = -1;
            double maxNValue = 0;
            for(int n = 2; n <= max; n++)
            {
                int totientN = MathPlus.Totient(n);
                if(maxNValue < (double)n/ (double)totientN)
                {
                    maxN = n;
                    maxNValue =(double)n / (double)totientN ;
                    Console.WriteLine("φ("+n+") = " + totientN + ", n/φ(n) ≈ " + maxNValue );
                }
            }
        }
    }
}