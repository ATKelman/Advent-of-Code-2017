using System;
using System.IO;
using System.Linq;

namespace Day_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PartOne());

            Console.ReadKey();
        }

        static int PartOne()
        {
            var input = File.ReadAllText("input.txt").Split(',').Select(int.Parse).ToList();
            var list = Enumerable.Range(0, 256).ToArray();
            int skips = 0, index = 0;

            foreach(var instruction in input)
            {
                var subList = new int[instruction];

                // Reverse the numbers 
                for (int i = 0; i < instruction; i++)
                {
                    subList[i] = list[(i + index) % 256];
                }


                subList = subList.Reverse().ToArray();

                for (int i = 0; i < instruction; i++)
                    list[(i + index) % 256] = subList[i];

                // Increase position
                index = (instruction + index + skips) % 256;
                skips++;
            }

            var answer = list[0] * list[1];

            return answer;
        }
    }
}
