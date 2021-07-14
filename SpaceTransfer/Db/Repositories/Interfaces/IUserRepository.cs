using System.Collections.Generic;
using System.Threading.Tasks;
using SpaceTransfer.Db.Entities;

namespace SpaceTransfer.Db.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> GetAll();
	}
}