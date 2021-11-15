using System.Collections.Generic;
using ElementarySchool.Core.Enums;

namespace ElementarySchool.Models
{
	public class Class
	{
		public ClassName Name { get; init; }
		public List<Child> Children { get; init; }
	}
}