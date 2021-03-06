using System;
using System.Collections.Generic;
using System.Linq;
using FitnessMVC.BL.Model;

namespace FitnessMVC.BL.Controller
{
	public class EatingController : ControllerBase
	{
		private readonly User user;
		public List<Food> Foods { get; }
		public Eating Eating { get; }

		public EatingController(User user)
		{
			this.user = user ?? throw new ArgumentNullException("User cannot be null", nameof(user));
			Foods = GetAllFoods();
			Eating = GetEating();
		}

		public void Add(Food food, double weight)
		{
			var product = Foods.SingleOrDefault(f => f.Name == food.Name);
			if(product == null)
			{
				Foods.Add(food);
				Eating.Add(food, weight);
				Save();
			}
			else
			{
				Eating.Add(product, weight);
				Save();
			}
		}
		private Eating GetEating()
		{
			return Load<Eating>().First();
		}
		private List<Food> GetAllFoods()
		{
			return Load<Food>();
		}
		private void Save()
		{
			base.Save(Foods);
		}
	}
}