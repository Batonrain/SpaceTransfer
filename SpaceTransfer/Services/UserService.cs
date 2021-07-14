using System.Collections.Generic;
using System.Threading.Tasks;
using SpaceTransfer.Db.Entities;
using SpaceTransfer.Db.Repositories.Interfaces;
using SpaceTransfer.Services.Interfaces;

namespace SpaceTransfer.Services
{
	public class UserService: IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public User Authenticate(string username, string password)
		{
			throw new System.NotImplementedException();
		}

		public async Task<IEnumerable<User>> GetAll()
		{
			return await _userRepository.GetAll();
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