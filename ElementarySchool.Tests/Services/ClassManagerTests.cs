using System.Collections.Generic;
using System.Linq;
using ElementarySchool.Models;
using ElementarySchool.Services.Abstractions;
using ElementarySchool.Services.Defaults;
using Xunit;

namespace ElementarySchool.Tests.Services
{
	public class ClassManagerTests
	{
		private readonly IClassManager _classManager;
		private readonly ISchoolRepository _schoolRepository;

		public ClassManagerTests()
		{
			_schoolRepository = new SchoolRepository();

			// Fill repo with test data
			List<School> schools = new[] { "foo", "bar", "School_198" }
					.Select(SchoolFactory.Create).ToList();

			foreach (School school in schools)
				_schoolRepository.Create(school);

			_classManager = new ClassManager(_schoolRepository);
		}


		[Fact]
		public void AddKidsRandom()
		{
			// Arrange
			const int expected = 10;
			const string schoolName = "foo";

			// Act
			_classManager.AddKidsRandom(schoolName, expected);
			int actual = _schoolRepository.GetByName(schoolName).Classes.Sum(c => c.Children.Count);

			// Assert
			Assert.Equal(expected, actual);
		}


		[Fact]
		public void AddKids()
		{
			// Arrange
			const string schoolName = "foo";
			Child[] children =
			{
					ChildrenFactory.RandomFemale(),
					ChildrenFactory.RandomFemale(),
					ChildrenFactory.RandomMale(),
					ChildrenFactory.RandomMale(),
			};

			// Act
			_classManager.AddKids(schoolName, children);
			int actual = _schoolRepository.GetByName(schoolName).Classes.Sum(c => c.Children.Count);

			// Assert
			Assert.Equal(children.Length, actual);
		}
	}
}