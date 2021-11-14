using System.Collections.Generic;
using ElementarySchool.Models;

namespace ElementarySchool.Services.Abstractions
{
	public interface ISchoolRepository
	{
		School GetByName(string name);
		IEnumerable<School> GetAll();
		void Create(School school);
		void Update(School school);
		void Delete(School school);
	}
}