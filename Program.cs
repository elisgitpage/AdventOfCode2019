using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What day of the advent calender would you like to solve?");
            int advInt;
            int.TryParse(Console.ReadLine(), out advInt);
            switch (advInt)
            {
                default:
                    break;
                case 1:
                    DayOne.StartProblem();
                    break;
                case 2:
                    DayTwo.StartProblem();
                    break;
                case 3:
                    DayThree.StartProblem();
                    break;
            }

        }
    }
}