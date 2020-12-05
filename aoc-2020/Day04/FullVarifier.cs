using System.Diagnostics;
using System.Text.RegularExpressions;

namespace aoc2020
{
	struct FullVarifier : IPassportVarifier
	{
		public bool IsValid(PassportInfo passport)
			=> ValidateBirth(passport.BirthYear)
			&& ValidateIssue(passport.IssueYear)
			&& ValidateExpiration(passport.ExpirationYear)
			&& ValidateHeight(passport.Height)
			&& ValidateHair(passport.HairColor)
			&& ValidateEyes(passport.EyeColor)
			&& ValidatePassportID(passport.PassportID);

		bool ValidateBirth(string year)
		{
			if (int.TryParse(year, out var y)) {
				Debug.Assert(InRange(y, 1920, 2002), $"Birth out of range {y}");
				return InRange(y, 1920, 2002);
			}

			Debug.Fail($"Birth value cannot be parsed {year}");
			return false;
		}

		bool ValidateIssue(string year)
		{
			if (int.TryParse(year, out var y)) {
				Debug.Assert(InRange(y, 2010, 2020), $"Issue out of range {y}");
				return InRange(y, 2010, 2020);
			}

			Debug.Fail($"Issue value cannot be parsed {year}");
			return false;
		}

		bool ValidateExpiration(string year)
		{
			if (int.TryParse(year, out var y)) {
				Debug.Assert(InRange(y, 2020, 2030), $"Expiration out of range {y}");
				return InRange(y, 2020, 2030);
			}

			Debug.Fail($"Expiration value cannot be parsed {year}");
			return false;
		}

		bool InRange(int value, int min, int max) => !(value > max || value < min);

		bool ValidateHeight(string height)
		{
			if (height.EndsWith("in")) {
				if (int.TryParse(height.Substring(0, height.Length - 2), out var inch)) {
					Debug.Assert(InRange(inch, 59, 76), $"Height out of in range {inch}");
					return InRange(inch, 59, 76);
				}
			} else if (height.EndsWith("cm")) {
				if (int.TryParse(height.Substring(0, height.Length - 2), out var cm)) {
					Debug.Assert(InRange(cm, 150, 193), $"Height out of cm range {cm}");
					return InRange(cm, 150, 193);
				}
			} else if (string.IsNullOrWhiteSpace(height)) {
				return false;
			}

			Debug.Fail($"Height value cannot be parsed {height}");
			return false;
		}

		bool ValidateHair(string hairColor)
		{
			const string hairRegex = @"^#[a-f0-9]{6}$";
			var rx = new Regex(hairRegex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
			var matches = rx.Matches(hairColor);

			Debug.Assert(matches.Count != 0, $"Hair value not matching {hairColor}");
			return matches.Count != 0;
		}

		bool ValidateEyes(string eyeColor)
		{
			switch (eyeColor) {
				case "amb":
				case "blu":
				case "brn":
				case "gry":
				case "grn":
				case "hzl":
				case "oth":
					return true;
				default:
					Debug.Fail($"Eye value not matching {eyeColor}");
					return false;
			}
		}

		bool ValidatePassportID(string passportID)
		{
			const string pidRegex = @"^[0-9]{9}$";
			var rx = new Regex(pidRegex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
			var matches = rx.Matches(passportID);

			Debug.Assert(matches.Count != 0, $"Passport value not matching {passportID}");
			return matches.Count != 0;
		}
	}
}
