using System;
using System.Linq;

namespace aoc2020
{
	public struct CultureDeclaration
	{
		public readonly int[] tally;
		public readonly int memberCount;

		public CultureDeclaration(string notes)
		{
			tally = new int[26];

			var a = (int)'a';
			foreach (var c in notes) {
				if (char.IsLetter (c))
					tally[c - a]++;
			}

			memberCount = notes
				.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
				.Count();
		}
	}
}
