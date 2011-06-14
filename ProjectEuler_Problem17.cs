using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler_01
{
    class Program
	{

		#region Helpers

		static bool IsNumberPalindrome(int candidate)
		{
			string stringCandidate = candidate.ToString();

			for (int i = 0; i < stringCandidate.Length / 2; i++)
			{
				if (stringCandidate[i] != stringCandidate[stringCandidate.Length - 1 - i])
					return false;
			}	
			return true;
		}

		static bool IsNumberPrime(int candidate)
		{
			if (candidate == 2 || candidate == 3 || candidate == 5 || candidate == 7) return true;
			if (candidate % 2 == 0 || candidate % 3 == 0 || candidate % 5 == 0 || candidate % 7 == 0) return false;
			int limit = (int)Math.Sqrt(candidate);
			for (int i = 2; i <= limit; i++)
			{
				if (candidate % i == 0)
					return false;
			}

			return true;
		}

		static int GetNumberOfDivisors(int i)
		{
			int divisorsCount = 0;
			int limit = (int)Math.Sqrt(i);

			for (int j = 2; j <= limit; j++)
			{
				if (i % j == 0)
					divisorsCount++;
			}
			return divisorsCount * 2 + 2;
		}

		static void ReadFile(out string[] input)
		{
			int counter = 0;
			string line;
			input = new string[100];
			System.IO.StreamReader file = new System.IO.StreamReader("c:\\numbers.txt");
			while ((line = file.ReadLine()) != null)
			{
				input[counter] = line;
				counter++;
			}
			file.Close();
		}

		public static double factorial(double n)
		{
			if (n == 1)
				return n;
			return n * factorial(n - 1);
		}

#endregion

		static void Main(string[] args)
		{
			long result = 0;

			int hundred = 7;
			int and = 3;

			int one = 3;
			int two = 3;
			int three = 5;
			int four = 4;
			int five = 4;
			int six = 3;
			int seven = 5;
			int eight = 5;
			int nine = 4;
			
			int ten = 3;
			int eleven = 6;
			int twelve = 6;
			int thirteen = 8;
			int fourteen = 8;
			int fifteen = 7;
			int sixteen = 7;
			int seventeen = 9;
			int eighteen = 8;
			int nineteen = 8;

			int rest = 46;
		
			result += 11; //one thousand
			
			result += (100+9*10) * (one + two + three+ four + five + six + seven + eight + nine);

			result += 10 * (ten + eleven + twelve + thirteen + fourteen + fifteen + + sixteen + seventeen + eighteen + nineteen);
			result += 10 * rest + 10 * 9 * rest;

			result += 900 * hundred;
			result += 9 * 99 * and;


			System.Console.WriteLine(result);
			System.Console.ReadKey(true);			
		}		
    }
}


