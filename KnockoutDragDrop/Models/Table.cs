using System.Collections.Generic;

namespace KnockoutDragDrop.Models
{
	public class Table
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public List<Student> Students { get; set; }

		public int Priority { get; set; }
	}
}