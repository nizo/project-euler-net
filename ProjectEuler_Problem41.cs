using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
	class Program
	{
		static int maximum = 0;
		static int maximumCurrentLength = 9;	

		static bool IsNumberPrime(int i)
		{
			if (i == 2 || i == 3 || i == 5)
				return true;
			if (i % 2 == 0 || i % 3 == 0 || i % 5 == 0)
				return false;

			int limit = (int)Math.Sqrt(i);

			for (int j = 7; j < limit; j += 2)
				if (i % j == 0)
					return false;

			return true;
		}

		static void GetHighestPandigitalNumber(string number, int length)
		{
			if (length == maximumCurrentLength)
			{
				int candidate = int.Parse(number);				
				if (IsNumberPrime(candidate) && (candidate > maximum))
					maximum = candidate;					
			}
			else for (int i = 1; i <= maximumCurrentLength; i++)
			{
				if (!number.Contains(i.ToString()))
					GetHighestPandigitalNumber(number + i.ToString(), length + 1);
			}
		}

		static void Main(string[] args)
		{
			bool stop = false;

			while (!stop)
			{
				GetHighestPandigitalNumber("", 0);
				maximumCurrentLength--;
				if (maximumCurrentLength == 0)
					stop = true;
			}

			System.Console.WriteLine("Maximum such number is " + maximum);
			System.Console.ReadKey(true);
		}
	}
}