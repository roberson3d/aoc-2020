using System.Collections.Generic;

namespace aoc2020
{
	class SumSearcher
	{
		readonly int target;
		readonly List<int> list;

		public SumSearcher(int target, List<int> list)
		{
			this.target = target;
			this.list = list;
		}

		public bool FindSums(ref int[] arr)
		{
			list.Sort();
			return FindSumsRecursive(ref arr, 0, 0, 0);
		}

		bool FindSumsRecursive(ref int[] arr, int sum, int startIndex, int level)
		{
			int maxLevels = arr.Length;
			if (level == maxLevels && sum == target) {
				return true;
			}

			if (level >= maxLevels || sum > target) {
				return false;
			}

			for (int i = startIndex; i < list.Count - maxLevels; i++) {
				arr[level] = list[i];
				if (FindSumsRecursive(ref arr, sum + list[i], i + 1, level + 1)) {
					return true;
				}
			}

			return false;
		}
	}
}
