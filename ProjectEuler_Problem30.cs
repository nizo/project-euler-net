using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using Oyster.Math;

namespace ProjectEuler_01
{
	class Program
	{
		static int result = 0;
		static int power = 5;
		static int limit = 0;
		static int count = 0;	

		static int GetValueOfSummedNumber(int input)
		{
			List<int> listOfDigits = new List<int>();
			string s = input.ToString();
			int localResult = 0;

			for (int i = 0; i < s.Length; i++)			
				listOfDigits.Add(int.Parse(s.Substring(i, 1)));
	
			listOfDigits.Sort();

			for (int j = listOfDigits.Count - 1; j >=0 ; j--)
			{										
				localResult += (int)Math.Pow(listOfDigits[j], power);
				if (localResult > input)
					return 0;
			}

			return (localResult == input)? localResult : 0;
		}


		static void Main(string[] args)
		{
			limit = (int)Math.Pow(9, power) * power;

			for (int i = 2; i <= limit; i++)			
				result += GetValueOfSummedNumber(i);				

			Console.WriteLine("Sum of these special numbers is " + result);
			Console.ReadLine();
		}		
	}
}