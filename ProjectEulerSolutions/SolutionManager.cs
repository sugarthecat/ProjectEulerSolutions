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
            switch(index)
            {
                case 51:
                    p51.Run();
                    break;
                case 89:
                    p89.Run();
                    break;
                default:
                    Console.WriteLine("Solution not implemented");
                    break;
            }
        }
    }
}
