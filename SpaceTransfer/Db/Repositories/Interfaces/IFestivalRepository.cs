using System.Collections.Generic;
using System.Threading.Tasks;
using SpaceTransfer.Db.Entities;

namespace SpaceTransfer.Db.Repositories.Interfaces
{
	public interface IFestivalRepository
	{
		Task<IEnumerable<Festival>> GetAll();
		Task<Festival> Get(long id);
		Task<long> Add(Festival festival);
		Task Update(Festival festival);
	}
}