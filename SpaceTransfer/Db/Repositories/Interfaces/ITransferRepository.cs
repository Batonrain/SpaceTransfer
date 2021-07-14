using System.Collections.Generic;
using System.Threading.Tasks;
using SpaceTransfer.Db.Entities;

namespace SpaceTransfer.Db.Repositories.Interfaces
{
	public interface ITransferRepository
	{
		Task<IEnumerable<Transfer>> GetAll();
		Task<Transfer> Get(long id);
		Task<long> Add(Transfer transfer);
		Task Update(Transfer transfer);
	}
}