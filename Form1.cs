using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Distribution
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
			//UniformChart();
			//ExponentialChart();
			NormalChart();
		}

		private void NormalChart()
		{
			Normal normal = new Normal();
			Series series = new Series();
			foreach (KeyValuePair<double, int> value in normal.Frequency)
				series.Points.AddXY(value.Key, value.Value);
			chart1.Series.Add(series);
		}

		private void ExponentialChart()
		{
			Exponential exponential = new Exponential();
			Series series = new Series();
			foreach (KeyValuePair<double, int> value in exponential.Frequency)
				series.Points.AddXY(value.Key, value.Value);
			chart1.Series.Add(series);
		}

		private void UniformChart()
		{
			Dictionary<double, int> d = Uniform();
			Series series = new Series();
			foreach (KeyValuePair<double, int> value in d)
				series.Points.AddXY(value.Key, value.Value);
			chart1.Series.Add(series);
		}

		private Dictionary<double, int> Uniform()
		{
			List<double> numbers = new List<double>();
			Dictionary<double, int> dictionary = new Dictionary<double, int>();
			Random random = new Random();
			for (int i = 0; i < 100000; i++)
			{
				numbers.Add(Math.Round(random.NextDouble(), 3));
			}
			for (int i = 0; i < numbers.Count; i++)
			{
				double key = numbers[i];
				if (dictionary.ContainsKey(key))
					dictionary[key] += 1;
				else
					dictionary[key] = 1;
			}
			return dictionary;
		}
	}
}
