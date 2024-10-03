using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodWagon.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FoodWagon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupsController : ControllerBase
    {
        private readonly SignupContext _context;
        private readonly IConfiguration _configuration;

        public SignupsController(SignupContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //public SignupsController(SignupContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Signups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Signup>>> GetSignup()
        {
            return await _context.Signup.ToListAsync();
        }

        // GET: api/Signups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Signup>> GetSignup(int id)
        {
            var signup = await _context.Signup.FindAsync(id);

            if (signup == null)
            {
                return NotFound();
            }

            return signup;
        }

        // PUT: api/Signups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSignup(int id, Signup signup)
        {
            if (id != signup.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(signup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignupExists(id))
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

        // POST: api/Signups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Signup>> PostSignup(Signup signup)
        {
            _context.Signup.Add(signup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SignupExists(signup.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSignup", new { id = signup.CustomerId }, signup);
        }

        // DELETE: api/Signups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSignup(int id)
        {
            var signup = await _context.Signup.FindAsync(id);
            if (signup == null)
            {
                return NotFound();
            }

            _context.Signup.Remove(signup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SignupExists(int id)
        {
            return _context.Signup.Any(e => e.CustomerId == id);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var user = _context.Signup.FirstOrDefault(x => x.EmailID == loginDTO.Email && x.Password == loginDTO.Password);
            if (user != null)
            {
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
