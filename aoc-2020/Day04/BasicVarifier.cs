namespace aoc2020
{
	struct BasicVarifier : IPassportVarifier
	{
		public bool IsValid(PassportInfo passport)
			=> !string.IsNullOrWhiteSpace(passport.BirthYear)
			&& !string.IsNullOrWhiteSpace(passport.IssueYear)
			&& !string.IsNullOrWhiteSpace(passport.ExpirationYear)
			&& !string.IsNullOrWhiteSpace(passport.Height)
			&& !string.IsNullOrWhiteSpace(passport.HairColor)
			&& !string.IsNullOrWhiteSpace(passport.EyeColor)
			&& !string.IsNullOrWhiteSpace(passport.PassportID)
			//&& !string.IsNullOrWhiteSpace(passport.CountryID)
			;
	}
}
