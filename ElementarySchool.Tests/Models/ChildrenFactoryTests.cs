using System.Linq;
using ElementarySchool.Models;
using Xunit;
using Xunit.Abstractions;

namespace ElementarySchool.Tests.Models
{
	public class ChildrenFactoryTests
	{
		private readonly ITestOutputHelper _testOutputHelper;

		public ChildrenFactoryTests(ITestOutputHelper testOutputHelper)
		{
			_testOutputHelper = testOutputHelper;
		}

		[Fact]
		public void RandomManyTest()
		{
			int count = ChildrenFactory.RandomMany(19).Count();
			Assert.Equal(19, count);
		}

		[Fact]
		public void RandomTest()
		{
			var child = ChildrenFactory.Random();
			var secondChild = ChildrenFactory.Random();
			Assert.NotNull(child);
			Assert.IsType<Child>(child);
			Assert.NotSame(child, secondChild);
			Assert.InRange(child.Age, 5, 15);
		}

		[Fact]
		public void RandomMaleTest()
		{
			var male = ChildrenFactory.RandomMale();
			_testOutputHelper.WriteLine(male.ToString());
			Assert.NotNull(male);
			Assert.True(male.Sex);
			Assert.False(!male.Sex);
		}

		[Fact]
		public void RandomFemaleTest()
		{
			var female = ChildrenFactory.RandomFemale();
			_testOutputHelper.WriteLine(female.ToString());
			Assert.NotNull(female);
			Assert.False(female.Sex);
			Assert.True(!female.Sex);
		}
	}
}