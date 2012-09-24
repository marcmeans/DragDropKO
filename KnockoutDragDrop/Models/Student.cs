using System;
using System.Collections.Generic;
using System.Linq;

namespace KnockoutDragDrop.Models
{
	public class Student
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string Gender { get; set; }

		public int Priority { get; set; }
		
		public Student Clone()
		{
			return (Student)MemberwiseClone();
		}
	}
}