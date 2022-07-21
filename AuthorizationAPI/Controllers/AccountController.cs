using AuthorizationAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace AuthorizationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager; //для управления пользователями (создание, поиск, удаление пользователя)
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JWTSettings _options;

        public AccountController(UserManager<IdentityUser> user, SignInManager<IdentityUser> signIn, IOptions<JWTSettings> optAccess)
        {
            _userManager = user;
            _signInManager = signIn;
            _options = optAccess.Value;

        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="Credentials"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] ParamUser paramUser)
        {
            var user = new IdentityUser { UserName = paramUser.UserName, Email = paramUser.Email };

            //Добавление пользователя в БД
            var result = await _userManager.CreateAsync(user, paramUser.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);


                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("Profession", paramUser.Profession.ToString()));
                claims.Add(new Claim("SeniorManager", paramUser.SeniorManager.ToString()));
                claims.Add(new Claim(ClaimTypes.Email, paramUser.Email));

                await _userManager.AddClaimsAsync(user, claims);

            }
            else
            {
                return Errors(result);
            }

            return Ok();

        }


        /// <summary>
        /// Ошибки при создании пользователя
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private JsonResult Errors(IdentityResult result)
        {
            var items = result.Errors
                .Select(x => x.Description)
                .ToArray();
            return new JsonResult(items) { StatusCode = 400 };
        }
    }
}
