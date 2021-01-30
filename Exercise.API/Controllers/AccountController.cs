using System.Threading.Tasks;
using AutoMapper;
using Exercise.Domain.CRUD.User;
using Exercise.Domain.Identity;
using Exercise.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exercise.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        
        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenService tokenService,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        // POST api/account
        [HttpPost("register")]
        public async Task<ActionResult<ReadUser>> Register(CreateUser createUser)
        {
            if (await _userManager.Users.AnyAsync(x => x.UserName == createUser.Username.ToLower()))
                return BadRequest("Username is taken");

            var user = _mapper.Map<AppUser>(createUser);

            user.UserName = createUser.Username.ToLower();

            var result = await _userManager.CreateAsync(user, createUser.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            return new ReadUser(user.UserName, await _tokenService.CreateToken(user));
        }

        // POST api/login
        [HttpPost("login")]
        public async Task<ActionResult<ReadUser>> Login(LoginUser loginUser)
        {
            var user = await _userManager.Users
                            .SingleOrDefaultAsync(x => x.UserName == loginUser.Username.ToLower());

            if (user == null) return Unauthorized("Invalid Username");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginUser.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }
            
            return new ReadUser(user.UserName, await _tokenService.CreateToken(user));
        }
    }
}