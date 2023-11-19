using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSolutions
{
    internal class p91
    {
        public static void Run()
        {
            //looks like O(n^4)
            int count = GetPossibleRightTriangles(50, 50);
            Console.WriteLine("Triangle count: " + count);
        }
        public static int GetPossibleRightTriangles(int xmax, int ymax)
        {
            //all right angles caused by linearity (i.e. x[0]=x[1]&y[0]=y[2])
            //3 cases, each occur xmax*ymax times
            //case 1: (0,0) is the right angle
            //case 2: (n,0) is the right angle
            //case 3: (0,n) is the right angle
            int triangleCount = (xmax)*(ymax)*3;

            //algorithm: For every point and (0,0):
            //Get the slope(rise and run) from (0,0) to the point
            //reduce the rise/run if they have any common factors
            //swap the rise/run, and invert downwards, continuing until either y<0 or x>xmax
            for (int x = 1; x<=xmax; x++)
            {
                for(int y = 1; y <= ymax; y++)
                {
                    triangleCount += GetTriangleCount(xmax, ymax, x, y);
                }
            }
            return triangleCount;
        }
        private static int GetTriangleCount(int xmax, int ymax, int x, int y)
        {
            int triangleCount = 0;
            //Get the slope(rise and run) from (0,0) to the point
            int rise = y;
            int run = x;
            //reduce the rise/run if they have any common factors
            int GCF = MathPlus.GCF(x,y);
            rise/=GCF; 
            run/=GCF;
            //swap the rise/run, and invert downwards, continuing until either y<0 or x>xmax

            //count triangles where the 3rd point is to the right of the 2nd
            int currX = x + rise;
            int currY = y - run;
            while (currX <= xmax && currY >= 0)
            {
                //Console.WriteLine("(0,0) ("+x+","+y+") ("+currX+","+currY+")");
                triangleCount++;
                currX += rise;
                currY -= run;
            }
            //count triangles where the 3rd point is to the left of the 2nd
            currX = x - rise;
            currY = y + run;
            while (currY <= ymax && currX >= 0)
            {
                //Console.WriteLine("(0,0) (" + x + "," + y + ") (" + currX + "," + currY + ")");
                triangleCount++;
                currX -= rise;
                currY += run;
            }
            return triangleCount;
        }
    }
}
