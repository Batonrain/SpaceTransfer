using System.Collections.Generic;

namespace SpaceTransfer.Db.Entities
{
	public class Festival
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public List<Transfer> Transfers { get; set; }
	}
}