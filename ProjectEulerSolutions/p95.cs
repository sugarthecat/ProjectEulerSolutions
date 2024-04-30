namespace ProjectEulerSolutions
{
    internal class p95
    {
        public static void Run()
        {
            int maxSearch = 15000;
            bool[] searched = new bool[maxSearch+1];
            int searchOn = 1;
            int largestAmicableChainLength = 0;
            int largestAmicableChain;
            while(searchOn < maxSearch)
            {
                if (!searched[searchOn])
                {
                    Console.WriteLine(searchOn);
                    int length = 1;
                    int originalNumber = searchOn;
                    int nextNum = findNextNumber(searchOn);
                    if (originalNumber == 12496)
                    {
                        Console.WriteLine(nextNum);
                    }
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
                    else
                    {
                        Console.WriteLine("no work out - " + searchOn);
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