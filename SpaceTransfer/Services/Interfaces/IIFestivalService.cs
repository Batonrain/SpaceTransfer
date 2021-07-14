using System.Collections.Generic;
using System.Threading.Tasks;
using SpaceTransfer.Models.Festival;

namespace SpaceTransfer.Services.Interfaces
{
	public interface IFestivalService
	{
		Task<IEnumerable<FestivalViewModel>> GetAll();
		Task<FestivalViewModel> Get(long id);
		Task<long> Add(CreateFestivalModel model);
		Task Update(int id, UpdateFestivalModel model);
		void Archive(int id);
	}
}