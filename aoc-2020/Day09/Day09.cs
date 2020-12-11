using System;
using System.IO;
using System.Linq;

namespace aoc2020
{
	struct Day09 : IAOCProgram
	{
		const int PreambleLength = 25;
		public void Run()
		{
			var data = File.ReadAllLines(@"Day09/input.txt")
				.Select(line => long.Parse(line))
				.ToList();

			for (int i = 0; i < data.Count - PreambleLength; i++) {
				var subList = data.GetRange(i, PreambleLength)
					.OrderBy (x => x)
					.ToList ();
				var searcher = new SumSearcher(data[i + PreambleLength], subList);

				var array = new long[2];
				if (!searcher.FindSums(ref array)) {
					Console.WriteLine($"MISSING {data[i + PreambleLength]} :: {string.Join(",", array)}");
				}
			}
		}
	}
}