﻿using System;
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
			var target = 2020;
			var values = File.ReadAllLines(@"Day01/input.txt")
				.Select(line => int.Parse(line));

			var arr = new int[2] { 0, 0 };
			var search = new SumSearcher(target, values.ToList());


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
			Regex expression = new Regex(@"(?<min>\d+)-(?<max>\d+)\s(?<char>\w):\s(?<password>\w+)");
			var values02 = File.ReadAllLines(@"Day02/input.txt")
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
				});

			var sledChecker = new SLEDPasscodeChecker();
			Console.WriteLine($"pt1 Number of valid passcodes: {values02.Where(passcode => sledChecker.IsValid(passcode)).Count()}");
			var otcChecker = new OTCPasscodeChecker();
			Console.WriteLine($"pt2 Number of valid passcodes: {values02.Where(passcode => otcChecker.IsValid(passcode)).Count()}");


			/************ Day 03 **************/
			var map = File.ReadAllLines(@"Day03/input.txt");

			var toboggan = new Toboggan();
			long trees = toboggan.Sled(map, new Slope(3, 1));
			Console.WriteLine($"pt1 Tree Count: {trees}");

			trees = 1;
			trees *= toboggan.Sled(map, new Slope(1, 1));
			trees *= toboggan.Sled(map, new Slope(3, 1));
			trees *= toboggan.Sled(map, new Slope(5, 1));
			trees *= toboggan.Sled(map, new Slope(7, 1));
			trees *= toboggan.Sled(map, new Slope(1, 2));
			Console.WriteLine($"pt2 Tree Count: {trees}");
		}
	}
}
