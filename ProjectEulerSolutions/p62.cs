namespace ProjectEulerSolutions
{
    internal class p62
    {
        private struct Stats
        {
            public int count;
            public int min;
            Stats(int min)
            {
                count = 1;
                this.min = min;
            }
        }

        public static void Run()
        {
            int exactPermutations = 5;
            long maxSearch = 2097152;
            Dictionary<string,long> counts = new Dictionary<string, long>();
            List<long> smallestItems = new List<long>();
            for (long i = 0; i < maxSearch; i++)
            {
                string sortedCube = GetSortedString(i * i * i);
                if (counts.ContainsKey(sortedCube))
                {
                    counts[sortedCube]++;
                }
                else
                {
                    counts[sortedCube] = 1;
                    smallestItems.Add(i);
                }
            }
            for(int i = 0;i < smallestItems.Count; i++)
            {
                string sortedCube = GetSortedString(smallestItems[i] * smallestItems[i] * smallestItems[i]);
                if (counts[sortedCube] == exactPermutations)
                {
                    Console.WriteLine(smallestItems[i] + " is the smallest number with " + exactPermutations + " cubic permutations");
                    Console.WriteLine(smallestItems[i] + "^3 =  " + (smallestItems[i] * smallestItems[i] * smallestItems[i]));
                    break;
                }
            }
        }
        public static string GetSortedString(long num)
        {
            char[] chars = { '9', '8', '7', '6', '5', '4', '3', '2', '1', '0' };
            string numString = num.ToString();
            string outstring = "";
            for(int i = 0; i < chars.Length; i++)
            {
                for(int j = 0; j < numString.Length; j++)
                {
                    if (chars[i] == numString[j])
                    {
                        outstring += chars[i];
                    }
                }
            }
            return outstring;
        }
    }
}