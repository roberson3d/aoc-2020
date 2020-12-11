using System;
using System.Collections.Generic;

namespace aoc2020
{
	class SumSearcher
	{
		readonly long target;
		readonly List<long> list;

		public SumSearcher(long target, List<long> list)
		{
			this.target = target;
			this.list = list;
		}

		public bool FindSums(ref long[] arr)
		{
			list.Sort();
			return FindSumsRecursive(ref arr, 0, 0, 0);
		}

		bool FindSumsRecursive(ref long[] arr, long sum, int startIndex, long level)
		{
			long maxLevels = arr.Length;
			if (level == maxLevels && sum == target) {
				return true;
			}

			if (level >= maxLevels || sum > target) {
				//Console.WriteLine($"Check [{string.Join(", ", arr)}] :: {sum}");
				return false;
			}

			for (int i = startIndex; i < list.Count; i++) {
				arr[level] = list[i];
				if (FindSumsRecursive(ref arr, sum + list[i], i + 1, level + 1)) {
					return true;
				}
			}

			//Console.WriteLine($"Check* [{string.Join(", ", arr)}] :: {sum}");
			return false;
		}
	}
}
