namespace ProjectEulerSolutions
{
    internal class p79
    {
        public static void Run()
        {
            string[] lines = TextReader.ReadFileLines("0079_keylog.txt");

            string start = "";
            string end = "";

            List<char> characters = new List<char>();
            foreach (string line in lines)
            {
                foreach (char c in line)
                {
                    if (!characters.Contains(c))
                    {
                        characters.Add(c);
                    }
                }
            }
            bool working = true;
            bool correct;
            int iteration = 1;
            while (working)
            {
                correct = true;
                working = false;
                Dictionary<char, bool> canStart = new Dictionary<char, bool>();
                Dictionary<char, bool> canEnd = new Dictionary<char, bool>();
                foreach (char c in characters)
                {
                    canStart[c] = true;
                    canEnd[c] = true;
                }
                foreach (string line in lines)
                {
                    int index = 0;
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (index == -1)
                        {
                            canStart[line[i]] = false;
                            correct = false;
                        }
                        else
                        {
                            index = start.IndexOf(line[i], index);
                            if(index == -1)
                            {
                                //last one found, this one isn't.
                                correct = false;
                            }
                            else
                            {
                                //this one is found
                                canStart[line[i]] = false;
                            }
                        }
                    }
                }
                foreach (char c in characters)
                {
                    if (canStart[c])
                    {
                        start += c;
                        working = true;
                    }
                }
                Console.Write("Iteration " + iteration++ + " - ");
                if (correct)
                {
                    Console.Write("Complete solution deduced \n");
                }
                else
                {
                    Console.Write(start.Length + " Characters deduced\n");
                }
            }
            Console.WriteLine("Solution: "+start);
        }
    }
}