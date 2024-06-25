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
            if (n1 % n2 == 0)
            {
                return n2;
            }
            else if (n1 < n2)
            {
                return GCF(n2, n1);
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
            if (n <= 1)
            {
                return false;
            }
            int max = (int)Math.Ceiling(Math.Sqrt(n));
            for (int i = 2; i < max; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Gets all prime factors of a given number
        /// </summary>
        /// <param name="n">The number which to search for factors of</param>
        /// <returns>an array of the number's prime factors</returns>
        public static int[] GetPrimeFactors(int n)
        {
            List<int> primeFactors = new List<int>();
            int numOn = n;
            int maxSearch = (int)Math.Ceiling(Math.Sqrt(n));
            for (int i = 1; i <= maxSearch; i++)
            {
                if (numOn % i == 0)
                {
                    primeFactors.Add(i);
                    i--;
                    numOn /= i;
                }
            }
            if (numOn != 1)
            {
                primeFactors.Add(numOn);
            }
            return primeFactors.ToArray();
        }

        /// <summary>
        /// Gets all prime factors of a given number
        /// </summary>
        /// <param name="n">The number which to search for factors of</param>
        /// <returns>an array of the number's prime factors</returns>
        public static int[] GetUniquePrimeFactors(int n)
        {
            List<int> primeFactors = new List<int>();
            int numOn = n;
            int maxSearch = (int)Math.Ceiling(Math.Sqrt(n));
            for (int i = 2; i <= maxSearch; i++)
            {
                if (numOn % i == 0)
                {
                    primeFactors.Add(i);
                    while(numOn % i == 0)
                    {
                        numOn /= i;
                    }
                    i--;
                }
            }
            if (numOn != 1)
            {
                primeFactors.Add(numOn);
            }
            return primeFactors.ToArray();
        }
        /// <summary>
        /// Gets an array of proper divisors for a given number
        /// </summary>
        /// <param name="n">the number to apply this to</param>
        /// <returns>the array of proper divisors</returns>
        public static int[] GetProperDivisors(int n)
        {

            List<int> divisors = new List<int>() { 1};
            int numOn = n;
            int maxSearch = (int)Math.Ceiling(Math.Sqrt(n));
            for (int i = 2; i <= maxSearch; i++)
            {
                if (numOn % i == 0)
                {
                    int count = 0;
                    while (numOn % i == 0)
                    {
                        count++;
                        numOn /= i;
                    }
                    int normalMax = divisors.Count;
                    
                    for(int j = 0;j<normalMax; j++)
                    {
                        for(int k = 1; k<=count;k++)
                        {
                            divisors.Add(Exponent(i,k) * divisors[j]);
                        }
                    }
                }
            }
            //add remaining num
            if (numOn != 1)
            {
                int normalMax = divisors.Count;
                for (int j = 0; j < normalMax; j++)
                {
                    divisors.Add(numOn* divisors[j]);
                }
            }
            return divisors.ToArray();
        }
        /// <summary>
        /// Finds an integer exponent, of the form a^b
        /// Precondition: exp is not negative
        /// </summary>
        /// <param name="baseN">the base of the exponent, or a in a^b</param>
        /// <param name="exp">the exponent, or b in a^b</param>
        /// <returns>The result of the expression</returns>
        public static int Exponent(int baseN, int exp)
        {
            int fx = 1;
            for(int i= 0; i<exp; i++)
            {
                fx *= baseN;
            }
            return fx;
        }
        /// <summary>
        /// Sums up an array of integers
        /// </summary>
        /// <param name="ints">the array of integers to sum</param>
        /// <returns>the sum</returns>
        public static int Sum(int[] ints)
        {
            int sum = 0; 
            for(int i = 0; i<ints.Length; i++)
            {
                sum += ints[i];
            }
            return sum;
        }
        /// <summary>
        /// Sorts the digits of a number, from highest to lowest. Used in matching numbers with the same digits in different orders.
        /// </summary>
        /// <param name="n">The number to sort</param>
        /// <returns>the number which consists of the input's digits sorted</returns>
        public static int SortNumber(int n)
        {
            int num = n;
            int[] ints = new int[10];
            while(num > 0)
            {
                ints[num%10]++;
                num /= 10;
            }
            int output = 0;
            for(int i = 9; i>=0; i--)
            {
                for(int j = 0; j < ints[i]; j++)
                {
                    output *= 10;
                    output += i;
                }
            }
            return output;
        }
    }
}