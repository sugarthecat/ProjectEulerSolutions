namespace ProjectEulerSolutions
{
    internal class p95
    {
        public static void Run()
        {
            int maxSearch = 1000000;
            bool[] searched = new bool[maxSearch + 1];
            int searchOn = 1;
            int largestAmicableChainLength = 0;
            int largestAmicableChain = 2;
            while (searchOn < maxSearch)
            {
                if (!searched[searchOn])
                {
                    List<int> numRing = new List<int>() { searchOn };
                    int originalNumber = searchOn;
                    int nextNum = findNextNumber(searchOn);
                    while (nextNum != originalNumber && nextNum <= maxSearch && !searched[nextNum])
                    {
                        searched[nextNum] = true;
                        numRing.Add(nextNum);
                        nextNum = findNextNumber(nextNum);
                    }
                    int length = 0;
                    for(int i = 0; i<numRing.Count; i++)
                    {
                        if (numRing[i] == nextNum)
                        {
                            length = numRing.Count-i;
                            originalNumber = numRing[i];
                        }
                    }
                    if (nextNum == originalNumber && length > largestAmicableChainLength)
                    {
                        largestAmicableChain = originalNumber;
                        largestAmicableChainLength = length;
                        Console.WriteLine("Largest: " + largestAmicableChain);
                        Console.WriteLine("Length: " + largestAmicableChainLength);
                    }
                }
                searchOn++;
            }
            Console.WriteLine("--------");
            //display full chain
            int n = largestAmicableChain;
            for(int i = 0; i<largestAmicableChainLength; i++)
            {
                Console.WriteLine(n + " -> " + findNextNumber(n));
                n = findNextNumber(n);
            }
        }

        public static int findNextNumber(int prevNum)
        {
            if (prevNum == 1)
            {
                return 1;
            }
            return MathPlus.Sum(MathPlus.GetProperDivisors(prevNum)) - prevNum;
        }
    }
}