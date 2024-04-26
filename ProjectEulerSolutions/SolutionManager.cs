using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSolutions
{
    internal class SolutionManager
    {

        public static void RunSolution(int index)
        {
            Console.WriteLine("--------");
            switch (index)
            {
                case 51:
                    p51.Run();
                    break;
                case 79:
                    p79.Run();
                    break;
                case 89:
                    p89.Run();
                    break;
                case 91:
                    p91.Run();
                    break;
                case 92:
                    p92.Run();
                    break;
                default:
                    Console.WriteLine("Solution not implemented");
                    break;
            }
        }
    }
}
