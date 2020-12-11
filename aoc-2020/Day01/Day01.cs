using System;
using System.Linq;
using System.IO;

namespace aoc2020
{
	struct Day01 : IAOCProgram
	{
		public void Run()
		{
			var target = 2020;
			var values = File.ReadAllLines(@"Day01/input.txt")
				.Select(line => long.Parse(line));

			var arr = new long[2] { 0, 0 };
			var search = new SumSearcher(target, values.ToList());


			if (search.FindSums(ref arr)) {
				var product = arr[0];
				for (int i = 1; i < arr.Length; i++) { product *= arr[i]; }
				Console.WriteLine($"pt1 Found! {string.Join(" * ", arr)} = {product}");
			} else {
				Console.WriteLine($"pt1 Sum {target} not found.");
			}

			arr = new long[3] { 0, 0, 0 };
			if (search.FindSums(ref arr)) {
				var product = arr[0];
				for (int i = 1; i < arr.Length; i++) { product *= arr[i]; }
				Console.WriteLine($"pt2 Found! {string.Join(" * ", arr)} = {product}");
			} else {
				Console.WriteLine($"pt2 Sum {target} not found.");
			}
		}
	}
}