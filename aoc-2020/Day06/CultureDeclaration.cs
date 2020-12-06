using System;
using System.Linq;

namespace aoc2020
{
	public struct CultureDeclaration
	{
		public readonly string[] answers;
		public readonly char[] consolidated;
		public readonly int allYesCount;
		public readonly int atLeastOneYesCount;
		public readonly int groupMembers;

		public CultureDeclaration(string notes)
		{
			answers = notes.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			consolidated = notes
				.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
				.SelectMany(answer => answer.ToCharArray())
				.Distinct()
				.OrderBy(c => c)
				.ToArray();

			var unique = new int[26];
			var a = (int)'a';
			foreach (var c in notes) {
				if (char.IsLetter (c))
					unique[c - a]++;
			}

			var members = answers.Count();
			groupMembers = members;
			allYesCount = unique.Count(entry => entry == members);
			atLeastOneYesCount = consolidated.Count();
		}
	}
}
