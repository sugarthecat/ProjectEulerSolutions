namespace ProjectEulerSolutions
{
    internal class p73
    {
        public static void Run()
        {
            int count = 0;
            for(int d = 2; d <= 12000;  d++)
            {
                int[] primeFactors = MathPlus.GetUniquePrimeFactors(d);
                for (int n = d/3; 2*n < d; n++)
                {
                    bool accepted = true;
                    for(int i = 0; i< primeFactors.Length; i++)
                    {
                        if ( n % primeFactors[i] == 0)
                        {
                            accepted = false;
                        }
                    }
                    if(accepted && n * 3 > d)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine("Count: " + count);
        }
    }
}