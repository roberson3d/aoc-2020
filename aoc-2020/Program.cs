using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace aoc2020
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var aoc = new AOCProgram();

			aoc.Day01();
			aoc.Day02();
			aoc.Day03();
			aoc.Day04();
			aoc.Day05();
			aoc.Day06();
		}
	}

	internal struct AOCProgram
	{
		/************ Day 01 **************/
		public void Day01()
		{
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
		}

		/************ Day 02 **************/
		public void Day02() {
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
		}

		/************ Day 03 **************/
		public void Day03()
		{
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

		/************ Day 04 **************/
		public void Day04()
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

		public void Day05()
		{
			int row, col;
			var converter = new TicketConversion();
			var seats = File.ReadAllLines(@"Day05/input.txt")
				.Select(line => new Ticket(line))
				.Select(ticket => converter.ConvertToSeat(ticket, out row, out col))
				.OrderBy(x => x);

			////BFFFBBFRRR: row 70, column 7, seat ID 567.
			//Console.WriteLine($"{converter.ConvertToSeat(new Ticket("BFFFBBFRRR"), out row, out col)} @ [{row}, {col}]");
			////FFFBBBFRRR: row 14, column 7, seat ID 119.
			//Console.WriteLine($"{converter.ConvertToSeat(new Ticket("FFFBBBFRRR"), out row, out col)} @ [{row}, {col}]");
			////BBFFBBFRLL: row 102, column 4, seat ID 820.
			//Console.WriteLine($"{converter.ConvertToSeat(new Ticket("BBFFBBFRLL"), out row, out col)} @ [{row}, {col}]");

			Console.WriteLine($"pt1 last seat: {seats.LastOrDefault()}");

			// find first empty seat
			var arr = seats.ToArray();
			for (int i = 0; i < arr.Length - 1; i++) {
				if (arr[i] != arr[i + 1] - 1) {
					Console.WriteLine($"pt2 my seat: {arr[i] + 1}");
					break;
				}
			}
		}

		public void Day06()
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
