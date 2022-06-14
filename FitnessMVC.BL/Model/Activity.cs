using System;
using System.Collections.Generic;

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
		public Activity() { }
		public int Id { get; set; }
		public string Name { get; set; }
		
		public virtual ICollection<Exercise> Exercises { get; set; }
		public double CaloriesPerMinute { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}