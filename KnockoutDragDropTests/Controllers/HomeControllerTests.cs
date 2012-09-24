using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using KnockoutDragDrop.Controllers;
using KnockoutDragDrop.Models;
using NUnit.Framework;

namespace KnockoutDragDropTests.Controllers
{
	class HomeControllerTests
	{
		#region Fields/Constants

		private HomeController _homeController;

		#endregion

		#region Properties

		#endregion

		#region SetUp

		/// <summary>
		/// Sets up the environment prior to each test running.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_homeController = new HomeController();
		}

		#endregion


		#region Tests

		/// <summary>
		/// Tests that the Index method correctly calls the service and returns the model.
		/// </summary>
		/// <remarks>
		/// - Desired Result:	ModelGotAndSent
		/// - Coordinator:      When
		/// - Conditions:       IndexGet
		/// </remarks>
		[Test]
		public void TestIndex_ModelGotAndSent_When_IndexGet()
		{
			ViewResult result = (ViewResult)_homeController.Index();
			Assert.IsNotNull(result.ViewBag.Model);
		}

		/// <summary>
		/// Tests that the Index method correctly calls the service and saves the model.
		/// </summary>
		/// <remarks>
		/// - Desired Result:	ModelSaved
		/// - Coordinator:      When
		/// - Conditions:       IndexPost
		/// </remarks>
		[Test]
		public void TestIndex_ModelSaved_When_IndexPost()
		{
			SeatingChartViewModel model = new SeatingChartViewModel();
			_homeController.Index();
			ViewResult result = (ViewResult)_homeController.AdjustPriority("300", "300", 1, 1, 1);
		}

		#endregion
	}
}
