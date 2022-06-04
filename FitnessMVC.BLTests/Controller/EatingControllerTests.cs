using System;
using System.Linq;
using FitnessMVC.BL.Controller;
using FitnessMVC.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FitnessMVC.BLTests.Controller
{
	[TestClass]
	public class EatingControllerTests
	{
		[TestMethod]
		public void AddTest()
		{
			// Arrange
			var userName = Guid.NewGuid().ToString();
			var foodName = Guid.NewGuid().ToString();
			var rnd = new Random();
			var userController = new UserController(userName);
			var eatingController = new EatingController(userController.CurrentUser);
			var food = new Food(foodName, rnd.Next(5, 500), rnd.Next(5, 500), rnd.Next(5, 500), rnd.Next(5, 500));
			
			// Act
			eatingController.Add(food, 1000);
			
			// Assert
			//Assert.AreEqual(food, eatingController.Eating.Foods.First().Key.Name);
		}
	}
}