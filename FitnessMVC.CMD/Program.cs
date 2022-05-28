using System;
using FitnessMVC.BL.Controller;

namespace FitnessMVC.CMD
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the FitnessMVC!");

			Console.WriteLine("Enter username: ");
			var name = Console.ReadLine();

			var userController = new UserController(name);
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
			Console.ReadLine();
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