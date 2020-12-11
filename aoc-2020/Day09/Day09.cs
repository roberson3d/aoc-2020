using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace aoc2020
{
	struct Day09 : IAOCProgram
	{
		const int PreambleLength = 25;
		List<long> data;

		public void Run()
		{
			data = File.ReadAllLines(@"Day09/input.txt")
				.Select(line => long.Parse(line))
				.ToList();

			var missingIndex = Part1();

			if (missingIndex.HasValue) {
				Console.WriteLine($"pt1 {data[missingIndex.Value]} @{missingIndex.Value}");
				Part2(missingIndex.Value, out var first, out var last);

				var subrange = data.GetRange(first, last - first + 1);
				subrange.Sort();
				Console.WriteLine($"pt2 {subrange.First() + subrange.Last()} :: @{first}-{last} = {subrange.Sum()} :: {string.Join(", ", subrange)}");
			}
		}

		int? Part1 ()
		{
			for (int i = 0; i < data.Count - PreambleLength; i++) {
				var subList = data.GetRange(i, PreambleLength)
					.OrderBy(x => x)
					.ToList();
				var searcher = new SumSearcher(data[i + PreambleLength], subList);

				var array = new long[2];
				if (!searcher.FindSums(ref array)) {
					return i + PreambleLength;
				}
			}

			return null;
		}

		void Part2(int missingIndex, out int first, out int last)
		{
			first = 0;
			long sum = 0;
			for (last = 0; last < missingIndex; last++) {
				sum += data[last];

				while (sum > data[missingIndex]) {
					sum -= data[first];
					first++;
				}

				if (sum == data[missingIndex]) {
					return;
				}
			}
		}
	}
}