using System.Collections.Generic;
using ElementarySchool.Core.Enums;

namespace ElementarySchool.Models
{
	public static class ClassFactory
	{
		public static Class Create(ClassName name)
		{
			return new Class
			{
					Name = name,
					Children = new List<Child>()
			};
		}
	}
}