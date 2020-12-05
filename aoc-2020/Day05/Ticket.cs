namespace aoc2020
{
	struct Ticket
	{
		public readonly char[] rowDirections;
		public readonly char[] colDirections;

		public Ticket(string directions)
		{
			rowDirections = directions.Substring(0, 7).ToCharArray();
			colDirections = directions.Substring(7, 3).ToCharArray();
		}

		public override string ToString() => $"{new string(rowDirections)} ::: {new string(colDirections)}";
	}
}
