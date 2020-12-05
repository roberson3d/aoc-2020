using System;
using System.Text.RegularExpressions;

namespace aoc2020
{
	public struct PassportInfo
	{
		public readonly string BirthYear;
		public readonly string IssueYear;
		public readonly string ExpirationYear;
		public readonly string Height;
		public readonly string HairColor;
		public readonly string EyeColor;
		public readonly string PassportID;
		public readonly string CountryID;

		public PassportInfo(string info)
		{
			BirthYear = string.Empty;
			IssueYear = string.Empty;
			ExpirationYear = string.Empty;
			Height = string.Empty;
			HairColor = string.Empty;
			EyeColor = string.Empty;
			PassportID = string.Empty;
			CountryID = string.Empty;

			const string regex = @"(?<key>[\w]+):#?(?<value>[\w]+)";
			Regex rx = new Regex(regex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
			MatchCollection matches = rx.Matches(info);
			// Report on each match.
			foreach (Match match in matches) {
				switch (match.Groups["key"].Value) {
					case "byr": BirthYear = match.Groups["value"].Value; break;
					case "iyr": IssueYear = match.Groups["value"].Value; break;
					case "eyr": ExpirationYear = match.Groups["value"].Value; break;
					case "hgt": Height = match.Groups["value"].Value; break;
					case "hcl": HairColor = match.Groups["value"].Value; break;
					case "ecl": EyeColor = match.Groups["value"].Value; break;
					case "pid": PassportID = match.Groups["value"].Value; break;
					case "cid": CountryID = match.Groups["value"].Value; break;
					default:
						Console.WriteLine($"Unhandled: {match.Groups["key"].Value}");
						break;
				};
			}
		}

		public bool IsValid()
			=> !string.IsNullOrWhiteSpace(BirthYear)
			&& !string.IsNullOrWhiteSpace(IssueYear)
			&& !string.IsNullOrWhiteSpace(ExpirationYear)
			&& !string.IsNullOrWhiteSpace(Height)
			&& !string.IsNullOrWhiteSpace(HairColor)
			&& !string.IsNullOrWhiteSpace(EyeColor)
			&& !string.IsNullOrWhiteSpace(PassportID)
			//&& !string.IsNullOrWhiteSpace(CountryID)
			;

		public override string ToString()
			=> $"{(IsValid () ? "    " : "XXXX")}\tBirth: {BirthYear, -5}\tIssued: {IssueYear,-5}\tExp: {ExpirationYear,-5}\tHeight: {Height,-5}\tHair: {HairColor,-5}\tEye: {EyeColor,-5}\tCountry: {CountryID,-10}\tPassport: {PassportID,-10}";
	}
}
