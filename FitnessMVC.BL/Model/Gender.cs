using System;

namespace FitnessMVC.BL.Model
{
	[Serializable]
	public class Gender
	{
		public Gender(string name)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("Gender cannot be empty", nameof(name));
			}
			Name = name;
		}
		public string Name { get; }

		public override string ToString()
		{
			return Name;
		}
	}
}