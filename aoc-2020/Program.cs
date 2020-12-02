using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace aoc2020
{
	class MainClass
	{
		const int target = 2020;

		public static void Main(string[] args)
		{
			var values = File.ReadAllLines(@"Data/input-D01.txt")
				.Select(line => int.Parse(line))
				.ToList();

			//if (FindSums(values, out var x, out var y)) {
			//	Console.WriteLine($"Found! {values[x]} * {values[y]} = {values[x] * values[y]}");
			//} else {
			//	Console.WriteLine($"Sum {target} not found.");
			//}

			if (FindSums3 (values, out var arr)) {
				var product = arr[0];
				for (int i = 1; i < arr.Length; i++) { product *= arr[i]; }
				Console.WriteLine($"Found! {string.Join (", ", arr)}. Product = {product}");
			} else {
				Console.WriteLine($"Sum {target} not found.");
			}
		}

		static bool FindSums2 (List<int> list, out int x, out int y)
		{
			list.Sort();

			x = 0;
			y = list.Count() - 1;

			do {
				while (list[x] + list[y] < target) {
					x++;
				}

				if (list[x] + list[y] == target) {
					return true;
				}

				while (list[x] + list[y] > target) {
					y--;
				}
			} while (x <= y);

			return false;
		}

		static bool FindSums3 (List<int> list, out int[] arr)
		{
			list.Sort();

			for (int i = 0; i < list.Count; i++) {
				for (int j = i + 1; j < list.Count; j++) {
					for (int k = j + 1; k < list.Count; k++) {
						if (list[i] + list[j] + list[k] == target) {
							arr = new int[] {
								list[i],
								list[j],
								list[k]
							};
							return true;
						}
					}
				}
			}

			arr = null;
			return false;
		}
	}
}
