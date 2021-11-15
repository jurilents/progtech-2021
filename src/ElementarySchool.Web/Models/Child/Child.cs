using System.Text.Json.Serialization;

namespace ElementarySchool.Models
{
	public class Child
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public bool Sex { get; set; }
		public byte Age { get; set; }

		private string Gender => Sex ? "Boy" : "Girl";

		public override string ToString() => $"<Name: {Name}, Sex: {Gender}, Age: {Age}>";
	}
}