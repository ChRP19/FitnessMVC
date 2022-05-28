using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using FitnessMVC.BL.Model;

namespace FitnessMVC.BL.Controller
{
	public class UserController
	{
		public UserController(string userName, string genderName, DateTime birthdate, double weight, double height)
		{
			var gender = new Gender(genderName);
			User = new User(userName, gender, birthdate, weight, height);
		}
		public User User { get; }

		public void Save()
		{
			var formatter = new BinaryFormatter();
			using var fileStream = new FileStream("user.dat", FileMode.OpenOrCreate);
			{
				formatter.Serialize(fileStream, User);
			}
		}

		public User Load()
		{
			var formatter = new BinaryFormatter();
			using var fileStream = new FileStream("user.dat", FileMode.OpenOrCreate);
			{
				return formatter.Deserialize(fileStream) as User;
			}
		}
	}
}