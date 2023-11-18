// See https://aka.ms/new-console-template for more information
using ProjectEulerSolutions;

string solution = "";
int solutionInt = -1;
do { 
    Console.WriteLine("Enter your solution below (-1 to exit):");
    try
    {
        solution = Console.ReadLine();
        solutionInt = Convert.ToInt32(solution);
    }
    catch
    {
        Console.WriteLine("Cannot convert to integer");
    }
}while(solutionInt < 0);

SolutionManager.RunSolution(solutionInt);
Console.WriteLine("Completed");
Console.ReadLine();