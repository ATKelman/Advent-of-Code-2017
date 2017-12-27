using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_04
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
            int validPhrases = 0;
            using (StreamReader reader = new StreamReader("input.txt"))
            {           
                while(!reader.EndOfStream)
                {
                    List<string> words = new List<string>();
                    var phrases = reader.ReadLine().Split(' ');

                    bool isValid = true;

                    foreach(var phrase in phrases)
                    {
                        if (words.Contains(phrase))
                        {
                            isValid = false;
                            break;
                        }
                        else
                            words.Add(phrase);
                    }
                    if (isValid)
                        validPhrases++;
                }
            }
            return validPhrases;
        }

        static int PartTwo()
        {
            var lines = File.ReadAllLines("input.txt");

            var result = lines.Count(x => x.Split(' ')
            .Select(y => String.Concat(y.OrderBy(z => z)))
            .Distinct().Count() == x.Split(' ').Count());

            return result;
        }
    }
}
