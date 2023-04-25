using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using CompanYoungAPI.Model;

namespace CompanYoungAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _configuration;

		public AuthController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		[HttpPost("token")]
		public IActionResult GetToken([FromBody] Credentials credentials)
		{
			// Validate credentials here (username, password, etc.)
			// This is just a simple example, so we skip validation

			var jwtSettings = _configuration.GetSection("JwtSettings");

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, credentials.Username),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.Name, credentials.Username),
				new Claim(ClaimTypes.Role, "admin")
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expires = DateTime.Now.AddDays(Convert.ToDouble(jwtSettings["ExpireDays"]));

			var token = new JwtSecurityToken(
				jwtSettings["Issuer"],
				jwtSettings["Audience"],
				claims,
				expires: expires,
				signingCredentials: creds
			);

			return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
		}

		private JsonWebKey GenerateJsonWebKey()
		{
			var jwtSettings = _configuration.GetSection("JwtSettings");
			var secretKey = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);

			var securityKey = new SymmetricSecurityKey(secretKey);
			var jsonWebKey = JsonWebKeyConverter.ConvertFromSymmetricSecurityKey(securityKey);

			jsonWebKey.Alg = SecurityAlgorithms.HmacSha256;
			jsonWebKey.Kid = "signing_key";
			jsonWebKey.Use = "sig"; // For signing

			return jsonWebKey;
		}

		[HttpGet(".well-known/jwks.json")]
		public IActionResult GetJwks()
		{
			var jsonWebKey = GenerateJsonWebKey();
			var jwks = new Dictionary<string, List<JsonWebKey>>
	{
		{ "keys", new List<JsonWebKey> { jsonWebKey } }
	};

			return Ok(jwks);
		}
	}
}
