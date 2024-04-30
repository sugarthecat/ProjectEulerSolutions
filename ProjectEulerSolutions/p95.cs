namespace ProjectEulerSolutions
{
    internal class p95
    {
        public static void Run()
        {
            int maxSearch = 1000000;
            bool[] searched = new bool[maxSearch];
            int searchOn = 1;
            int largestAmicableChainLength = 1;
            int largestAmicableChain = 1;
            while(searchOn < maxSearch)
            {
                if (!searched[searchOn])
                {
                    int length = 1;
                    int originalNumber = searchOn;
                    int nextNum = findNextNumber(searchOn);
                    while (nextNum != originalNumber && nextNum <= maxSearch && !searched[nextNum])
                    {
                        searched[nextNum] = true;
                        length++;
                        nextNum = findNextNumber(nextNum);
                    }
                    if (nextNum  == originalNumber && length > largestAmicableChainLength)
                    {
                        largestAmicableChain = searchOn;
                        largestAmicableChainLength = length;
                        Console.WriteLine("Largest: " + largestAmicableChain);
                        Console.WriteLine("Length: " + largestAmicableChainLength);
                    }
                }
                searchOn++;
            }
        }
        public static int findNextNumber(int prevNum)
        {
            if(prevNum == 1)
            {
                return 1;
            }
            return MathPlus.Sum(MathPlus.GetProperDivisors(prevNum))-prevNum;
        }
    }
}