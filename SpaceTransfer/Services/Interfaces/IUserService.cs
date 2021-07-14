using System.Collections.Generic;
using System.Threading.Tasks;
using SpaceTransfer.Db.Entities;

namespace SpaceTransfer.Services.Interfaces
{
	public interface IUserService
	{
		User Authenticate(string username, string password);
		Task<IEnumerable<User>> GetAll();
		User GetById(int id);
		User Create(User user, string password);
		void Update(User user, string password = null);
		void Delete(int id);
	}
}