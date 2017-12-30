using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_02
{
    class Program
    {
		static void Main(string[] args)
		{
			var answer = CalculateCheckSum();
			Console.WriteLine(answer);

			var answer2 = CalculateDivisbleSum();
			Console.WriteLine(answer2);

			Console.ReadKey();
		}

		static int CalculateCheckSum()
		{
			var answer = 0;

			using (StreamReader reader = new StreamReader("Day 02 input.txt"))
			{
				string line;

				while ((line = reader.ReadLine()) != null)
				{
					var largestNumber = 0;
					var smallestNumber = 9999;
					var numbers = line.Split('\t');
					foreach (var number in numbers)
					{
						if (Convert.ToInt32(number) < smallestNumber)
							smallestNumber = Convert.ToInt32(number);
						if (Convert.ToInt32(number) > largestNumber)
							largestNumber = Convert.ToInt32(number);
					}
					answer += (largestNumber - smallestNumber);
				}
			}
			return answer;
		}

		static int CalculateDivisbleSum()
		{
			var answer = 0;
			using (StreamReader reader = new StreamReader("Day 02 input.txt"))
			{
				string line;

				while ((line = reader.ReadLine()) != null)
				{

					var numbers = line.Split('\t');
					foreach (var number1 in numbers)
					{
						foreach (var number2 in numbers)
						{
							if (number1 != number2)
							{
								if ((Convert.ToInt32(number1) % Convert.ToInt32(number2)) == 0 && Convert.ToInt32(number1) > Convert.ToInt32(number2))
								{
									answer += (Convert.ToInt32(number1) / Convert.ToInt32(number2));
								}
							}
						}
					}
				}
			}
			return answer;
		}
	}
}
