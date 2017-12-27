using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());

            Console.ReadKey();
        }

        static int PartOne()
        {
            var jumps = File.ReadAllLines("input.txt").Select(int.Parse).ToArray();

            var currentInstruction = 0;
            var numberOfJumps = 0;
            while(currentInstruction < jumps.Length)
            {
                jumps[currentInstruction]++;
                currentInstruction += jumps[currentInstruction] - 1;
                numberOfJumps++;
            }

            return numberOfJumps;
        }

        static int PartTwo()
        {
            var jumps = File.ReadAllLines("input.txt").Select(int.Parse).ToArray();

            var currentInstruction = 0;
            var numberOfJumps = 0;
            while (currentInstruction < jumps.Length)
            {
                var update = jumps[currentInstruction] > 2 ? -1 : 1;

                var instruction = jumps[currentInstruction];
                jumps[currentInstruction] += update;
                currentInstruction += instruction;

                numberOfJumps++;
            }

            return numberOfJumps;
        }
    }
}
