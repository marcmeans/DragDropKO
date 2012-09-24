using System;
using System.Collections.Generic;
using System.Linq;
using KnockoutDragDrop.Models;

namespace KnockoutDragDrop.Services
{
	public static class DataService
	{

		private static SeatingChartViewModel _studentSeating;

		public static SeatingChartViewModel LoadViewModel()
		{
			if (_studentSeating == null)
			{
				_studentSeating = new SeatingChartViewModel
					{
						Tables = new List<Table>
                            {
                                GetTable(1),
                                GetTable(2),
                                new Table{Id = 3,Name = "Table3",Students = new List<Student>(),Priority = 2}
                            },
						AvailableStudents = new Table() { Id = 4, Name = "Availble Students", Students = GetStudents(4) }
					};
			}
			foreach (var t in _studentSeating.Tables)
			{
				var sorted = from s in t.Students
							 orderby s.Priority
							 select s;
				t.Students = sorted.ToList();
			}
			return _studentSeating;
		}

		public static void UpdateStudentPriority(string origStudentId, string changedStudentId, int newPriority, int sourceTableId, int targetTableId)
		{
			if (_studentSeating == null)
			{
				throw new NullReferenceException();
			}
			var source = _studentSeating.Tables.FirstOrDefault(x => x.Id == sourceTableId) ?? _studentSeating.AvailableStudents;
			var target = _studentSeating.Tables.FirstOrDefault(x => x.Id == targetTableId) ?? _studentSeating.AvailableStudents;
			var student = source.Students.FirstOrDefault(x => x.Id == origStudentId);
			var newStudent = source.Students.FirstOrDefault(x => x.Id == origStudentId).Clone();
			if (origStudentId != changedStudentId)
			{
				newStudent.Id = changedStudentId;
			}
			if (student == null || source == null || target == null)
			{
				throw new NullReferenceException("No Student matches the id passed in");
			}

			if (source.Id != target.Id)
			{
				target.Students.Add(newStudent);
				if (source != _studentSeating.AvailableStudents)
				{
					source.Students.Remove(student);
				}
				Reorder(source);
			}

			Reorder(newPriority, student, target);
			student.Priority = newStudent.Priority = newPriority;
		}

		public static void RemoveStudent(string studentId, int sourceId)
		{
			var source = _studentSeating.Tables.FirstOrDefault(x => x.Id == sourceId) ?? _studentSeating.AvailableStudents;
			var student = source.Students.FirstOrDefault(x => x.Id == studentId);
			source.Students.Remove(student);
		}

		#region Private Logic

		private static void Reorder(Table table)
		{
			int i = 0;
			foreach (var student in table.Students.OrderBy(x => x.Priority))
			{
				student.Priority = i;
				i++;
			}
		}

		private static void Reorder(int newPriority, Student student, Table target)
		{
			int originalPrioirty = student.Priority;
			if (newPriority == originalPrioirty)
			{
				//do nothing?
			}
			else if (newPriority < originalPrioirty)
			//the item was moved up, so everything else, up to the item that was moved, gets the priority plus one
			{
				foreach (Student x in target.Students)
				{
					if (x.Priority >= newPriority && x.Priority < originalPrioirty)
					{
						x.Priority++;
					}
				}
			}
			else //the item was moved down, so every thing else, up to the item that was moved, gets a priority minus one
			{
				foreach (Student x in target.Students)
				{
					if (x.Priority <= newPriority && x.Priority > originalPrioirty)
					{
						x.Priority--;
					}
				}
			}
		}

		private static Table GetTable(int seed)
		{
			return new Table()
			{
				Id = seed,
				Name = "Table" + seed,
				Students = GetStudents(seed),
				Priority = seed - 1
			};
		}

		private static List<Student> GetStudents(int seed)
		{
			var students = new List<Student>();
			for (int i = 0; i < 3; i++)
			{
				students.Add(new Student()
				{
					Id = ((seed * 100) + i).ToString(),
					Gender = i % 2 == 0 ? "male" : "female",
					Name = "S" + (seed * 100) + i,
					Priority = i
				});
			}
			return students;
		}

		#endregion

	}
}