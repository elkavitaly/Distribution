using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution
{
	class Exponential
	{
		private List<double> numbers;

		private Dictionary<double, int> dictionary;

		public List<double> Values { get => numbers; }

		public Dictionary<double, int> Frequency { get => dictionary; }

		public Exponential()
		{
			numbers = new List<double>();
			dictionary = new Dictionary<double, int>();
			GenerateValues();
			GetDictionary();
		}

		private void GenerateValues()
		{
			Random r = new Random();
			for (int i = 0; i < 100000; i++)
				numbers.Add(GetValue(r, 1));
			numbers.Sort();
		}

		private double GetValue(Random r, double l) => -Math.Round(Math.Log(1 - r.NextDouble()) / l, 2);
		
		private void GetDictionary()
		{
			for (int i = 0; i < numbers.Count; i++)
			{
				double key = numbers[i];
				if (dictionary.ContainsKey(key))
					dictionary[key] += 1;
				else
					dictionary[key] = 1;
			}
		}
	}
}
