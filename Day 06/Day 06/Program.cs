using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_06
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
            var numbers = File.ReadAllLines("input.txt").FirstOrDefault().Split('\t').Select(int.Parse).ToList();

            var set = new HashSet<string>
            {
                string.Join(" ", numbers)
            };

            while(true)
            {
                var max = numbers.Max();
                var maxIndex = numbers.IndexOf(max);
                var toDistribute = numbers[maxIndex];

                numbers[maxIndex] = 0;

                while(toDistribute > 0)
                {
                    maxIndex = (maxIndex + 1) % numbers.Count;
                    numbers[maxIndex]++;
                    toDistribute--;
                }

                if(!set.Add(string.Join(" ", numbers)))
                    return set.Count;

            }
        }

        static int PartTwo()
        {
            var numbers = File.ReadAllLines("input.txt").FirstOrDefault().Split('\t').Select(int.Parse).ToList();

            var set = new HashSet<string>
            {
                string.Join(" ", numbers)
            };

            bool firstTime = true;

            while (true)
            {
                var max = numbers.Max();
                var maxIndex = numbers.IndexOf(max);
                var toDistribute = numbers[maxIndex];

                numbers[maxIndex] = 0;

                while (toDistribute > 0)
                {
                    maxIndex = (maxIndex + 1) % numbers.Count;
                    numbers[maxIndex]++;
                    toDistribute--;
                }

                if (!set.Add(string.Join(" ", numbers)))
                {
                    if (firstTime)
                    {
                        set = new HashSet<string>
                            {
                                string.Join(" ", numbers)
                            };
                        set.Add(string.Join(" ", numbers));
                        firstTime = false;
                    }
                    else
                        return set.Count;
                }
            }
        }
    }
}
