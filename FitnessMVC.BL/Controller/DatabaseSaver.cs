using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessMVC.BL.Model;

namespace FitnessMVC.BL.Controller
{
	public class DatabaseSaver : IDataSaver
	{
		public void Save<T>(List<T> item) where T : class
		{
			using (var db = new FitnessContext())
			{
				db.Set<T>().AddRange(item);
				db.SaveChanges();
			}
		}

		public List<T> Load<T>() where T : class
		{
			using(var db = new FitnessContext())
			{
				var result = db.Set<T>().Where(l => true).ToList();
				return result;
			}
		}
	}
}