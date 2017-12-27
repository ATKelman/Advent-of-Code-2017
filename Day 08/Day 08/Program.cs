using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(greatestValueEver);

            Console.ReadKey();
        }

        static Dictionary<string, int> dictionary;
        static int greatestValueEver;

        static int PartOne()
        {
            var input = File.ReadAllLines("input.txt");
            dictionary = new Dictionary<string, int>();

            foreach(var line in input)
            {
                if(CheckCondition(line))
                {
                    PerformInstruction(line);
                }
            }

            var greatestValue = dictionary.OrderByDescending(x => x.Value).First();

            return greatestValue.Value;
        }

        static bool CheckCondition(string cmd)
        {
            var words = cmd.Split(' ');

            if(!dictionary.ContainsKey(words[4]))
            {
                dictionary.Add(words[4], 0);
            }

            var value1 = dictionary[words[4]];
            var value2 = Convert.ToInt32(words[6]);
            var operand = words[5];

            switch(operand)
            {
                case ">":
                    return value1 > value2;
                case "<":
                    return value1 < value2;
                case "==":
                    return value1 == value2;
                case "!=":
                    return value1 != value2;
                case ">=":
                    return value1 >= value2;
                case "<=":
                    return value1 <= value2;
                default:
                    Console.WriteLine("Error no operand found : " + cmd);
                    break;
            }

            return false; 
        }

        static void PerformInstruction(string cmd)
        {
            var words = cmd.Split(' ');

            if(!dictionary.ContainsKey(words[0]))
            {
                dictionary.Add(words[0], 0);
            }

            var amount = Convert.ToInt32(words[2]);
            if(words[1].Equals("inc"))
            {
                dictionary[words[0]] += amount;
            }
            else if(words[1].Equals("dec"))
            {
                dictionary[words[0]] -= amount;
            }
            else
            {
                Console.WriteLine("Neither 'inc' or 'dec' : " + cmd);
            }

            if (dictionary[words[0]] > greatestValueEver)
                greatestValueEver = dictionary[words[0]];
        }
    }
}
