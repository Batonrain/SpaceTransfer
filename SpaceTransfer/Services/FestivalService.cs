using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SpaceTransfer.Db.Entities;
using SpaceTransfer.Db.Repositories.Interfaces;
using SpaceTransfer.Models.Festival;
using SpaceTransfer.Services.Interfaces;

namespace SpaceTransfer.Services
{
	public class FestivalService : IFestivalService
	{
		private readonly IFestivalRepository _festivalRepository;
		private readonly IMapper _mapper;

		public FestivalService(IFestivalRepository festivalRepository, IMapper mapper)
		{
			_festivalRepository = festivalRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<FestivalViewModel>> GetAll()
		{
			var bugs = await _festivalRepository.GetAll();
			return _mapper.Map<IEnumerable<FestivalViewModel>>(bugs);
		}

		public async Task<FestivalViewModel> Get(long id)
		{
			var bug = await _festivalRepository.Get(id);
			return _mapper.Map<FestivalViewModel>(bug);
		}

		public async Task<long> Add(CreateFestivalModel model)
		{
			var bug = _mapper.Map<Festival>(model);
			return await _festivalRepository.Add(bug);
		}

		public async Task Update(int id, UpdateFestivalModel model)
		{
			var bug = _mapper.Map<Festival>(model);
			bug.Id = id;
			await _festivalRepository.Update(bug);
		}

		public void Archive(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}