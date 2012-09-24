using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using KnockoutDragDrop.Controllers;
using KnockoutDragDrop.Models;
using KnockoutDragDrop.Services;
using NUnit.Framework;

namespace KnockoutDragDropTests.Services
{
    class DataServiceTests
    {
		//#region Fields/Constants

		//private DataService _service;

		//#endregion

		//#region Properties

		//#endregion

		//#region SetUp

		///// <summary>
		///// Sets up the environment prior to each test running.
		///// </summary>
		//[SetUp]
		//public void SetUp()
		//{
		//	_service = new DataService();
		//	_service.StudentSeating = new SeatingChartViewModel
		//	{
		//		Tables = new List<Table>
		//					{
		//						GetTable(1),
		//						GetTable(2),
		//						GetTable(3)
		//					},
		//		AvailableStudents = new Table() { Name = "Availble Students", Students = GetStudents(4) }
		//	};
		//}

		//#endregion

		//#region Tests
		///// <summary>
		///// Tests that the LoadViewModel method correctly gets Data.
		///// </summary>
		///// <remarks>
		///// - Desired Result:	SeatingChartViewModel
		///// - Coordinator:      When
		///// - Conditions:       Called
		///// </remarks>
		//[Test]
		//public void TestLoadViewModel_SeatingChartViewModel_When_Called()
		//{
		//	SeatingChartViewModel model = new SeatingChartViewModel
		//		{
		//			Tables = new List<Table>
		//					{
		//						GetTable(1),
		//						GetTable(2),
		//						GetTable(3)
		//					},
		//			AvailableStudents = new Table() { Name = "Availble Students", Students = GetStudents(4) }
		//		};
		//	SeatingChartViewModel seatingChartViewModel = _service.LoadViewModel();
		//	Assert.AreEqual(model.Tables.Count, seatingChartViewModel.Tables.Count);
		//	Assert.AreEqual(model.AvailableStudents.Students.Count, seatingChartViewModel.AvailableStudents.Students.Count);
		//}

		///// <summary>
		///// Tests that the UpdateStudentPriority method correctly updates Data.
		///// </summary>
		///// <remarks>
		///// - Desired Result:	SeatingChartViewModelUpdated
		///// - Coordinator:      When
		///// - Conditions:       Called
		///// </remarks>
		//[Test]
		//public void TestUpdateStudentPriority_SeatingChartViewModelUpdated_When_ItemNotMoved()
		//{
		//	SeatingChartViewModel expected = new SeatingChartViewModel
		//	{
		//		Tables = new List<Table>
		//					{
		//						GetTable(1),
		//						GetTable(2),
		//						GetTable(3)
		//					},
		//		AvailableStudents = new Table() { Name = "Availble Students", Students = GetStudents(4) }
		//	};

		//	_service.UpdateStudentPriority(302, 2, 1, 1);

		//	AssertStudentChartViewModelEqual(expected);
		//}
		//[Test]
		//public void TestUpdateStudentPriority_SeatingChartViewModelUpdated_When_ItemMovedUp()
		//{
		//	SeatingChartViewModel expected = new SeatingChartViewModel
		//	{
		//		Tables = new List<Table>
		//					{
		//						GetTable(1),
		//						GetTable(2),
		//						GetTable(3)
		//					},
		//		AvailableStudents = new Table() { Name = "Availble Students", Students = GetStudents(4) }
		//	};
		//	expected.Tables[2].Students.FirstOrDefault(x => x.Id == 300).Priority = 1;
		//	expected.Tables[2].Students.FirstOrDefault(x => x.Id == 301).Priority = 2;
		//	expected.Tables[2].Students.FirstOrDefault(x => x.Id == 302).Priority = 0;


		//	_service.UpdateStudentPriority(302, 0, 1, 1);

		//	AssertStudentChartViewModelEqual(expected);
		//}
		//[Test]
		//public void TestUpdateStudentPriority_SeatingChartViewModelUpdated_When_Called_ItemMovedUp2()
		//{
		//	SeatingChartViewModel expected = new SeatingChartViewModel
		//	{
		//		Tables = new List<Table>
		//					{
		//						GetTable(1),
		//						GetTable(2),
		//						GetTable(3)
		//					},
		//		AvailableStudents = new Table() { Name = "Availble Students", Students = GetStudents(4) }
		//	};
		//	expected.Tables[2].Students.FirstOrDefault(x => x.Id == 300).Priority = 1;
		//	expected.Tables[2].Students.FirstOrDefault(x => x.Id == 301).Priority = 0;
		//	expected.Tables[2].Students.FirstOrDefault(x => x.Id == 302).Priority = 2;


		//	_service.UpdateStudentPriority(301, 0, 1, 1);

		//	AssertStudentChartViewModelEqual(expected);
		//}

		//[Test]
		//public void TestUpdateStudentPriority_SeatingChartViewModelUpdated_When_Called_ItemMovedDown()
		//{
		//	SeatingChartViewModel expected = new SeatingChartViewModel
		//	{
		//		Tables = new List<Table>
		//					{
		//						GetTable(1),
		//						GetTable(2),
		//						GetTable(3)
		//					},
		//		AvailableStudents = new Table() { Name = "Availble Students", Students = GetStudents(4) }
		//	};
		//	expected.Tables[2].Students.FirstOrDefault(x => x.Id == 300).Priority = 0;
		//	expected.Tables[2].Students.FirstOrDefault(x => x.Id == 301).Priority = 2;
		//	expected.Tables[2].Students.FirstOrDefault(x => x.Id == 302).Priority = 1;


		//	_service.UpdateStudentPriority(301, 2, 1, 1);

		//	AssertStudentChartViewModelEqual(expected);
		//}

		//[Test]
		//public void TestUpdateStudentPriority_SeatingChartViewModelUpdated_When_Called_ItemMovedDown2()
		//{
		//	SeatingChartViewModel expected = new SeatingChartViewModel
		//	{
		//		Tables = new List<Table>
		//					{
		//						GetTable(1),
		//						GetTable(2),
		//						GetTable(3)
		//					},
		//		AvailableStudents = new Table() { Name = "Availble Students", Students = GetStudents(4) }
		//	};
		//	expected.Tables[2].Students.FirstOrDefault(x => x.Id == 300).Priority = 2;
		//	expected.Tables[2].Students.FirstOrDefault(x => x.Id == 301).Priority = 0;
		//	expected.Tables[2].Students.FirstOrDefault(x => x.Id == 302).Priority = 1;


		//	_service.UpdateStudentPriority(300, 2, 1, 1);

		//	AssertStudentChartViewModelEqual(expected);
		//}
		//#endregion

		//#region Private Logic
		//private Table GetTable(int seed)
		//{
		//	return new Table()
		//	{
		//		Name = "Table" + seed,
		//		Students = GetStudents(seed)
		//	};
		//}

		//private List<Student> GetStudents(int seed)
		//{
		//	var students = new List<Student>();
		//	for (int i = 0; i < 3; i++)
		//	{
		//		students.Add(new Student()
		//		{
		//			Id = (seed * 100) + i,
		//			Gender = i % 2 == 0 ? "male" : "female",
		//			Name = "S" + (seed * 100) + i,
		//			Priority = i
		//		});
		//	}
		//	return students;
		//}


		//private void AssertStudentChartViewModelEqual(SeatingChartViewModel expected)
		//{
		//	Assert.AreEqual(expected.Tables.Count, _service.StudentSeating.Tables.Count);
		//	for (int i = 0; i < expected.Tables.Count; i++)
		//	{
		//		Assert.AreEqual(expected.Tables[i].Name, _service.StudentSeating.Tables[i].Name);
		//		for (int j = 0; j < expected.Tables[i].Students.Count; j++)
		//		{
		//			Assert.AreEqual(expected.Tables[i].Students[j].Id, _service.StudentSeating.Tables[i].Students[j].Id,
		//							String.Format("failed at table {0} student {1} id", i, j));
		//			Assert.AreEqual(expected.Tables[i].Students[j].Name, _service.StudentSeating.Tables[i].Students[j].Name,
		//							String.Format("failed at table {0} student {1} name", i, j));
		//			Assert.AreEqual(expected.Tables[i].Students[j].Gender, _service.StudentSeating.Tables[i].Students[j].Gender,
		//							String.Format("failed at table {0} student {1} gender", i, j));
		//			Assert.AreEqual(expected.Tables[i].Students[j].Priority,
		//							_service.StudentSeating.Tables[i].Students[j].Priority,
		//							String.Format("failed at table {0} student {1} priority", i, j));
		//		}
		//	}
		//	Assert.AreEqual(expected.AvailableStudents.Students.Count, _service.StudentSeating.AvailableStudents.Students.Count);
		//}
		//#endregion
    }
}
