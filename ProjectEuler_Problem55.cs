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
		public static Stopwatch sw;

		static bool IsPalindrome(string s)
		{
			for (int i = 0; i < s.Length / 2; i++)			
				if (s[i] != s[s.Length - i - 1])
					return false;

			return true;
		}

		static BigInteger ReverseNumber(string i)
		{
			char[] charArray = i.ToCharArray();
			Array.Reverse(charArray);

			
			return new BigInteger((new string(charArray)), 10);
		}
		
		static bool IsNumberLychrel(BigInteger candidate)
		{
			for (int i = 1; i < 50; i++)
			{
				candidate += ReverseNumber(candidate.ToString());
				if (IsPalindrome(candidate.ToString()))									
					return false;				
			}
			
			return true;
		}


		static void Main(string[] args)
		{
			StartingProcedures();
			int counter = 0;

			for (int i = 1; i < 10000; i++)
				if (IsNumberLychrel(i))
					counter++;			

			System.Console.WriteLine("There are " + counter.ToString() + " such numbers!");
			
			ClosingProcedures();
		}

		#region HelpMethods

		static void StartingProcedures()
		{
			sw = new Stopwatch();
			sw.Start();
		}

		static void ClosingProcedures()
		{
			sw.Stop();
			Console.WriteLine(sw.Elapsed);
			Console.ReadLine();
		}

		#endregion

	}
}
