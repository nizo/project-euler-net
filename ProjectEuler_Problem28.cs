using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ProjectEuler_01
{
	class Program
	{
		static void Main(string[] args)
		{
			int lengthOfGrid = 1001;

			int currentNumber = lengthOfGrid * lengthOfGrid;
			int gridLength = lengthOfGrid - 1;
			int modulatedCounter = 0;
			int totalSum = 0;

			while (currentNumber != 1)
			{
				if (modulatedCounter == 4)
				{
					modulatedCounter = 0;
					gridLength -= 2;
				}
				modulatedCounter++;

				totalSum += currentNumber;
				currentNumber -= gridLength;
			}

			totalSum++;
			System.Console.WriteLine(totalSum);
			System.Console.ReadKey(true);
		}
	}
}





