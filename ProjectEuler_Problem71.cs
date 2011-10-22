using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEuler_01
{
	class Program
	{
		static void Main(string[] args)
		{
			int nominatorA = 0;
			int denominatorA = 1;

			int nominatorB = 1;
			int denominatorB = 2;						

			int nominatorC = 1;
			int denominatorC = 1;

			double neighbour = 3.0 / 7.0;

			while (true)
			{
				if (neighbour > (double)nominatorB / (double)denominatorB)
				{
					if (denominatorC + denominatorB > 1000000)
						break;

					nominatorA = nominatorB;
					denominatorA = denominatorB;

					nominatorB = nominatorA + nominatorC;
					denominatorB = denominatorA + denominatorC;
				}
				else
				{

					if (denominatorA + denominatorB > 1000000)
						break;

					nominatorC = nominatorB;
					denominatorC = denominatorB;
					
					nominatorB = nominatorA + nominatorC;
					denominatorB = denominatorA + denominatorC;
				}
			}

			Console.WriteLine("Result is " + nominatorB + " with denominator " + denominatorB);
			Console.ReadLine();
		}
	}
}
