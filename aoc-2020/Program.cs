using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;


namespace aoc2020
{
	partial class MainClass
	{
		public static void Main(string[] args)
		{
			var checker = new OTCPasscodeChecker();
			Regex expression = new Regex(@"(?<min>\d+)-(?<max>\d+)\s(?<char>\w):\s(?<password>\w+)");
			var values = File.ReadAllLines(@"Data/input-D02.txt")
				.Select(line => {
					var match = expression.Match(line);
					if (match.Success) {
						return new Passcode(
							int.Parse(match.Groups["min"].Value),
							int.Parse(match.Groups["max"].Value),
							match.Groups["char"].Value[0],
							match.Groups["password"].Value
						);
					}

					Console.WriteLine($"Failed to parse: {line}");
					return new Passcode();
				})
				.Where(passcode => checker.IsValid(passcode))
				.ToList();

			Console.WriteLine($"Number of valid passcodes: {values.Count()}");
		}
	}
}
