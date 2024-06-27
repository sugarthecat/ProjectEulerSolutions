namespace ProjectEulerSolutions
{
    internal class p70
    {
        public static void Run()
        {
            int max = 10000;
            List<int> primes = new List<int>() { 2,3 };
            for (int n = 6; n <= max; n += 6)
            {
                if (MathPlus.IsPrime(n-1))
                {
                    primes.Add(n-1);
                }
                if (MathPlus.IsPrime(n+1))
                {
                    primes.Add(n+1);
                }
            }
            double min = 100;
            int nForMin = 0;
            for(int i = primes.Count-1; i >= 0; i--)
            {
                for(int j = i-1; j >= 0; j--)
                {
                    
                    int n = primes[i] * primes[j];
                    if( n > 10000000)
                    {
                        continue;
                    }
                    if(MathPlus.SortNumber(MathPlus.Totient(n)) != MathPlus.SortNumber(n))
                    {
                        continue;
                    }
                    double fX = n/(double)MathPlus.Totient(n);
                    if(fX < min)
                    {
                        min = fX;
                        nForMin = primes[i] * primes[j];
                        Console.WriteLine("Minimum at n = " + nForMin);
                    }
                }
            }
        }
    }
}