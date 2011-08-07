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
		
		static void GetNthIteration(BigInteger n, out BigInteger numerator, out BigInteger denominator)
		{						
			bool firstTime = true;			

			BigInteger holder = 2;
			denominator = 2;
			numerator = 2;

			while (n > 0)
			{
				if (firstTime)
				{
					numerator = 0;
					denominator = 2;					
					firstTime = false;
				}
				else
				{
					holder = denominator;
					denominator = numerator;
					numerator = holder;
					holder = 2;
				}

				holder *= denominator;
				numerator = numerator + holder;

				n--;			
			}

			while (numerator % 2 == 0 && denominator % 2 == 0)							
			{
				numerator /= 2;
				denominator /= 2;
			}	

			numerator -= denominator;
		}

		static void Main(string[] args)
		{
			StartingProcedures();
			int counter = 0;
			BigInteger numerator = 0;
			BigInteger denominator = 0;


			for (int i = 1; i <= 1000; i++)
			{
				numerator = 1;
				denominator = 1;				


				GetNthIteration(i, out numerator, out denominator);
				if (numerator.ToString().Length > denominator.ToString().Length)				
					counter++;									
			}			

			System.Console.WriteLine("There are " + counter.ToString() + " such numbers");
			
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
