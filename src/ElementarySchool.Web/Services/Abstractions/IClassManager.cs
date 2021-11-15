using System.Collections.Generic;
using ElementarySchool.Models;

namespace ElementarySchool.Services.Abstractions
{
	public interface IClassManager
	{
		void AddKidsRandom(string schoolName, int count);
		void AddKids(string schoolName, IEnumerable<Child> children);
	}
}