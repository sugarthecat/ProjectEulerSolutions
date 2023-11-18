using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSolutions
{
    internal class p89
    {
        public static void Run()
        {
            string[] lines = TextReader.ReadFileLines("0089_roman.txt");
            int savings = 0;
            foreach (string line in lines)
            {
                int startingLength = line.Length;
                int value = RomanNumerals.ReadNumeral(line);
                string newNumeral = RomanNumerals.ConvertToNumeral(value);
                Console.WriteLine(line + " -> " + newNumeral);
                Console.WriteLine("Saved " + (startingLength - newNumeral.Length) + " characters");
                savings += startingLength - newNumeral.Length;
            }
            Console.WriteLine("Overall savings: " + savings);
        }
    }
}
