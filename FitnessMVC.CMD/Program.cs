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
			var exerciseController = new ExerciseController(userController.CurrentUser);
			if(userController.IsNewUser)
			{
				Console.Write("Enter gender: ");
				var gender = Console.ReadLine();
				var weight = ParseDouble("weight");
				var height = ParseDouble("height");
				var birthdate = ParseDateTime("birthdate");

				userController.SetNewUserData(gender, birthdate, weight, height);
			}
			Console.WriteLine(userController.CurrentUser);
			while(true)
			{
				Console.WriteLine("What do you want to do?");
				Console.WriteLine("E - enter a meal.");
				Console.WriteLine("A - enter exercise.");
				Console.WriteLine("Q - exit.");
				var key = Console.ReadKey();
				Console.WriteLine();
				switch(key.Key)
				{
					case ConsoleKey.E:
					{
						var foods = EnterEating();
						eatingController.Add(foods.Food, foods.Weight);

						foreach(var item in eatingController.Eating.Foods)
						{
							Console.WriteLine($"\t{item.Key} - {item.Value}");
						}
						break;
					}
					case ConsoleKey.A:
					{
						var exe = EnterExercise();
						exerciseController.Add(exe.Activity, exe.Begin, exe.End);
						foreach(var item in exerciseController.Exercises)
						{
							Console.WriteLine($"\t{item.Activity} from {item.Start.ToShortTimeString()} to {item.Finish.ToShortTimeString()}");
						}
						break;
					}
					case ConsoleKey.Q:
						Environment.Exit(0);
						break;
				}
				Console.ReadLine();
			}
		}
		private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
		{
			Console.WriteLine("Enter exercise name: ");
			var name = Console.ReadLine();
			var energy = ParseDouble("energy consumption per minute");
			var begin = ParseDateTime("start of exercise");
			var end = ParseDateTime("end of exercise");
			var activity = new Activity(name, energy);
			return (begin, end, activity);
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

		private static DateTime ParseDateTime(string value)
		{
			DateTime birthdate;
			while(true)
			{
				Console.Write($"Enter {value} (dd.MM.yyyy): ");
				if(DateTime.TryParse(Console.ReadLine(), out birthdate))
					break;
				else
					Console.WriteLine($"Wrong format {value}");
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