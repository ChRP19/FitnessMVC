using System;
using System.Globalization;

namespace FitnessMVC.BL.Model
{
	[Serializable]
	public class Food
	{
		public Food(string name) : this(name, 0, 0, 0, 0){ }
		public Food(string name, double proteins, double fats, double carbohydrates, double calories)
		{
			Proteins = proteins / 100.0;
			Fats = fats / 100.0;
			Carbohydrates = carbohydrates / 100.0;
			Calories = calories / 100.0;
		}
		public string Name { get; }

		public double Proteins { get; }
		public double Fats { get; }
		public double Carbohydrates { get; }
		public double Calories { get; }
	}
}