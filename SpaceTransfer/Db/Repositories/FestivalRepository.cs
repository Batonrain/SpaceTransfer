using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpaceTransfer.Db.Entities;
using SpaceTransfer.Db.Repositories.Interfaces;

namespace SpaceTransfer.Db.Repositories
{
	public class FestivalRepository : IFestivalRepository
	{
		private readonly ApplicationContext _context;

		public FestivalRepository(ApplicationContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Festival>> GetAll()
		{
			return await _context.Festivals.ToListAsync();
		}

		public async Task<Festival> Get(long id)
		{
			return await _context.Festivals.FindAsync(id);
		}

		public async Task<long> Add(Festival festival)
		{
			_context.Festivals.Add(festival);
			await _context.SaveChangesAsync();

			return festival.Id;
		}

		public async Task Update(Festival festival)
		{
			try
			{
				_context.Entry(festival).State = EntityState.Modified;

				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException exception)
			{
				await exception.Entries.Single().ReloadAsync();
				await _context.SaveChangesAsync();
			}
		}
	}
}