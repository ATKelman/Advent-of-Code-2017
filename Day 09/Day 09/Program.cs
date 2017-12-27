using System;
using System.IO;

namespace Day_09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetCount(true));
            Console.WriteLine(GetCount(false));

            Console.ReadKey();
        }

        static int GetCount(bool answer)
        {
            var input = File.ReadAllText("input.txt");

            var groupCount = 0;
            var score = 0;
            var garbageCount = 0;

            var isGarbage = false;
            var shouldSkip = false;

            foreach(char c in input)
            {
                if(shouldSkip)
                {
                    shouldSkip = false;
                    continue;
                }
                if(c == '!')
                {
                    shouldSkip = true;
                    continue;
                }

                if(c == '<')
                {
                    if(!isGarbage)
                    {
                        isGarbage = true;
                        continue;
                    }
                }
                else if(c== '>')
                {
                    isGarbage = false;
                    continue;
                }

                if(c == '{' && !isGarbage)
                {
                    groupCount++;
                }
                if(c =='}' && !isGarbage)
                {
                    score += groupCount;
                    groupCount--;
                }

                if(isGarbage)
                    garbageCount++;
            }

            if (answer)
                return score;
            else
                return garbageCount;
        }
    }
}
