using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace AdventOfCode
{
    internal class DayTwo
    {
        public static void StartProblem()
        {
            string text = File.ReadAllText(@"..\..\input2.txt");
            string[] intStrings = text.Split(',');

            int[] myInts = Array.ConvertAll(intStrings, int.Parse);

            myInts[1] = 12;
            myInts[2] = 2;
            for(int i = 0; i < myInts.Count() - 3; i += 4)
            {
                Console.WriteLine("Iteration {0}, Position {1}, Command {2}, Operand One : {3}, Operand Two : {4}", i / 4 + 1, i, myInts[i], myInts[i + 1], myInts[i + 2]);
                if(myInts[i] == 1)
                {
                    myInts[myInts[i + 3]] = myInts[myInts[i + 1]] + myInts[myInts[i + 2]];
                } else if(myInts[i] == 2)
                {
                    myInts[myInts[i + 3]] = myInts[myInts[i + 1]] * myInts[myInts[i + 2]];
                } else if(myInts[i] == 99)
                {
                    break;
                } else
                {
                    Console.WriteLine("Bad command value, did not find 0 or 1 or 99 in position {0}", i);
                    throw new Exception();
                }
            }

            Console.WriteLine("New Position 0 intcode : {0}", myInts[0]);
        }
    }
}