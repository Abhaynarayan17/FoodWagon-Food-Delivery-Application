using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodWagon.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace FoodWagon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterationsController : ControllerBase
    {
        private readonly RegisterationDetailcontext _context;
        private readonly IConfiguration _configuration;

        public RegisterationsController(RegisterationDetailcontext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Registerations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registeration>>> GetRegisteration()
        {
            return await _context.Registeration.ToListAsync();
        }

        // GET: api/Registerations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Registeration>> GetRegisteration(string id)
        {
            var registeration = await _context.Registeration.FindAsync(id);

            if (registeration == null)
            {
                return NotFound();
            }

            return registeration;
        }

        // PUT: api/Registerations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegisteration(string id, Registeration registeration)
        {
            if (id != registeration.EmailID)
            {
                return BadRequest();
            }

            _context.Entry(registeration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Registerations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Registeration>> PostRegisteration(Registeration registeration)
        {
            _context.Registeration.Add(registeration);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RegisterationExists(registeration.EmailID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRegisteration", new { id = registeration.EmailID }, registeration);
        }

        // DELETE: api/Registerations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegisteration(string id)
        {
            var registeration = await _context.Registeration.FindAsync(id);
            if (registeration == null)
            {
                return NotFound();
            }

            _context.Registeration.Remove(registeration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegisterationExists(string id)
        {
            return _context.Registeration.Any(e => e.EmailID == id);
        }



        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var user = _context.Registeration.FirstOrDefault(x => x.EmailID == loginDTO.Email && x.Password == loginDTO.Password);
            if (user != null) {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),

                    new Claim(JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString()),
                    new Claim("EmailID", user.EmailID.ToString()),
                    new Claim("Password", user.Password.ToString()),

                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                var token = new JwtSecurityToken(

                _configuration["Jwt:Issuer"],

                _configuration["Jwt:Audience"],

                claims,

                expires: DateTime.UtcNow.AddMinutes(60),

                signingCredentials: signIn

                );

                string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { Token = tokenValue, User = user });
            }
            return NoContent();
        }

    }
}

