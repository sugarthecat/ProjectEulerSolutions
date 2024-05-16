namespace ProjectEulerSolutions
{
    internal class p76
    {
        public static void Run()
        {
            int simulationN = 100;
            Console.WriteLine(GetSummationPossibilities(simulationN,simulationN-1));
        }
        private static int GetSummationPossibilities(int sumRemaining, int maxInt)
        {
            if (sumRemaining ==  0|| maxInt == 1) {
                return 1;
            }
            
            int possibRemaining = 0;
            for(int i = 1; i <= maxInt && sumRemaining-i >= 0; i++)
            {
                possibRemaining += GetSummationPossibilities(sumRemaining - i, i);
            }
            return possibRemaining;
        }
    }
}