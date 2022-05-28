using System;
using System.Reflection.Metadata;

namespace FitnessMVC.BL.Model
{
	[Serializable]
	public class User
	{
		public User(string name, Gender gender, DateTime birthdate, double weight, double height)
		{
			#region Verification
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("Name can not be empty.", nameof(name));
			}
			if(gender == null)
			{
				throw new ArgumentNullException("Gender cannot be null.", nameof(gender));
			}
			if(birthdate < DateTime.Parse("01.01.1900") || birthdate >= DateTime.Now)
			{
				throw new ArgumentException("Impossible date of birth." ,nameof(birthdate));
			}
			if(weight <= 0)
			{
				throw new ArgumentException("Wrong weight.", nameof(weight));
			}
			if(height <= 0)
			{
				throw new ArgumentException("Wrong height.", nameof(height));
			}
			#endregion
			
			Name = name;
			Gender = gender;
			Birthdate = birthdate;
			Weight = weight;
			Height = height;
		}
		public User(string name)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("Name can not be empty.", nameof(name));
			}
			Name = name;
		}
		public string Name { get; }

		public Gender Gender { get; set; }

		public DateTime Birthdate { get; set; }

		public double Weight { get; set; }

		public double Height { get; set; }
		
		public int Age { get { return DateTime.Now.Year - Birthdate.Year; } }

		public override string ToString()
		{
			return Name + " " + Age;
		}
	}

}