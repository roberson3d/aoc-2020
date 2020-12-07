using System;
using System.Linq;
using System.IO;

namespace aoc2020
{
	struct Day06 : IAOCProgram
	{
		public void Run()
		{
			var data = File.ReadAllText(@"Day06/input.txt")
			.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
			.Select(val => new CultureDeclaration(val));

			var pt1 = data.Sum(cd => cd.tally.Count(entry => entry > 0));
			Console.WriteLine($"pt1 Sum: {pt1}");

			var pt2 = data.Sum(cd => cd.tally.Count(entry => entry == cd.memberCount));
			Console.WriteLine($"pt2 Sum: {pt2}");

		}
	}
}