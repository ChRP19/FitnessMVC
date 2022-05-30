using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using FitnessMVC.BL.Model;

namespace FitnessMVC.BL.Controller
{
	public class UserController
	{
		public UserController(string userName)
		{
			if(string.IsNullOrWhiteSpace(userName))
			{
				throw new ArgumentNullException("Username cannot be empty.", nameof(userName));
			}
			Users = GetUserData();

			CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

			if(CurrentUser == null)
			{
				CurrentUser = new User(userName);
				Users.Add(CurrentUser);
				IsNewUser = true;
				Save();
			}
		}
		public List<User> Users { get; }

		public User CurrentUser { get; }

		public bool IsNewUser { get; } = false;
		private List<User> GetUserData()
		{
			var formatter = new BinaryFormatter();
			using var fileStream = new FileStream("user.dat", FileMode.OpenOrCreate);
			{
				if(fileStream.Length > 0 && formatter.Deserialize(fileStream) is List<User> users)
					return users;
				else
					return new List<User>();
			}
		}

		public void SetNewUserData(string genderName, DateTime birthdate, double weight = 1, double height = 1)
		{
			CurrentUser.Gender = new Gender(genderName);
			CurrentUser.Birthdate = birthdate;
			CurrentUser.Weight = weight;
			CurrentUser.Height = height;

			Save();

		}
		public void Save()
		{
			var formatter = new BinaryFormatter();
			using var fileStream = new FileStream("user.dat", FileMode.OpenOrCreate);
			{
				formatter.Serialize(fileStream, Users);
			}
		}
	}
}