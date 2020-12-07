using System;
using System.Linq;
using System.IO;

namespace aoc2020
{
	struct Day05 : IAOCProgram
	{
		public void Run()
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
	}
}