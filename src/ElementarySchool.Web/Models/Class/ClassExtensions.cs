using System;
using System.Collections.Generic;
using System.Linq;
using ElementarySchool.Core.Enums;

namespace ElementarySchool.Models.Extensions
{
	public static class ClassExtensions
	{
		public static void AddChildToClass(this IEnumerable<Class> classes, ClassName className, Child child)
		{
			if (child is null)
				throw new ArgumentNullException(nameof(child));

			classes.FirstOrDefault(c => c.Name == className)?.Children.Add(child);
		}
	}
}