using System;
using System.Linq;
using System.IO;

namespace aoc2020
{
	struct Day04 : IAOCProgram
	{
		public void Run()
		{
			var data = File.ReadAllText(@"Day04/input.txt")
			.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
			.Select(val => new PassportInfo(val));

			foreach (var entry in data) { Console.WriteLine(entry.ToString()); }

			var basic = new BasicVarifier();
			var basicCount = data
				.Where(passport => basic.IsValid(passport))
				.Count();
			Console.WriteLine($"pt1 valid passports Count: {basicCount}");

			var full = new FullVarifier();
			var fullCount = data
				.Where(passport => full.IsValid(passport))
				.Count();
			Console.WriteLine($"pt2 valid passports Count: {fullCount}");
		}
	}
}