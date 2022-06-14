using System.Data.Entity.Migrations;
using FitnessMVC.BL.Controller;

namespace FitnessMVC.BL.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<FitnessMVC.BL.Controller.FitnessContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
			ContextKey = "FitnessMVC.BL.Controller.FitnessContext";
		}

		protected override void Seed(FitnessContext context)
		{
			base.Seed(context);
		}
	}
}