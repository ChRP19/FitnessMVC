using System;

namespace FitnessMVC.BL.Model
{
	[Serializable]
	public class Activity
	{
		public Activity(string name, double caloriesPerMinute)
		{
			Name = name;
			CaloriesPerMinute = caloriesPerMinute;
		}
		public string Name { get; }
		public double CaloriesPerMinute { get; }

		public override string ToString()
		{
			return Name;
		}
	}
}