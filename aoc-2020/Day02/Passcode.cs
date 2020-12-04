using System.Linq;

namespace aoc2020
{
	public struct Passcode
	{
		public readonly int Min;
		public readonly int Max;
		public readonly char Char;
		public readonly string Password;

		public Passcode(int min, int max, char c, string password)
		{
			Min = min;
			Max = max;
			Char = c;
			Password = password;
		}

		public bool IsValid()
		{
			var c = Char;
			var count = Password.Count(x => x == c);
			return count <= Max && count >= Min;
		}

		public bool IsValidOTC() => Password[Max - 1] == Char ^ Password[Min - 1] == Char;

		public override string ToString() => $"Range ({Min}, {Max}) {Char} in {Password}";
	}

	public interface IPasscodeChecker
	{
		bool IsValid(Passcode passcode);
	}

	public struct OTCPasscodeChecker : IPasscodeChecker
	{
		public bool IsValid(Passcode passcode)
			=> passcode.Password[passcode.Max - 1] == passcode.Char
			^ passcode.Password[passcode.Min - 1] == passcode.Char;
	}

	public struct SLEDPasscodeChecker : IPasscodeChecker
	{
		public bool IsValid(Passcode passcode)
		{
			var count = passcode.Password.Count(x => x == passcode.Char);
			return count <= passcode.Max && count >= passcode.Min;
		}
	}
}
