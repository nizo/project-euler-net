using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace ConsoleApplication1
{
	class Program
	{
		static long result = 0;
		static Dictionary<char, int> chars = new Dictionary<char,int>();


		static int GetValue(string s)
		{
			int value = 0;
			int localValue = 0;
			s = s.ToLower();

			for (int i = 0; i < s.Length; i++)
			{
				chars.TryGetValue(s[i], out localValue);
				value += localValue;
			}
			return value;
		}


		static void EvaluateWords(string s)
		{
			int index = 1;
			int valueOfWord = 0;
			string localString = "";

			while (index < s.Length)
			{
				while (s[index].ToString() != "\"")
				{
					localString += s[index];
					index++;
				}

				valueOfWord = GetValue(localString);

				// Inverse function of triangle function
				if (((Math.Sqrt(8*valueOfWord + 1) - 1) / 2) % 1 == 0)
					result++;

				localString = "";

				index += 3;				
			}
		}


		static void Main(string[] args)
		{
			string alphabet = "abcdefghijklmnopqrstuvwxyz";			
			const string inputFile = "words.txt";
			string line = "";

			for (int i = 1; i <= alphabet.Length; i++)
				chars.Add(alphabet[i - 1], i);

			using (StreamReader streamReader = new StreamReader(inputFile))
			{
				line = streamReader.ReadLine();
				streamReader.Close();
			}

			EvaluateWords(line);
			
			System.Console.Out.WriteLine("There are " + result + " of these words!");
			System.Console.ReadKey(true);
		}
	}
}
