using System;
using System.IO;
using System.Linq;

namespace Day_13
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
            var input = File.ReadAllLines("input.txt").Select(x => new Security(x)).ToList();
            var severity = 0;

            foreach (var current in input)
            {
                if (current.IsCaught(0))
                    severity += current.depth * current.range;
            }

            return severity;
        }

        static int PartTwo()
        {
            var input = File.ReadAllLines("input.txt").Select(x => new Security(x)).ToList();
            var delays = 0;
            var caught = true;

            while(caught)
            {
                caught = false;
                foreach (var current in input)
                {
                    if (current.IsCaught(delays))
                    {
                        caught = true;
                        break;
                    }                       
                }
                if(caught)
                    delays++;
            }

            return delays;
        }
        
        public class Security
        {
            public int depth;
            public int range;

            public Security(string input)
            {
                var words = input.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                depth = int.Parse(words[0]);
                range = int.Parse(words[1]);
            }

            public bool IsCaught(int delay)
            {
                return ((depth + delay) % ((range - 1) * 2) == 0);
            }           
        }
    }
}
