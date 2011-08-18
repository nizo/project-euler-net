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

		static string ProcessString(string s, string password)
		{
			int currentIndex = 0;
			string result = "";

			foreach (char c in s)
			{
				char currentChar = Convert.ToChar(Convert.ToByte(c) ^ password[currentIndex]);								
				result += char.ToString(currentChar);

				currentIndex = (currentIndex + 1) % 3;
			}			

			return result;
		}

		static string UpdatePassword(string s)
		{
			char firstChar = s[0];
			char middleChar = s[1];
			char lastChar = s[2];

			if (lastChar == 'z' && middleChar == 'z')
			{
				lastChar = 'a';
				middleChar = 'a';
				firstChar++;

				if (firstChar == '{')
					return "x";
			}
			else if (lastChar == 'z')
			{
				lastChar = 'a';
				middleChar++;

				if (middleChar == '{')
				{
					firstChar++;
					middleChar = 'a';
				}
			}
			else
				lastChar++;

			return char.ToString(firstChar) + char.ToString(middleChar) + char.ToString(lastChar);				
		}

		static List<float> GetStatistics(string s)
		{
			List<float> result = new List<float>();
			float aOccurence = 0f;
			float eOccurence = 0f;
			float tOccurence = 0f;

			for (int i = 0; i < s.Length; i++)
			{

				switch (s.Substring(i, 1))
				{
					case "a":
						{
							aOccurence++;
							break;
						}
					case "e":
						{
							eOccurence++;
							break;
						}
					case "t":
						{
							tOccurence++;
							break;
						}
				}				
			}

			result.Add(aOccurence / s.Length);
			result.Add(eOccurence / s.Length);
			result.Add(tOccurence / s.Length);

			return result;
		}

		static bool IsStringCandidate(List<float> occurences)
		{
			return (occurences[0] > 0.04f && occurences[0] < 0.1f && occurences[1] > 0.09f && occurences[1] < 0.2f && occurences[2] > 0.05f && occurences[2] < 0.3f);
		}

		static int GetASCIISum(string s)
		{
			int result = 0;

			for (int i = 0; i < s.Length; i++)			
				result += s[i];

			return result;
		}

		static void Main(string[] args)
		{
			StartingProcedures();
			
			bool resultFound = false;
			string currentPassword = "aaa";
			string unformattedString = "";
			string inputString = "";
			string currentString = "";
			List<float> occurences = new List<float>();
			const string inputFile = "cipher1.txt";
			
			using (StreamReader streamReader = new StreamReader(inputFile))
			{
				unformattedString += streamReader.ReadLine();
				streamReader.Close();
			}
			
			string localString = "";			
			
			for (int i = 0; i < unformattedString.Length; i++)
			{
				if (unformattedString.Substring(i, 1) == ",")
				{
					inputString += char.ToString((char)(int.Parse(localString)));
					localString = "";
				}
				else
					localString += unformattedString.Substring(i, 1);
			}

			inputString += char.ToString((char)(int.Parse(localString)));


			while (!resultFound)
			{
				currentString = ProcessString(inputString, currentPassword);
				occurences = GetStatistics(currentString);

				if (IsStringCandidate(occurences))
				{
					System.Console.WriteLine(currentString);
					string consoleInput = Console.ReadLine();

					if (consoleInput == "a")
					{
						System.Console.WriteLine("Sum of chars is " + GetASCIISum(currentString));
						resultFound = true;
					}
					else
						System.Console.WriteLine("");

				}

				currentPassword = UpdatePassword(currentPassword);
				if (currentPassword == "x")
				{
					System.Console.WriteLine("FAIL");
					resultFound = true;
				}
			}			

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
