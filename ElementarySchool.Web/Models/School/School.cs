using System.Collections.Generic;

namespace ElementarySchool.Models
{
	public class School
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public List<Class> Classes { get; init; }
	}
}