using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSolutions
{
    internal class RomanNumerals
    {
        public static int ReadNumeral(string numeral)
        {
            char[] chars = numeral.ToCharArray();
            int[] charValues = new int[chars.Length];
            for(int i =0; i < chars.Length; i++)
            {
                charValues[i] = GetCharacterValue(chars[i]);
            }
            int totalValue = 0;
            for(int i = 0; i < charValues.Length; i++)
            {
                if (i == charValues.Length - 1 || charValues[i] >= charValues[i+1])
                {
                    totalValue += charValues[i];
                }
                else
                {
                    totalValue -= charValues[i];
                }

            }
            return totalValue;
        }
        /// <summary>
        /// Converts an integer into roman numerals
        /// </summary>
        /// <param name="value">The value to convert</param>
        /// <returns></returns>
        public static string ConvertToNumeral(int value)
        {
            string output = "";
            int remainingValue = value;
            while(remainingValue > 0)
            {
                //not computationally ideal to have these nested if's, but works organizationally
                if (remainingValue > 1000)
                {
                    //work in 1000s place
                    output += "M";
                    remainingValue -= 1000;
                }
                else if (remainingValue >= 100)
                {
                    //work in 100s place
                    if(remainingValue >= 900)
                    {
                        //900 in 100s digit
                        output += "CM";
                        remainingValue -= 900;
                    }
                    else if (remainingValue >= 500)
                    {
                        // <900, >=500 in 100s digit
                        output += "D";
                        remainingValue -= 500;
                    }
                    else if (remainingValue >= 400)
                    {
                        // <500, >=400 in 100s digit
                        output += "CD";
                        remainingValue -= 400;
                    }
                    else
                    {
                        //default
                        output += "C";
                        remainingValue -= 100;
                    }
                }
                else if (remainingValue >= 10)
                {
                    //work in 10s place
                    if (remainingValue >= 90)
                    {
                        //90 in 10s digit
                        output += "XC";
                        remainingValue -= 90;
                    }
                    else if (remainingValue >= 50)
                    {
                        // <90, >=50 in 10s digit
                        output += "L";
                        remainingValue -= 50;
                    }
                    else if (remainingValue >= 40)
                    {
                        // <50, >=40 in 10s digit
                        output += "XL";
                        remainingValue -= 40;
                    }
                    else
                    {
                        //default
                        output += "X";
                        remainingValue -= 10;
                    }
                }
                else
                {
                    //work in 1s place
                    if (remainingValue >= 9)
                    {
                        //9 in 1s digit
                        output += "IX";
                        remainingValue -= 9;
                    }
                    else if (remainingValue >= 5)
                    {
                        // <9, >=5 in 1s digit
                        output += "V";
                        remainingValue -= 5;
                    }
                    else if (remainingValue >= 4)
                    {
                        // <5, >=4 in 1s digit
                        output += "IV";
                        remainingValue -= 4;
                    }
                    else
                    {
                        //default
                        output += "I";
                        remainingValue -= 1;
                    }
                }
            }
            return output;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public static int GetCharacterValue(char character)
        {
            int value = 0;
            switch(character)
            {
                case 'I':
                    value = 1;
                    break;
                case 'V':
                    value = 5;
                    break;
                case 'X':
                    value = 10;
                    break;
                case 'L':
                    value = 50;
                    break;
                case 'C':
                    value = 100;
                    break;
                case 'D':
                    value = 500;
                    break;
                case 'M':
                    value = 1000;
                    break;
                default: 
                    value = 0;
                    break;
            }
            return value;
        }
    }
}
