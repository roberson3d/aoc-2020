using System;

namespace aoc2020
{
	struct TicketConversion
	{
		public int ConvertToSeat(Ticket ticket, out int row, out int col)
		{

			var bin = new string(ticket.rowDirections)
				.Replace('B', '1')
				.Replace('F', '0');
			row = Convert.ToInt32(bin, 2);

			bin = new string(ticket.colDirections)
				.Replace('R', '1')
				.Replace('L', '0');
			col = Convert.ToInt32(bin, 2);

			return row * 8 + col;
		}
	}
}
