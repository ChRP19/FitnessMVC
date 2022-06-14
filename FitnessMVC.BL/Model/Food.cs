using System;
using System.Globalization;

namespace FitnessMVC.BL.Model
{
	[Serializable]
	public class Food
	{
		public int Id { get; set; }
		public Food(string name, double proteins = 0, double fats = 0, double carbohydrates = 0, double calories = 0)
		{
			Proteins = proteins / 100.0;
			Fats = fats / 100.0;
			Carbohydrates = carbohydrates / 100.0;
			Calories = calories / 100.0;
		}
		public Food() { }
		public string Name { get; set; }
		public double Proteins { get; set; }
		public double Fats { get; set; }
		public double Carbohydrates { get; set; }
		public double Calories { get; set; }
	}
}