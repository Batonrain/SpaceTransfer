using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaceTransfer.Models.Festival;
using SpaceTransfer.Services.Interfaces;

namespace SpaceTransfer.Controllers
{
	public class Festival : Controller
	{
		private readonly IFestivalService _festivalService;

		public Festival(IFestivalService festivalService)
		{
			_festivalService = festivalService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _festivalService.GetAll();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(long id)
		{
			var result = await _festivalService.Get(id);

			if (result == null)
			{
				return NotFound();
			}

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateFestivalModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			return Ok(new {id = await _festivalService.Add(model)});
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody]UpdateFestivalModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			//todo добавить проверку на существование и архивацию фестиваля. Если существует и НЕ в архиве - давать возможностиь редактировать

			await _festivalService.Update(id, model);

			return Ok();
		}
	}
}