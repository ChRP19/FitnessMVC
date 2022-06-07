using System;

namespace FitnessMVC.BL.Model
{
	[Serializable]
	public class Exercise
	{
		public Exercise(DateTime start, DateTime finish, Activity activity, User user)
		{
			Start = start;
			Finish = finish;
			Activity = activity;
			User = user;
		}
		public DateTime Start { get; }
		public DateTime Finish { get; }
		public Activity Activity { get; }
		public User User { get; }
	}
}