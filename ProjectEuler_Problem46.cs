using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
	class Program
	{
		static int limit = 10000;
		static bool[] primesList = new bool[limit];
		static int[] primesValues = new int[limit / 2];

		static bool IsNumberPrime(int i)
		{
			if (i == 2 || i == 3 || i == 5)
				return true;
			if (i % 2 == 0 || i % 3 == 0 || i % 5 == 0)
				return false;

			int limit = (int)Math.Sqrt(i);

			for (int j = 7; j <= limit; j += 2)
				if (i % j == 0)
					return false;

			return true;
		}

		static bool TestGoldbachNumber(int i)
		{
			int primeIndex = 1;
			int squareValue = 0;
			int sum = 0;

			if (primesList[i])
				return true;
	
			while (true)
			{
				squareValue = 0;
				sum = 0;

				while (sum < i)
				{
					squareValue++;
					sum = 2 * squareValue * squareValue + primesValues[primeIndex];
				}

				if (sum == i)
					return true;
				
				if (primesValues[primeIndex] > i)
					return false;

				primeIndex++;
			}
		}

		static void Main(string[] args)
		{
			int index = 0;
			int currentNumber = 5;

			for (int i = 2; i < limit; i++)
				if (IsNumberPrime(i))
				{
					primesList[i] = true;
					primesValues[index] = i;
					index++;
				}

			while (currentNumber < limit)
			{
				if (!TestGoldbachNumber(currentNumber))
				{
					System.Console.WriteLine(currentNumber);
					break;
				}

				currentNumber += 2;
			}
			
			System.Console.ReadKey(true);
		}
	}
}
