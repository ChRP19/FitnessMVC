using System;
using FitnessMVC.BL.Controller;

namespace FitnessMVC.CMD
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the FitnessMVC!");

			Console.WriteLine("Enter username:");
			var name = Console.ReadLine();

			Console.WriteLine("Enter gender:");
			var gender = Console.ReadLine();
			
			Console.WriteLine("Enter birthdate:");
			var birthdate = DateTime.Parse(Console.ReadLine());
			
			Console.WriteLine("Enter weight:");
			var weight = Double.Parse(Console.ReadLine());
			
			Console.WriteLine("Enter height:");
			var height = Double.Parse(Console.ReadLine());

			var userController = new UserController(name, gender, birthdate, weight, height);
			userController.Save();
		}
	}
}