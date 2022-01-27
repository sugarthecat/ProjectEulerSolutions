using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Runtime;

namespace EulerSolutions
{
    class Program
    {
        static int ConsonantCount(string InputText)
        {
            int consonants = 0;
            string cst = "qwrtpsdfghjklzxcvbnm";
            for (var i = 0; i < InputText.Length; i++)
            {
                if (cst.Contains(InputText.Substring(i, 1).ToLower()))
                {
                    consonants++;
                }
            }
            return consonants;
        }
        static int factorial(int input)
        {
            int output = 1;
            for (int i = input; i > 0; i--)
            {
                output *= i;
            }
            return output;
        }
        static string reverse(string input)
        {
            string outnum = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                outnum += input.Substring(i, 1);
            }
            return outnum;
        }
        static List<int> toBinary(int intt)
        {
            List<int> binaryVersion = new List<int>();
            binaryVersion.Add(intt);
            while (binaryVersion[binaryVersion.Count - 1] > 1)
            {
                binaryVersion.Add(binaryVersion[binaryVersion.Count - 1] - (binaryVersion[binaryVersion.Count - 1] % 2));
                binaryVersion[binaryVersion.Count - 1] /= 2;
                binaryVersion[binaryVersion.Count - 2] %= 2;
            }
            return binaryVersion;
        }
        static bool isPrimeProof(long inNum)
        {

            for (int place = 0; place < inNum.ToString().Length; place++)
            {
                if (inNum % 5 == 0 || inNum % 2 == 0)
                {

                }
                for (int replace = 0; replace < 10; replace++)
                {
                    string checking = inNum.ToString().Substring(0, place) + replace.ToString() + inNum.ToString().Substring(place + 1, inNum.ToString().Length - (place + 1));
                    if (checking != inNum.ToString() && checkPrime(Convert.ToInt64(checking)) && Convert.ToInt64(checking) != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static bool isCircularPrime(int inNum)
        {
            string s = inNum.ToString();
            int checkint;
            for (int i = 0; i < s.Length; i++)
            {
                checkint = Convert.ToInt32(s);
                if (!checkPrime(checkint))
                {
                    return false;
                }
                s = s.Substring(s.Length - 1, 1) + s.Substring(0, s.Length - 1);
            }
            return true;
        }
        static List<List<int>> allPandigitals(int length)
        {

            int max = factorial(length);
            int numon = 0;
            List<List<int>> Pandiggies = new List<List<int>>();
            while (numon <= max)
            {
                List<int> remainingNums = new List<int>();
                List<int> eText = new List<int>();
                for (int i = 0; i < length; i++)
                {
                    remainingNums.Add(i);
                }
                double possibs = Convert.ToDouble(factorial(length));
                while (remainingNums.Count > 1)
                {
                    int workwith = Convert.ToInt32(Math.Floor((Convert.ToDouble(numon) % possibs) / (possibs / Convert.ToDouble(remainingNums.Count))));
                    eText.Add(remainingNums[workwith]);
                    possibs /= remainingNums.Count;
                    remainingNums.RemoveAt(workwith);

                }
                numon++;
                eText.Add(remainingNums[0]);
                Pandiggies.Add(eText);
            }
            return Pandiggies;
        }

        static int VowelCount(string InputText)
        {
            int vowels = 0;
            string cst = "aeiouy";
            for (var i = 0; i < InputText.Length; i++)
            {
                if (cst.Contains(InputText.Substring(i, 1).ToLower()))
                {
                    vowels++;
                }
            }
            return vowels;
        }

        static int primes = 2;
        static int percent = 0;
        static private List<int> ProperDivisors(int toFactorize)
        {
            List<int> factorize = PrimeFactorize(toFactorize);

            List<int> primenum = new List<int>();
            List<int> primecount = new List<int>();
            List<int> answer = new List<int>();
            primenum.Add(1);
            primecount.Add(1);
            for (int i = 0; i < factorize.Count; i++)
            {
                if (primenum.Contains(factorize[i]))
                {
                    primecount[primenum.IndexOf(factorize[i])]++;
                }
                else
                {
                    primenum.Add(factorize[i]);
                    primecount.Add(1);
                }
            }
            //Console.WriteLine(string.Join(",", primenum));
            //Console.WriteLine(string.Join(",", primecount));
            List<int> numsSoFar = new List<int>();
            answer.Add(1);
            for (int i = 0; i < primenum.Count; i++)
            {
                for (int v = 1; v <= primecount[i]; v++)
                {
                    foreach (int divisor in answer)
                    {
                        int timesnum = 1;
                        for (var r = 0; r < v; r++)
                        {
                            timesnum *= primenum[i];
                        }
                        numsSoFar.Add(divisor * timesnum);
                    }
                }
                foreach (int divisor in numsSoFar)
                {
                    if (!answer.Contains(divisor))
                    {
                        answer.Add(divisor);
                    }
                }
            }
            answer.Sort();
            return answer;
        }
        static private List<Int32> PrimeFactorize(Int32 toFactorize)
        {
            int pfac = toFactorize;
            List<Int32> a = new List<Int32>();
            for (int i = 2; i <= pfac; i++)
            {
                if (pfac % i == 0)
                {
                    pfac /= i;
                    a.Add(i);
                    i = 1;
                }
            }

            return a;
        }
        static private int sumOfString(string nummer)
        {
            int total = 0;
            foreach (char i in nummer)
            {
                total += Convert.ToInt32(i.ToString());
            }
            return total;
        }
        static private bool stringGreaterThan(string str1, string str2)
        {
            if (str1.Length > str2.Length)
            {
                return true;
            }
            if (str2.Length > str1.Length)
            {
                return false;
            }
            for (int i = 0; i < str2.Length; i++)
            {
                if (Convert.ToInt32(str2.Substring(i, 1)) > Convert.ToInt32(str1.Substring(i, 1)))
                {
                    return false;

                }
                if (Convert.ToInt32(str2.Substring(i, 1)) < Convert.ToInt32(str1.Substring(i, 1)))
                {
                    return true;
                }
            }
            return false;
        }
        static private string MultiplyStrings(string mult1, int mult2)
        {
            string total = "0";
            List<string> totals = new List<string>();
            List<int> positions = new List<int>();
            for (int i = 0; i < mult2; i++)
            {
                bool haveFix = false;
                int fixpos = 0;
                for (int v = positions.Count - 1; v >= 0; v--)
                {
                    if (positions[v] + i < mult2)
                    {
                        haveFix = true;
                        fixpos = v;
                    }
                }
                if (haveFix)
                {
                    total = AddStrings(total, totals[fixpos]);
                    i += positions[fixpos];

                }
                else
                {
                    total = AddStrings(mult1, total);

                }
                totals.Add(total);
                positions.Add(i);
            }
            //Console.WriteLine("added: " + string.Join(" ",totals));

            return total;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mult1"></param>
        /// <param name="mult2"></param>
        /// <returns></returns>
        static private string MultiplyBigStrings(string mult1, ulong mult2)
        {
            string total = "0";
            List<string> totals = new List<string>();
            List<ulong> positions = new List<ulong>();
            for (ulong i = 0; i < mult2; i++)
            {
                bool haveFix = false;
                int fixpos = 0;
                for (int v = positions.Count - 1; v > 0; v--)
                {
                    if (positions[v] + Convert.ToUInt64(i) < mult2)
                    {
                        haveFix = true;
                        fixpos = v;
                        v = 0;
                    }
                }
                if (haveFix)
                {
                    total = AddStrings(total, totals[fixpos]);
                    i += positions[fixpos];

                }
                else
                {
                    total = AddStrings(mult1, total);
                }
                totals.Add(total);
                positions.Add(i);
                //Console.WriteLine("Increased by "+ totals[fixpos]);
            }
            //Console.WriteLine("added: " + string.Join(" ",totals));
            return total;
        }
        static private string stringPower(string mult1, int mult2)
        {
            string total = "1";
            List<string> totals = new List<string>();
            List<int> positions = new List<int>();
            for (int i = 0; i < mult2; i++)
            {
                bool haveFix = false;
                int fixpos = 0;
                for (int v = positions.Count - 1; v >= 0; v--)
                {
                    if (positions[v] + i < mult2)
                    {
                        haveFix = true;
                        fixpos = v;
                    }
                }
                if (haveFix)
                {
                    total = MultiplyStrings(total, Convert.ToInt32(totals[fixpos]));
                    i += positions[fixpos];

                }
                else
                {
                    total = MultiplyStrings(total, Convert.ToInt32(mult1));

                }
                totals.Add(total);
                positions.Add(i);
            }
            //Console.WriteLine("added: " + string.Join(" ",totals));
            return total;
        }
        static private string AddStrings(string addnum1, string addnum2)
        {
            string sum = "";
            int carry = 0;
            int prechecknum = 0;
            int continueTo = addnum1.Length;
            if (addnum2.Length > continueTo)
            {
                continueTo = addnum2.Length;
            }
            for (var i = 1; i <= continueTo; i++)
            {
                if (continueTo - i < 5 && addnum1.Length > i + 5 && addnum2.Length > i + 5)
                {

                    prechecknum = Convert.ToInt32(addnum1.Substring(addnum1.Length - i, 5)) + Convert.ToInt32(addnum2.Substring(addnum2.Length - i, 5)) + carry;
                    carry = (prechecknum - prechecknum % 100000) / 100000;
                    prechecknum = prechecknum % 100000;
                    sum = prechecknum.ToString() + sum;
                    i += 4;
                }
                else if (continueTo - i < 3 && addnum1.Length > i + 3 && addnum2.Length > i + 3)
                {

                    prechecknum = Convert.ToInt32(addnum1.Substring(addnum1.Length - i, 3)) + Convert.ToInt32(addnum2.Substring(addnum2.Length - i, 3)) + carry;
                    carry = (prechecknum - prechecknum % 1000) / 1000;
                    prechecknum = prechecknum % 1000;
                    sum = prechecknum.ToString() + sum;
                    i += 2;
                }
                else
                {
                    if (i <= addnum1.Length && i <= addnum2.Length)
                    {
                        prechecknum = Convert.ToInt32(addnum1.Substring(addnum1.Length - i, 1)) + Convert.ToInt32(addnum2.Substring(addnum2.Length - i, 1)) + carry;
                    }
                    else if (i <= addnum1.Length)
                    {
                        prechecknum = Convert.ToInt32(addnum1.Substring(addnum1.Length - i, 1)) + carry;
                    }
                    else
                    {
                        prechecknum = Convert.ToInt32(addnum2.Substring(addnum2.Length - i, 1)) + carry;
                    }
                    carry = (prechecknum - prechecknum % 10) / 10;
                    prechecknum = prechecknum % 10;
                    sum = prechecknum.ToString() + sum;
                }

            }
            if (carry > 0)
            {
                sum = carry.ToString() + sum;
            }
            return sum;
        }

        static private Boolean checkPrime(Int64 checknum)
        {
            Int64 newcheck = Convert.ToInt64(checknum);
            Int64[] earlyprimes = { 2, 3, 5, 7, 11 };
            if (earlyprimes.Contains(checknum))
            {
                return true;
            }
            if ((checknum % 2 == 0 && checknum > 2) || (checknum == 1) || checknum == 0)
            {
                return false;
            }
            for (var x = 3; x <= Math.Sqrt(checknum) + 2; x += 2)
            {
                if (checknum % x == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static private string findCycle(string inputtext)
        {
            string toBeTrimmed = inputtext.Substring(100, inputtext.Length - 101);

            for (int i = 1; i < toBeTrimmed.Length / 2 - 1; i++)
            {
                if (toBeTrimmed.Substring(0, i) == toBeTrimmed.Substring(i, i) && toBeTrimmed.Substring(i, i) == toBeTrimmed.Substring(i * 2, i) && toBeTrimmed.Substring(i * 2, i) == toBeTrimmed.Substring(i * 3, i))
                {
                    return toBeTrimmed.Substring(0, i);
                }
            }
            return "Error";
        }
        static private int DayOfWeek(int day, int month, int year)
        {
            int[] normalyear = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31, };
            int[] leapyear = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31, };
            int counterday = 1;
            int countermonth = 1;
            int counteryear = 1900;
            int dayofweek = 0;
            while (counterday != day || countermonth != month || counteryear != year)
            {
                counterday++;
                dayofweek++;
                dayofweek %= 7;
                if (counteryear % 4 == 0 && (counteryear % 100 != 0 || counteryear % 400 == 0))
                {
                    //leap year
                    if (counterday > leapyear[countermonth - 1])
                    {
                        counterday = 1;
                        countermonth++;
                    }
                    if (countermonth > 12)
                    {
                        countermonth = 1;
                        counteryear++;
                        //Console.WriteLine(counteryear);
                    }
                }
                else
                {
                    //non-leap year
                    if (counterday > normalyear[countermonth - 1])
                    {
                        counterday = 1;
                        countermonth++;
                    }
                    if (countermonth > 12)
                    {
                        countermonth = 1;
                        counteryear++;
                    }
                }
            }
            return dayofweek + 1;
        }
        static private string SpellWord(int spellnum)
        {
            string[] teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty" };
            string[] ones = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string word = "";
            if (spellnum % 100 >= 10 && spellnum % 100 < 20)
            {
                word += teens[spellnum % 10];
            }
            else
            {
                word += tens[spellnum % 100 / 10];
                word += ones[spellnum % 10];
            }
            if (spellnum >= 100)
            {
                if (spellnum % 100 == 0 && spellnum < 1000)
                {
                    word = ones[spellnum / 100] + " hundred " + word;
                }
                else if (spellnum < 1000)
                {
                    word = ones[spellnum / 100] + " hundred and " + word;
                }
                else
                {
                    word = "one thousand";
                }
            }
            word = ReplaceAll(word, "  ", " ");
            return word;
        }
        static private string ReplaceAll(string maintext, string replacetext, string overwritetext)
        {
            string text = maintext;
            int letterChecking = 0;
            while (letterChecking + replacetext.Length < text.Length)
            {
                if (text.Substring(letterChecking, replacetext.Length) == replacetext)
                {
                    text = text.Substring(0, letterChecking) + overwritetext + text.Substring(letterChecking + replacetext.Length, text.Length - letterChecking - replacetext.Length);
                    letterChecking += overwritetext.Length;
                }
                letterChecking++;
            }
            return text;
        }
        static private bool isPowerOf2(double input)
        {
            while (input != 1)
            {
                if (input < 1)
                {
                    return false;
                }
                input /= 2;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Euler time!");
            Console.WriteLine("Which problem do you wanna solve?");
            switch (Console.ReadLine()){
                case "39":
                    int numOfSolutions(int p)
                    {
                        int numo = 0;
                        for (int a = 1; a< p; a++)
                        {
                            for(int b = a; a + b < p; b++)
                            {
                                if( (a*a) + (b*b) == (p - a - b) * (p - a - b))
                                {
                                    numo++;
                                    //Console.WriteLine(a + "," + b + "," + (p - a - b));
                                }
                            }
                        }
                        return numo;
                                }
                    int maxsols = 0;
                    for(int i = 1; i<=1000; i++)
                    {
                        if (numOfSolutions(i) > maxsols)
                        {
                            maxsols = numOfSolutions(i);
                            Console.WriteLine(i);
                        }
                    }
                    break;
                
                case "44":
                    List<long> pentNums = new List<long>();
                    List<int> primes = new List<int>();
                    List<List<long>> validNumsOfPrimes = new List<List<long>>();
                    for (int i = 4; i < 100; i++)
                    {
                        if (checkPrime(i))
                        {
                            primes.Add(i);
                            validNumsOfPrimes.Add(new List<long>());
                        }
                    }
                    bool isPentagonal(long l, List<long> pentnums)
                    {
                        for (int i = 0; i < primes.Count; i++)
                        {
                            if (!validNumsOfPrimes[i].Contains(l % primes[i]))
                            {
                                return false;
                            }
                        }
                        return pentnums.Contains(l);
                    }
                    for (long i = 1; i < 1000000; i++)
                    {
                        pentNums.Add(i * (3 * i - 1) / 2);
                        for (int n = 0; n < primes.Count; n++)
                        {
                            if (!validNumsOfPrimes[n].Contains(pentNums[pentNums.Count - 1] % primes[n]))
                            {
                                validNumsOfPrimes[n].Add(pentNums[pentNums.Count - 1] % primes[n]);
                                Console.WriteLine(primes[n] + " has " + pentNums[pentNums.Count - 1] % primes[n]);
                            }
                        }
                        //Console.WriteLine(pentNums[Convert.ToInt32(i-1)] + "," + pentNums[Convert.ToInt32(i - 1)] % 11 + "," + pentNums[Convert.ToInt32(i - 1)] % 3 + "," + pentNums[Convert.ToInt32(i - 1)]%2);
                    }
                    for (int x = 0; x < pentNums.Count; x++)
                    {
                        if (x % 100000 == 0 || x < 1000 || (x < 100000 && x % 1000 == 0))
                        {
                            Console.WriteLine(x);
                        }
                        for (int y = x; y < pentNums.Count; y++)
                        {
                            if (y % 100000 == 0 && x <= 5)
                            {
                                //Console.WriteLine(y + "y");
                            }
                            if (pentNums[pentNums.Count - 1] < pentNums[x] + pentNums[y])
                            {
                                y = pentNums.Count;
                            }
                            else if (x != y && isPentagonal(pentNums[x] + pentNums[y], pentNums) && isPentagonal(Math.Abs(pentNums[y] - pentNums[x]), pentNums))
                            {
                                Console.WriteLine(pentNums[x] + "," + pentNums[y]);
                                Console.WriteLine(pentNums[y] - pentNums[x]);
                                x = pentNums.Count;
                            }
                        }
                    }
                    break;
                case "59":

                    break;
            }

        }
    }
}
