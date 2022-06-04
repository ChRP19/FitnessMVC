﻿using System;
using System.Collections.Generic;
using System.Linq;
using FitnessMVC.BL.Model;

namespace FitnessMVC.BL.Controller
{
	public class EatingController : BaseController
	{
		private const string FOODS_FILE_NAME = "foods.dat";
		private const string EATINGS_FILE_NAME = "eatings.dat";

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
			return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
		}
		private List<Food> GetAllFoods()
		{
			return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
		}
		private void Save()
		{
			base.Save(FOODS_FILE_NAME, Foods);
			base.Save(EATINGS_FILE_NAME, Eating);
		}
	}
}