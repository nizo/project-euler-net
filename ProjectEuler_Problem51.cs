using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ConsoleApplication1
{
	class Program
	{
		static bool IsMultipledPalindrome(int originalNumber, int multipleFactor)
		{			
			string originalInString = originalNumber.ToString();
			string multipledInString = (originalNumber * multipleFactor).ToString();
			bool[] usedDigits = new bool[originalInString.Length];

			if (originalInString.Length != multipledInString.Length || originalInString == multipledInString)
				return false;

			for (int i = 0; i < originalInString.Length; i++)
			{
				int index = originalInString.IndexOf(multipledInString.Substring(i, 1));
				if (index == -1 || usedDigits[index])
					return false;

				usedDigits[index] = true;				
			}
			return true;
		}

		static void Main(string[] args)
		{
			int currentNumber = 1;
			bool doIt = true;

			Stopwatch timer = new Stopwatch();
			timer.Start();

			while (doIt)
			{
				for (int i = 2; i <= 6; i++)
				{
					if (IsMultipledPalindrome(currentNumber, i))
					{
						if (i == 6)
						{
							System.Console.WriteLine(currentNumber);							
							doIt = false;
							break;
						}
					}
					else break;
				}					
				currentNumber++;
			}
			timer.Stop();
			System.Console.WriteLine(timer.Elapsed);
			System.Console.ReadKey(true);
		}						
	}
}
