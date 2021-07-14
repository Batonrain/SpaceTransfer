using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpaceTransfer.Db.Entities;
using SpaceTransfer.Db.Repositories.Interfaces;

namespace SpaceTransfer.Db.Repositories
{
	public class TransferRepository : ITransferRepository
	{
		private readonly ApplicationContext _context;

		public TransferRepository(ApplicationContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Transfer>> GetAll()
		{
			return await _context.Transfers.ToListAsync();
		}

		public async Task<Transfer> Get(long id)
		{
			return await _context.Transfers.FindAsync(id);
		}

		public async Task<long> Add(Transfer transfer)
		{
			_context.Transfers.Add(transfer);
			await _context.SaveChangesAsync();

			return transfer.Id;
		}

		public async Task Update(Transfer transfer)
		{
			try
			{
				_context.Entry(transfer).State = EntityState.Modified;

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