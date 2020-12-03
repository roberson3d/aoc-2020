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
      /************ Day 01 **************/
			var values = File.ReadAllLines(@"Data/input-D01.txt")
				.Select(line => int.Parse(line));

			var arr = new int[2] { 0, 0 };
			var search = new SumSearcher(target, values.ToList ());


			if (search.FindSums(ref arr)) {
				var product = arr[0];
				for (int i = 1; i < arr.Length; i++) { product *= arr[i]; }
				Console.WriteLine($"pt1 Found! {string.Join(" * ", arr)} = {product}");
			} else {
				Console.WriteLine($"pt1 Sum {target} not found.");
			}

			arr = new int[3] { 0, 0, 0 };
			if (search.FindSums(ref arr)) {
				var product = arr[0];
				for (int i = 1; i < arr.Length; i++) { product *= arr[i]; }
				Console.WriteLine($"pt2 Found! {string.Join(" * ", arr)} = {product}");
			} else {
				Console.WriteLine($"pt2 Sum {target} not found.");
			}
  
      /************ Day 02 **************/
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
