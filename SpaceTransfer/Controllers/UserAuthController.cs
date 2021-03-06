using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SpaceTransfer.Db.Entities;
using SpaceTransfer.Helpers;
using SpaceTransfer.Models;
using SpaceTransfer.Services.Interfaces;

namespace SpaceTransfer.Controllers
{
	// [Authorize]
	[ApiController]
	[Route("[controller]")]
	public class UserAuthController : Controller
	{
		private IUserService _userService;
		private IMapper _mapper;
		private readonly AppSettings _appSettings;

		public UserAuthController(
			IUserService userService,
			IMapper mapper,
			IOptions<AppSettings> appSettings)
		{
			_userService = userService;
			_mapper = mapper;
			_appSettings = appSettings.Value;
		}

		[AllowAnonymous]
		[HttpPost("authenticate")]
		public IActionResult Authenticate([FromBody]AuthenticateModel model)
		{
			var user = _userService.Authenticate(model.Username, model.Password);

			if (user == null)
				return BadRequest(new { message = "Username or password is incorrect" });

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new []
				{
					new Claim(ClaimTypes.Name, user.Id.ToString())
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			var tokenString = tokenHandler.WriteToken(token);

			return Ok(new
			{
				Id = user.Id,
				Username = user.Username,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Token = tokenString
			});
		}

		[AllowAnonymous]
		[HttpPost("register")]
		public IActionResult Register([FromBody]RegisterModel model)
		{
			var user = _mapper.Map<User>(model);

			try
			{
				_userService.Create(user, model.Password);
				return Ok();
			}
			catch (AppException ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var users = await _userService.GetAll();
			// var model = _mapper.Map<IList<UserModel>>(users);
			return Ok(users);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var user = _userService.GetById(id);
			var model = _mapper.Map<UserModel>(user);
			return Ok(model);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody]UpdateModel model)
		{
			var user = _mapper.Map<User>(model);
			user.Id = id;

			try
			{
				_userService.Update(user, model.Password);
				return Ok();
			}
			catch (AppException ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_userService.Delete(id);
			return Ok();
		}
	}
}