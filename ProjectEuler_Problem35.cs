
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
	class Program
	{
		static bool IsNumberPrime(int i)
		{
			if (i == 2 || i == 3 | i == 5)
				return true;
			if (i % 2 == 0 || i % 3 == 0 || i % 5 == 0)
				return false;

			int limit = (int)Math.Sqrt(i);
			for (int j = 3; j <= limit; j += 2)
			{
				if (i % j == 0)
					return false;
			}
			return true;
		}

		static void Main(string[] args)
		{
			int result = 1;
			int numberOfRotations = 1;
			int lengthOfCurrentPrime = 0;
			string innerNumber = "";
			bool doIt = true;

			for (int i = 3; i < 1000000; i += 2)
			{
				if (IsNumberPrime(i))
				{
					innerNumber = i.ToString();
					lengthOfCurrentPrime = (int)i.ToString().Length;
					doIt = true;

					while (doIt)
					{
						if (numberOfRotations == lengthOfCurrentPrime)
						{
							doIt = false;
							result++;
							continue;
						}

						innerNumber = innerNumber.Insert(0, innerNumber.Substring(innerNumber.Length - 1, 1)).Substring(0, lengthOfCurrentPrime);

						if (!IsNumberPrime(int.Parse(innerNumber)))
						{
							doIt = false;
							continue;
						}
						numberOfRotations++;
					}
				}
				numberOfRotations = 1;
			}

			System.Console.Out.WriteLine("There are " + result + " of these numbers below one milion");
			System.Console.ReadKey(true);
		}
	}
}