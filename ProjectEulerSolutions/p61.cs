namespace ProjectEulerSolutions
{
    internal class p61
    {
        public static void Run()
        {
            Func<int, int>[] generators = new Func<int, int>[] {
                (n => n * (n+1)/2),// triangle
                (n => n * n), //square
                (n => n * (3*n-1)/2), // pentagon

                (n => n * (2*n-1)), //hexagon
                (n => n * (5*n-3)/2), // heptagon
                (n => n * (3*n-2)), // octagon
            };
            List<Dictionary<int, List<int>>> numberTransformations = new List<Dictionary<int, List<int>>>();
            for (int i = 0; i < generators.Length; i++)
            {
                numberTransformations.Add(new Dictionary<int, List<int>>());
                int n = 1;
                int fn = 1;
                while (n < 10000)
                {
                    fn = generators[i](n);
                    if (fn > 1000)
                    {
                        int fragment1 = fn / 100;
                        int fragment2 = fn % 100;
                        if (numberTransformations[i].ContainsKey(fragment1))
                        {
                            if (!numberTransformations[i][fragment1].Contains(fragment2))
                            {
                                numberTransformations[i][fragment1].Add(fragment2);
                            }
                        }
                        else
                        {
                            numberTransformations[i][fragment1] = new List<int> { fragment2 };
                        }
                    }
                    n++;
                }
            }
            // try with all possible orders of number transformations
            Console.WriteLine(SolveAll(numberTransformations, new List<Dictionary<int, List<int>>>() { numberTransformations[0] }));
        }

        private static bool SolveAll(List<Dictionary<int, List<int>>> mappings, List<Dictionary<int, List<int>>> mappingsLeft)
        {
            if (mappings.Count == mappingsLeft.Count)
            {
                return Solve(mappingsLeft, new int[] { });
            }
            else
            {
                for (int insertIndex = 0; insertIndex < mappingsLeft.Count; insertIndex++)
                {
                    List<Dictionary<int, List<int>>> newMapping = new List<Dictionary<int, List<int>>>();
                    for (int i = 0; i < mappingsLeft.Count; i++)
                    {
                        if (insertIndex == i)
                        {
                            newMapping.Add(mappings[mappingsLeft.Count]);
                        }
                        newMapping.Add(mappingsLeft[i]);
                    }
                    if (SolveAll(mappings, newMapping))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private static bool Solve(List<Dictionary<int, List<int>>> mapping, int[] numsChosen)
        {
            if (numsChosen.Length == 0)
            {
                for (int i = 1; i < 100; i++)
                {
                    if (Solve(mapping, new int[] { i }))
                    {
                        return true;
                    }
                }
                return false;
            }
            else if (numsChosen.Length == mapping.Count)
            {
                if (!mapping[0].ContainsKey(numsChosen[numsChosen.Length - 1]))
                {
                    return false;
                }
                List<int> poss = mapping[0][numsChosen[numsChosen.Length - 1]];
                if (poss.Contains(numsChosen[0]))
                {
                    Console.WriteLine("Solved!");
                    Console.WriteLine(numsChosen[numsChosen.Length - 1] + "" + numsChosen[0]);
                    int sum = 0;
                    for (int i = 0; i < numsChosen.Length; i++)
                    {
                        if (i + 1 < numsChosen.Length)
                        {
                            Console.WriteLine(numsChosen[i] + "" + numsChosen[i + 1]);
                        }
                        sum += 101 * numsChosen[i];
                    }
                    Console.WriteLine("Sum: " + sum);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                int[] chosenInts = new int[numsChosen.Length + 1];
                for (int i = 0; i < numsChosen.Length; i++)
                {
                    chosenInts[i] = numsChosen[i];
                }
                if (!mapping[numsChosen.Length].ContainsKey(numsChosen[numsChosen.Length - 1]))
                {
                    return false;
                }
                for (int i = 0; i < mapping[numsChosen.Length][numsChosen[numsChosen.Length - 1]].Count; i++)
                {
                    chosenInts[chosenInts.Length - 1] = mapping[numsChosen.Length][numsChosen[numsChosen.Length - 1]][i];
                    if (Solve(mapping, chosenInts))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}