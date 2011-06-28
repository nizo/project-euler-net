using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
	class Program
	{
		static int limit = 50000;

		static Dictionary<long, int> pentagonalNumbersDictionary = new Dictionary<long, int>();
		static List<long> pentagonalNumbersList = new List<long>();

		static void Main(string[] args)
		{
			long minimum = int.MaxValue;

			for (int i = 0; i < limit; i++)
			{
				long number = (i * (3 * i - 1) / 2);
				pentagonalNumbersDictionary.Add(number, (int)i);
				pentagonalNumbersList.Add(number);
			}


			for (int i = 1; i < limit; i++)
				for (int j = i; j < limit; j++)
					if (pentagonalNumbersDictionary.ContainsKey(Math.Abs(pentagonalNumbersList[i] - pentagonalNumbersList[j])))
						if (pentagonalNumbersDictionary.ContainsKey(pentagonalNumbersList[i] + pentagonalNumbersList[j]))
							if (Math.Abs(pentagonalNumbersList[i] - pentagonalNumbersList[j]) < minimum && i != j)
								minimum = Math.Abs(pentagonalNumbersList[i] - pentagonalNumbersList[j]);

			System.Console.WriteLine("Minimalised difference is " + minimum);
			System.Console.ReadKey(true);
		}
	}
}