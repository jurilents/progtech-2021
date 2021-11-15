using System;
using System.Collections.Generic;

namespace ElementarySchool.Models
{
	public static class ChildrenFactory
	{
		private static int _iter = 100;
		private static readonly Random _rand = new();


		public static void Complete(Child child)
		{
			child.Id = _iter++;
			child.Age = child.Age switch
			{
					< 3 => 3,
					> 20 => 20,
					_ => child.Age
			};
		}

		public static IEnumerable<Child> RandomMany(int count, double proportion = 0.5)
		{
			if (count <= 0)
				throw new ArgumentOutOfRangeException(nameof(count));

			for (int i = 0; i < count; i++)
				yield return Random(proportion);
		}

		public static Child Random(double proportion = 0.5) => _rand.NextDouble() > proportion ? RandomMale() : RandomFemale();

		public static Child RandomMale()
		{
			return new Child
			{
					Id = _iter++,
					Sex = true,
					Age = GenerateAge(),
					Name = GenerateMaleName()
			};
		}

		public static Child RandomFemale()
		{
			return new Child
			{
					Id = _iter++,
					Sex = false,
					Age = GenerateAge(),
					Name = GenerateFemaleName()
			};
		}


		private static readonly string[] MaleNames = { "Іваня", "Кирюша", "Серьожа", "Нікітка", "Данило", "Денчік", "Стьопа", "Юрій", "Владік", "Костя", "Лесь", "Джон", "Діо", "Димитро", "Ромчик", "Йосип", "Ерен" };
		private static readonly string[] FemaleNames = { "Анічка", "Олена", "Люда", "Оля", "Маруся", "Діана", "Маргарита", "Юля", "Вікторія", "Саша", "Хрестина", "Улянка", "Злата", "Ичіго", "Таня", "Мікаса" };
		private static readonly string[] Surnames = { "Шевченко", "Черненко", "Шмідт", "Ульм", "Гуро Гуро", "Джон", "Попенко", "Романов", "Білочка", "Енштейн", "Ферштейн", "Геббельс", "Габсбург", "Червондель", "Купрій", "Мамамото", "Ніт", "Жмайло", "Тиран", "Загреб", "Мілано", "Драгон", "Нгуен", "Кок", "Орочі", "Євнух", "Більбо", "Ґудзик", "Акерман", "Єгер", "Фіт", "Колбасенко", "Япончик" };

		private static string GenerateMaleName() => PickRandom(MaleNames) + " " + PickRandom(Surnames);
		private static string GenerateFemaleName() => PickRandom(FemaleNames) + " " + PickRandom(Surnames);
		private static byte GenerateAge() => (byte)_rand.Next(7, 11);

		private static T PickRandom<T>(IReadOnlyList<T> array) => array[_rand.Next(0, array.Count)];
	}
}