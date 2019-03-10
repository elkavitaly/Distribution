using System;
using System.Collections.Generic;
using System.Text;

namespace Distribution
{
    class Normal
    {
		private List<double> numbers;

		private Dictionary<double, int> dictionary;

		public List<double> Values { get => numbers; }

		public Dictionary<double, double> d;
		public Dictionary<double, int> Frequency { get => dictionary; }

		public Normal()
		{
			numbers = new List<double>();
			dictionary = new Dictionary<double, int>();
			GenerateValues();
			GetDictionary();
			//ChangeDictionary();
		}

		private void GenerateValues()
		{
			Random r = new Random();
			for (int i = 0; i < 100000; i++)
			{
				double[] arr = GetValue(r, 0.125, 0.5);
				numbers.Add(arr[0]);
				numbers.Add(arr[1]);
			}
			numbers.Sort();
		}

		private double[] GetValue(Random r, double deviation, double expected)
		{
			double x, y, s;
			do
			{
				x = 2 * r.NextDouble() - 1;
				y = 2 * r.NextDouble() - 1;
				s = x * x + y * y;
			}
			while (s > 1 || s == 0);
			double multi = Math.Sqrt(-2 * Math.Log(s) / s);

			return new double[] { Math.Round(x * multi, 2) * deviation + expected, Math.Round(y * multi, 2) * deviation + expected };
		}

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

		private void ChangeDictionary()
		{
			int sum = 0;
			foreach (KeyValuePair<double, int> p in dictionary) {
				sum += p.Value;
			}

			d = new Dictionary<double, double>();
			foreach (KeyValuePair<double, int> p in dictionary)
			{
				d.Add(p.Key, p.Value / sum);
			}
		}
    }
}
