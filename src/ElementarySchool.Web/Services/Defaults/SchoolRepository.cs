using System.Collections.Generic;
using System.Linq;
using ElementarySchool.Core.Exceptions;
using ElementarySchool.Models;
using ElementarySchool.Services.Abstractions;

namespace ElementarySchool.Services.Defaults
{
	public class SchoolRepository : ISchoolRepository
	{
		private readonly List<School> _schools;

		public SchoolRepository()
		{
			_schools = new List<School>();
		}


		public IEnumerable<School> GetAll() => _schools;
		public School GetByName(string name) => _schools.FirstOrDefault(s => s.Name == name);

		public void Create(School school)
		{
			if (GetByName(school.Name) is null)
				_schools.Add(school);
			else
				throw new HttpException($"School with name '{school.Name} already exists'");
		}

		public void Update(School school)
		{
			if (GetByName(school.Name) is null)
				throw new HttpException($"School with name '{school.Name} not exists'");

			School prev = GetByName(school.Name);
			_schools.Remove(prev);
			_schools.Add(school);
		}

		public void Delete(School school)
		{
			if (GetByName(school.Name) is null)
				throw new HttpException($"School with name '{school.Name} not exists'");

			_schools.Remove(school);
		}
	}
}