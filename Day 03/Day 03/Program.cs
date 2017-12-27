using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PartOne(277678));
            Console.ReadKey();
        }

        static int PartOne(int input)
        {
            //var bottomRight = 4 * (Math.Pow(layer, 2)) + (4 * layer) + 1;
            //var bottomLeft  = 4 * (Math.Pow(layer, 2)) + (2 * layer) + 1;

            var layer = Math.Ceiling(0.5 * (Math.Sqrt(input) - 1));
            var distance = layer + Math.Abs((input - 1) % (2 * layer) - layer);

            return (int)distance;
        }      
    }
}
