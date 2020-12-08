﻿namespace aoc2020
{
	partial class MainClass
	{
		public static void Main(string[] args)
		{
			IAOCProgram[] programs = new IAOCProgram[] {
				new Day01 (),
				new Day02 (),
				new Day03 (),
				new Day04 (),
				new Day05 (),
				new Day06 (),
				new Day07 ()
			};

			foreach (var program in programs) {
				program.Run();
			}
		}
	}
}