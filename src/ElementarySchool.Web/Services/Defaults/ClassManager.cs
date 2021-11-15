using System.Collections.Generic;
using ElementarySchool.Core.Enums;
using ElementarySchool.Models;
using ElementarySchool.Models.Extensions;
using ElementarySchool.Services.Abstractions;

namespace ElementarySchool.Services.Defaults
{
	public class ClassManager : IClassManager
	{
		private readonly ISchoolRepository _schoolRepository;

		public ClassManager(ISchoolRepository schoolRepository)
		{
			_schoolRepository = schoolRepository;
		}

		public void AddKidsRandom(string schoolName, int count)
		{
			AddKids(schoolName, ChildrenFactory.RandomMany(count));
		}

		public void AddKids(string schoolName, IEnumerable<Child> children)
		{
			foreach (Child child in children)
			{
				ChildrenFactory.Complete(child);

				ClassName? className = child.Age switch
				{
						> 6 and <= 8 => ClassName.First,
						9 => ClassName.Second,
						10 => ClassName.Third,
						11 => ClassName.Fourth,
						_ => null
				};

				if (className is not null)
					ManageChild(schoolName, className.Value, child);
			}
		}


		private void ManageChild(string schoolName, ClassName className, Child child)
		{
			var school = _schoolRepository.GetByName(schoolName);
			school?.Classes.AddChildToClass(className, child);
		}
	}
}