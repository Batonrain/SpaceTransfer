using System;

namespace SpaceTransfer.Db.Entities
{
	public class Transfer
	{
		public long Id { get; set; }

		public string From { get; set; }
		public string To { get; set; }

		public decimal Amount { get; set; }

		public DateTime DepartureTime { get; set; }
		public DateTime? ArrivalTime { get; set; }

		public int FestivalId { get; set; }
		public Festival Festival { get; set; }
	}
}