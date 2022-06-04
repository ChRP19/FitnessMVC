using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FitnessMVC.BL.Model
{
	[Serializable]
	public class Eating
	{
		public Eating(User user)
		{
			User = user ?? throw new ArgumentNullException("User cannot be empty", nameof(user));
			Moment = DateTime.UtcNow;
			Foods = new Dictionary<Food, double>();

		}
		public DateTime Moment { get; }

		public Dictionary<Food, double> Foods { get; }

		public User User { get; }

		public void Add(Food food, double weight)
		{
			var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
			if(product == null)
			{
				Foods.Add(food, weight);
			}
			else
			{
				Foods[product] += weight;
			}
		}
	}
}