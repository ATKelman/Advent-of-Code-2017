using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_01
{
    class Program
    {
		static void Main(string[] args)
		{
			Console.WriteLine("Advent of Code Day 01");
			var result = GetSumHalfStep("12131415");
			Console.WriteLine(result);
			Console.ReadKey();
		}

		static int GetSum(string input)
		{
			var sum = 0;
			var previous = -1;
			for (int i = 0; i < input.Length + 1; i++)
			{
				var counter = i % input.Length;
				var instance = (int)Char.GetNumericValue(input[counter]);
				if (instance == previous)
				{
					sum += instance;
				}
				previous = instance;
			}

			return sum;
		}

		static int GetSumHalfStep(string input)
		{
			var sum = 0;

			for (int i = 0; i < input.Length; i++)
			{
				var comparison = (i + input.Length / 2) % input.Length;

				var valueCurrent = (int)Char.GetNumericValue(input[i]);
				var valueComparison = (int)Char.GetNumericValue(input[comparison]);
				if (valueCurrent == valueComparison)
				{
					sum += valueCurrent;
				}
			}

			return sum;
		}
	}
}
