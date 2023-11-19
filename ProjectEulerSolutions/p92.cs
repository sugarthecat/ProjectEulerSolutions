using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSolutions
{
    internal class p92
    {
        public static void Run()
        {
            //proud of this, should trend towards O(n), or O(1) per sim
            int reaches89 = 0;
            const int sim_max = 10000000; //10 million
            int[] destinations = new int[sim_max];
            for(int startValue = 1; startValue < sim_max; startValue++)
            {
                int currValue = startValue;
                while(currValue != 1 && currValue != 89)
                {
                    currValue = SquareDigits(currValue);
                    if (destinations[currValue] != 0) {
                        currValue = destinations[currValue];
                    }
                }
                destinations[startValue] = currValue;
                if(currValue == 89)
                {
                    reaches89++;
                }
            }
            Console.WriteLine(reaches89 + " reach 89");
        }
        public static int SquareDigits(int value)
        {
            int totalSquareValue = 0;
            int currentWorkingValue = value;
            while (currentWorkingValue > 0)
            {
                int digit = currentWorkingValue % 10;
                currentWorkingValue -= digit;
                currentWorkingValue /= 10;
                totalSquareValue += digit*digit;
            }
            return totalSquareValue;
        }
    }
}
