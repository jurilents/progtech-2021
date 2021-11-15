using System.Collections.Generic;
using ElementarySchool.Core.Enums;

namespace ElementarySchool.Models
{
	public static class SchoolFactory
	{
		private static int _iter = 100;

		public static School Create(string schoolName)
		{
			return new School
			{
					Id = _iter++,
					Name = schoolName,
					Classes = new List<Class>
					{
							ClassFactory.Create(ClassName.First),
							ClassFactory.Create(ClassName.Second),
							ClassFactory.Create(ClassName.Third),
							ClassFactory.Create(ClassName.Fourth),
					}
			};
		}
	}
}