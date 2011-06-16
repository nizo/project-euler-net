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
		static List<string> namesList = new List<string>();
		static int result = 0;

		static void ParseNames(string s)
		{
			int index = 1;
			int counter = 0;
			string localString = "";

			while (index < s.Length)
			{
				while (s[index].ToString() != "\"")
				{
					localString += s[index];
					index++;
				}

				namesList.Add(localString);
				localString = "";

				index += 3;
				counter++;
			}
		}

		static void RateNamesList()
		{
			int localResult = 0; ;
			int coefficient = 1;
			string alphabet = "abcdefghijklmnopqrstuvwxyz".ToUpper();
			
			foreach(string name in namesList)
			{
				for (int i = 0; i < name.Length; i++)
					localResult += alphabet.IndexOf(name[i]) + 1;				
			
				result += localResult * coefficient;
				coefficient++;
				localResult = 0;				
			}
		}

		static void Main(string[] args)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			string line = "";			

			const string inputFile = "names.txt";

			using (StreamReader streamReader = new StreamReader(inputFile))
			{
				line = streamReader.ReadLine();				
				streamReader.Close();
			}

			ParseNames(line);
			namesList.Sort();
			RateNamesList();

			System.Console.WriteLine("Total score is " + result);

			stopwatch.Stop();
			System.Console.WriteLine("Calculation lasted for " + stopwatch.Elapsed);
			System.Console.ReadKey(true);
		}
	}
}





