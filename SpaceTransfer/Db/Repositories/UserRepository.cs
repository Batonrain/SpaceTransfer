using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpaceTransfer.Db.Entities;
using SpaceTransfer.Db.Repositories.Interfaces;

namespace SpaceTransfer.Db.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationContext _context;

		public UserRepository(ApplicationContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<User>> GetAll()
		{
			var qq = await _context.Users.ToListAsync();
			return await _context.Users.ToListAsync();
		}
	}
}