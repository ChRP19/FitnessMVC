﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessMVC.BL.Controller
{
	public abstract class BaseController
	{
		protected void Save(string fileName, object item)
		{
			var formatter = new BinaryFormatter();
			using var fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
			{
				formatter.Serialize(fileStream, item);
			}
		}

		protected T Load<T>(string fileName)
		{
			var formatter = new BinaryFormatter();
			using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
			{
				if(fileStream.Length > 0 && formatter.Deserialize(fileStream) is T items)
					return items;
				else
					return default(T);
			}

		}
	}
}