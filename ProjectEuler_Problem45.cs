using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
	class Program
	{
		static bool IsNumberHexagonal(long i)
		{
			if (((Math.Sqrt(8 * i + 1)) + 1) / 4 % 1 == 0)
				return true;

			return false;
		}

		static bool IsNumberPentagonal(long i)
		{
			if (((Math.Sqrt(24 * i + 1)) + 1) / 6 % 1 == 0)
				return true;

			return false;
		}

		static bool IsNumberTriangle(long i)
		{			
			if (((Math.Sqrt(8 * i + 1)) - 1) / 2 % 1 == 0)
				return true;

			return false;
		}

		static void Main(string[] args)
		{
			long increment = 500000;

			while (increment < int.MaxValue)
			{
				if (IsNumberHexagonal(increment) && IsNumberPentagonal(increment) && IsNumberTriangle(increment))
				{
					System.Console.Out.WriteLine(increment);					
					break;
				}
				increment++;
			}
			
			System.Console.ReadKey(true);
		}
	}
}
