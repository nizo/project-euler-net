using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEuler_01
{
	class Program
	{
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

		static Dictionary<string, int> primesHashes;
		static List<int> primes;

		static void ParsePrimeNumber(int index, string originalNumber, int avatar)
		{			
			if (index == -1)
			{											
				if (primesHashes.ContainsKey(originalNumber))
					primesHashes[originalNumber]++;
				else
					primesHashes.Add(originalNumber, 1);

				return;
			}

			string alternativeNumber = originalNumber;

			for (int i = index; i < originalNumber.Length; i++)
			{
				if (i == originalNumber.Length - 1)
				{
					if (originalNumber.Substring(i, 1) == "x")
					{
						alternativeNumber = originalNumber.Substring(0, i) + avatar.ToString() + originalNumber.Substring(i + 1, originalNumber.Length - i - 1);
						ParsePrimeNumber(-1, alternativeNumber, avatar);
					}

					ParsePrimeNumber(-1, originalNumber, avatar);
					
					return;
				}
				else if (originalNumber.Substring(i, 1) == "x")
				{
					alternativeNumber = originalNumber.Substring(0, i) + avatar.ToString() + originalNumber.Substring(i + 1, originalNumber.Length - i - 1);

					ParsePrimeNumber(i + 1, originalNumber, avatar);
					ParsePrimeNumber(i + 1, alternativeNumber, avatar);

					return;
				}
			}
		}

		static bool IsNumberWorthChecking(string number)
		{
			int count = 0;
			for (int i = 0; i < number.Length; i++)
				if (number.Substring(i, 1) == "x")
					count++;

			return count > 1;
		}

		static void Main(string[] args)
		{
			int limit = 100000;
			int currentNumber = 10001;			
			bool found = false;
			string result = "";
			string hash = "";
			string alteredHash = "";
			List<bool> checkedList = new List<bool>();
			
			primesHashes = new Dictionary<string, int>();
			primes = new List<int>();

			while (!found)
			{				
				while (currentNumber < limit)
				{
					if (IsNumberPrime(currentNumber))
						primes.Add(currentNumber);

					currentNumber += 2;
				}				

				foreach (int i in primes)
				{
					hash = i.ToString();
					alteredHash = hash;

					checkedList.Clear();

					for (int f = 0; f < i.ToString().Length; f++)					
						checkedList.Add(false);

					for (int j = 0; j < hash.Length - 1; j++)
					{
						if (checkedList[j])
							continue;

						if (j == 0)						
							alteredHash = "x" + hash.Substring(1, hash.Length - 1);						
						else
							alteredHash = hash.Substring(0, j) + "x" + hash.Substring(j + 1, hash.Length - j - 1);

						for (int z = j + 1; z < hash.Length; z++)
						{
							if (hash[j] == hash[z])
							{
								checkedList[z] = true;
								alteredHash = alteredHash.Substring(0, z) + "x" + alteredHash.Substring(z + 1, alteredHash.Length - z - 1);
							}
						}

						if (IsNumberWorthChecking(alteredHash))
							ParsePrimeNumber(j + 1, alteredHash, int.Parse(hash.Substring(j, 1)));
						
						alteredHash = alteredHash.Substring(0, j) + hash.Substring(j, 1) + alteredHash.Substring(j + 1, alteredHash.Length - j - 1);

						if (IsNumberWorthChecking(alteredHash))
							ParsePrimeNumber(j + 1, alteredHash, int.Parse(hash.Substring(j, 1)));
					}
				}

				foreach (KeyValuePair<string, int> entry in primesHashes)
				{
					if (entry.Value == 8)
					{
						result = entry.Key;
						found = true;
						break;
					}
				}

				primesHashes.Clear();
				primes.Clear();
				limit *= 10;
				Console.WriteLine("--- INCREASING LIMIT ---");
			}			

			while (true)
			{
				if (IsNumberPrime(System.Convert.ToInt32(result.Replace('x', '0'))))
				{
					result = result.Replace('x', '0');
					break;
				}
				if (IsNumberPrime(System.Convert.ToInt32(result.Replace('x', '1'))))
				{
					result = result.Replace('x', '1');
					break;
				}
				if (IsNumberPrime(System.Convert.ToInt32(result.Replace('x', '2'))))
				{
					result = result.Replace('x', '2');
					break;
				}
			}

			Console.WriteLine("Result is " + result);
			Console.ReadLine();
		}
	}
}
