using System.Collections.Generic;
using System.Linq;
using ElementarySchool.Core.Exceptions;
using ElementarySchool.Models;
using ElementarySchool.Services.Abstractions;
using ElementarySchool.Services.Defaults;
using Xunit;

namespace ElementarySchool.Tests.Services
{
	public class SchoolRepositoryTests
	{
		private readonly ISchoolRepository _schoolRepository;


		public SchoolRepositoryTests()
		{
			_schoolRepository = new SchoolRepository();
		}

		[Fact]
		public void GetSchools()
		{
			// Arrange
			List<School> schools = new[] { "foo", "bar", "School_198" }
					.Select(SchoolFactory.Create).ToList();

			const int expectedCount = 3;

			// Act
			foreach (School school in schools)
				_schoolRepository.Create(school);

			int actualCount = _schoolRepository.GetAll().Count();

			// Assert
			Assert.Equal(expectedCount, actualCount);
		}

		[Theory]
		[InlineData("School_198")]
		[InlineData("foo", "bar", "foo")]
		[InlineData("", "", null)]
		public void CreateSchool(params string[] schoolNames)
		{
			foreach (string schoolName in schoolNames)
			{
				// Arrange
				var school = new School { Name = schoolName };

				// Act
				// Assert
				if (_schoolRepository.GetByName(schoolName) is null)
					_schoolRepository.Create(school);
				else
					Assert.Throws<HttpException>(() => _schoolRepository.Create(school));
			}
		}


		[Theory]
		[InlineData("School_198")]
		[InlineData("foo", "bar", "foo")]
		[InlineData("", "", null)]
		public void DeleteSchool(params string[] schoolNames)
		{
			foreach (string schoolName in schoolNames)
			{
				// Arrange
				var school = new School { Name = schoolName };

				// Act
				// Assert
				if (_schoolRepository.GetByName(schoolName) is not null)
					_schoolRepository.Delete(school);
				else
					Assert.Throws<HttpException>(() => _schoolRepository.Delete(school));
			}
		}
	}
}