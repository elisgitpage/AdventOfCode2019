using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode
{
    class DayOne
    {
        public static void StartProblem()
        {
            string text = File.ReadAllText(@"..\..\input.txt");
            string[] modules = text.Split('\n');

            int[] modMasses= new int[modules.Count()];
            if (modMasses.Count() != modules.Count()) throw new Exception();

            int tempFuelCalc, tempMass, totalFuelReq;
            totalFuelReq = 0;

            for (int i = 0; i < modules.Count(); i++) 
            {
                tempFuelCalc = 0;
                tempMass = 0;
                int.TryParse(modules[i], out tempMass);
                if(tempMass == 0 || tempMass.Equals(null))
                {
                    Console.WriteLine("Module {0} : Bad Input, Skipped.");
                    continue;
                }

                tempFuelCalc = CalculateFuel(tempMass);
                totalFuelReq += tempFuelCalc;

                Console.WriteLine("Module {0} : TempMass {1} : TempFuelCalc {2} : Running Total of Fuel Req {3} ", i, tempMass, tempFuelCalc, totalFuelReq);
            }

            Console.WriteLine("Day 1 : Fuel requirement for all modules is {0}", totalFuelReq);
        }

        private static int CalculateFuel(int tempMass)
        {
            double result = (double)tempMass;
            result = result / 3;
            int resultint = (int)result;
            resultint -= 2;
            return resultint;
        }
    }
}