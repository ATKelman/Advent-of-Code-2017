using System;
using System.IO;

namespace Day_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PerformOperation(true));
            Console.WriteLine(PerformOperation(false));

            Console.ReadKey();
        }

        static int PerformOperation(bool answer)
        {
            var input = File.ReadAllText("input.txt").Split(',');
            int x = 0, y = 0, maxSteps = 0;

            foreach (var cmd in input)
            {
                switch (cmd)
                {
                    case "n":
                        y += 2;
                        break;
                    case "ne":
                        y++;
                        x++;
                        break;
                    case "se":
                        y--;
                        x++;
                        break;
                    case "s":
                        y -= 2;
                        break;
                    case "sw":
                        y--;
                        x--;
                        break;
                    case "nw":
                        y++;
                        x--;
                        break;
                    default:
                        Console.WriteLine("ERROR : Invalid Instruction - " + cmd);
                        break;
                }

                if (CalculateSteps(x, y) > maxSteps)
                    maxSteps = CalculateSteps(x, y);
            }
            if (answer)
                return CalculateSteps(x, y);
            else
                return maxSteps;
        }

        static int CalculateSteps(int x, int y)
        {
            return (Math.Abs(x) + ((Math.Abs(y) - Math.Abs(x)) / 2));
        }
    }
}
