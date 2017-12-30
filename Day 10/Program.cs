using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_10
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

        static string PartTwo()
        {
            var input = File.ReadAllBytes("input.txt");
            var inputExtraBytes = File.ReadAllText("input_2.txt").Split(',').Select(byte.Parse).ToArray();

            var newArray = new byte[input.Length + inputExtraBytes.Length];
            input.CopyTo(newArray, 0);
            inputExtraBytes.CopyTo(newArray, input.Length);

            int skips = 0, index = 0;
            var list = Enumerable.Range(0, 256).ToArray();

            for (int i = 0; i < 64; i++)
                RunOperation(newArray, ref list, ref skips, ref index);

            var denseHash = new int[(256 / 16)];

            for(int i = 0; i < denseHash.Length; i++)
            {
                var subset = new int[16];
                for(int j = 0; j < 16; j++)
                    subset[j] = list[(i * 16) + j];

                denseHash[i] = subset[0];
                for(int j = 1; j< 16; j++)
                    denseHash[i] ^= subset[j];
            }

            var answerString = "";
            foreach(var hex in denseHash)
            {
                answerString += String.Format("{0:X}", hex);
            }


            return answerString;
        }

        static void RunOperation(byte[] instructions, ref int[] list, ref int skips, ref int index)
        {
            foreach (var input in instructions)
            {
                var subList = new int[input];

                // Reverse the numbers 
                for (int i = 0; i < input; i++)
                {
                    subList[i] = list[(i + index) % 256];
                }

                subList = subList.Reverse().ToArray();

                for (int i = 0; i < input; i++)
                    list[(i + index) % 256] = subList[i];

                // Increase position
                index = (input + index + skips) % 256;
                skips++;
            }
        }
    }
}
