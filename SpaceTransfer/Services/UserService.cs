using System.Collections.Generic;
using SpaceTransfer.Db.Models;
using SpaceTransfer.Services.Interfaces;

namespace SpaceTransfer.Services
{
	public class UserService: IUserService
	{
		public User Authenticate(string username, string password)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<User> GetAll()
		{
			throw new System.NotImplementedException();
		}

		public User GetById(int id)
		{
			throw new System.NotImplementedException();
		}

		public User Create(User user, string password)
		{
			throw new System.NotImplementedException();
		}

		public void Update(User user, string password = null)
		{
			throw new System.NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}