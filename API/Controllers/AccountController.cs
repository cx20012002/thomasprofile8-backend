using API.DTOs;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;

        public AccountController(UserManager<User> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            if (loginDto == null) return BadRequest(new ProblemDetails { Title = "Invalid login details", Status = StatusCodes.Status400BadRequest });

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return NotFound(new ProblemDetails { Title = "User does not exist", Status = StatusCodes.Status404NotFound });

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return Unauthorized(new ProblemDetails { Title = "Invalid username or password", Status = StatusCodes.Status401Unauthorized });

            return Ok(new
            {
                Status = StatusCodes.Status200OK,
                UserName = user.UserName,
                Email = user.Email,
                Token = await _tokenService.GenerateToken(user)
            });
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (registerDto == null) return BadRequest("Invalid registration details");

            if (await _userManager.FindByEmailAsync(registerDto.Email) != null)
                return BadRequest(new ProblemDetails { Title = "Email already registered", Status = StatusCodes.Status400BadRequest });

            var user = new User { UserName = registerDto.UserName, Email = registerDto.Email };
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return ValidationProblem();
            }

            await _userManager.AddToRoleAsync(user, "Member");

            if (user == null) return BadRequest(new ProblemDetails { Title = "Failed to create user", Status = StatusCodes.Status400BadRequest });

            return CreatedAtAction(nameof(GetCurrentUser), new
            {
                Status = StatusCodes.Status201Created,
                UserName = user.UserName,
                Token = await _tokenService.GenerateToken(user)
            });
        }

        [Authorize]
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(string email)
        {
            if (string.IsNullOrEmpty(email)) return BadRequest("Email is required");

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return null;

            if (User.Identity?.Name != user.UserName && !User.IsInRole("Admin"))
                return Unauthorized("You can only delete your own account");

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return BadRequest("Failed to delete user");

            return Ok();
        }

        [Authorize]
        [HttpGet("currentUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<object>> GetCurrentUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            if (user == null) return NotFound();

            return Ok(new { user.UserName, user.Email });
        }

        //get user by email
        [HttpGet("getUserByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}