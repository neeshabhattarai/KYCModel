using FirstApplicationClass.Model.DTO;
using FirstApplicationClass.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FirstApplicationClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RegisterController : ControllerBase
    {
        private readonly UserManager<IdentityUser> manager;
        private readonly IToken token;

        public RegisterController(UserManager<IdentityUser> manager, IToken token)
        {
            this.manager = manager;
            this.token = token;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            var user = new IdentityUser
            {
                Email = registerDTO.Email,
                UserName = registerDTO.Email,

            };
            var result = await manager.CreateAsync(user,registerDTO.Password);
            if (result.Succeeded)
            {
                if (registerDTO.role != null && registerDTO.role.Any())
                {
                    var resultRole = await manager.AddToRolesAsync(user, registerDTO.role);
                    if (resultRole.Succeeded)
                    {
                        return Ok("User created");
                    }
                }
            }
            if (result.Errors.Any())
            {
                foreach (var errors in result.Errors)
                {
                    ModelState.AddModelError("", errors.Description);
                }
            }
                return BadRequest(result.Errors.ToString());
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] RegisterDTO registerDto)
        {
            var user=await manager.FindByEmailAsync(registerDto.Email);
            if (user != null)
            {
                var check = await manager.CheckPasswordAsync(user, registerDto.Password);
                if (check)
                {
                    var roles = await manager.GetRolesAsync(user);
                    var tokens =token.Create(user,roles);
                   return Ok(tokens);
                }

            }
            return BadRequest("UserName or Password Incorrect");
        }
    }
}
