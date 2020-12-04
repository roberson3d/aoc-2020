namespace aoc2020
{
	public struct Toboggan
	{
		public int Sled(in string[] map, Slope slope)
		{
			int trees = 0;
			for (int x = 0, y = 0; y < map.Length; x += slope.right, y += slope.down) {
				var plot = map[y][x % map[y].Length];

				var isTree = plot == '#';
				if (isTree) {
					trees++;
				}

				//Console.WriteLine($"{map[y]} ::: {(isTree ? trees.ToString() : ".")}   ({x.ToString()}, {y.ToString()})");
			}

			return trees;
		}
	}
}
