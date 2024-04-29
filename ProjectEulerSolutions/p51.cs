namespace ProjectEulerSolutions
{
    internal class p51
    {
        private struct Evaluation
        {
            public string format;
            public int result;
            public Evaluation(string format, int result)
            {
                this.format = format;
                this.result = result;
            }
        }

        public static void Run()
        {
            Console.WriteLine(GetPossibleValueCount("56**3"));
            for(int i = 1; i<7; i++)
            {
                Evaluation eval = GetLargestValue("", i);

                Console.WriteLine("---------");
                Console.WriteLine(eval.format);
                Console.WriteLine(eval.result);
            }
        }

        // takes in format (ex: "9*1")
        // outputs count of valid primes
        private static int GetPossibleValueCount(string format)
        {
            
            int primes = 0;
            int initial = 0;
            if (format[0] == '*')
            {
                initial = 1;
            }
            for (int i = 0; i < 10; i++)
            {
                int newNum = Convert.ToInt32(format.Replace('*', i.ToString()[0])); // converts i to char
                if (MathPlus.IsPrime(newNum)){
                    primes++;
                }
            }
            if (!format.Contains('*'))
            {
                primes = Math.Min(primes, 1);
            }
            return primes;
        }

        private static Evaluation GetLargestValue(string prevString, int futureGens)
        {
            if (futureGens > 0)
            {
                string chars = "0123456789*";
                Evaluation bestEval = GetLargestValue(prevString + chars[0], futureGens-1);
                for (int i = 1; i < chars.Length; i++)
                {
                    Evaluation newEval = GetLargestValue(prevString + chars[i], futureGens - 1);
                    if(newEval.result > bestEval.result)
                    {
                        bestEval = newEval;
                    }
                }
                return bestEval;
            }
            else
            {
                return new Evaluation(prevString,GetPossibleValueCount(prevString));
            }
        }
    }
}