using System;

namespace ElementarySchool.Core.Exceptions
{
	public class HttpException : Exception
	{
		public HttpException(string message) : base(message) { }
	}
}