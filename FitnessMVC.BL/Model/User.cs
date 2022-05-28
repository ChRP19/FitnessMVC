using System;
using System.Reflection.Metadata;

namespace FitnessMVC.BL.Model
{
	[Serializable]
	public class User
	{
		public User(string name, Gender gender, DateTime birthday, double weight, double height)
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
			if(birthday < DateTime.Parse("01.01.1900") || birthday >= DateTime.Now)
			{
				throw new ArgumentException("Impossible date of birth." ,nameof(birthday));
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
			Birthday = birthday;
			Weight = weight;
			Height = height;
		}
		public string Name { get; }

		public Gender Gender { get; }

		public DateTime Birthday { get; }

		public double Weight { get; set; }

		public double Height { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}

}