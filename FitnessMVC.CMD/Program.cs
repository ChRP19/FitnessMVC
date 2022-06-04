using System;
using System.Globalization;
using System.Resources;
using FitnessMVC.BL.Controller;
using FitnessMVC.BL.Model;
using FitnessMVC.CMD.Languages;

namespace FitnessMVC.CMD
{
	class Program
	{
		static void Main(string[] args)
		{
			var culture = CultureInfo.CreateSpecificCulture("ru-ru");
			var resourceManager = new ResourceManager("FitnessMVC.CMD.Languages.Messages", typeof(Program).Assembly);
			
			Console.WriteLine(resourceManager.GetString("Hello", culture));
			Console.WriteLine(resourceManager.GetString("EnterName", culture));

			var name = Console.ReadLine();

			var userController = new UserController(name);
			var eatingController = new EatingController(userController.CurrentUser);
			if(userController.IsNewUser)
			{
				Console.Write("Enter gender: ");
				var gender = Console.ReadLine();
				var weight = ParseDouble("weight");
				var height = ParseDouble("height");
				var birthdate = ParseDateTime();
				
				userController.SetNewUserData(gender, birthdate, weight, height);
			}			
			Console.WriteLine(userController.CurrentUser);
			Console.WriteLine("What do you want to do?");
			Console.WriteLine("E - enter a meal.");
			var key = Console.ReadKey();
			Console.WriteLine();
			
			if (key.Key == ConsoleKey.E)
			{
				var foods = EnterEating();
				eatingController.Add(foods.Food, foods.Weight);

				foreach(var item in eatingController.Eating.Foods)
				{
					Console.WriteLine($"\t{item.Key} - {item.Value}");
				}
			}
			Console.ReadLine();
		}
		
		private static (Food Food, double Weight) EnterEating()
		{
			Console.WriteLine("Enter product name: ");
			
			var food = Console.ReadLine();
			var proteins = ParseDouble("proteins");
			var fats = ParseDouble("fats");
			var carbohydrates = ParseDouble("carbohydrates");
			var calories = ParseDouble("calories");
			var weight = ParseDouble("serving weight");
			
			var product = new Food(food, proteins, fats, carbohydrates, calories);
			
			return (Food: product, Weight: weight);
		}
		private static DateTime ParseDateTime()
		{
			DateTime birthdate;
			while(true)
			{
				Console.Write("Enter birthdate (dd.MM.yyyy): ");
				if(DateTime.TryParse(Console.ReadLine(), out birthdate))
					break;
				else
					Console.WriteLine("Wrong format birthdate");
			}
			return birthdate;
		}
		private static double ParseDouble(string name)
		{
			while(true)
			{
				Console.Write($"Enter {name}: ");
				if(double.TryParse(Console.ReadLine(), out double value))
					return value;
				else
					Console.WriteLine($"Wrong format {name}");
			}
		}
	}
}