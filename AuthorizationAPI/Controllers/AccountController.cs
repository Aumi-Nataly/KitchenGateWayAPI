using AuthorizationAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthorizationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager; //для управления пользователями (создание, поиск, удаление пользователя)
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JWTSettings _options;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<IdentityUser> user, SignInManager<IdentityUser> signIn, IOptions<JWTSettings> optAccess, ILogger<AccountController> logger)
        {
            _userManager = user;
            _signInManager = signIn;
            _options = optAccess.Value;
            _logger = logger;
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="Credentials"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] OtherParamUser paramUser)
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
                _logger.LogError("контроллер AccountController метод Register {numberError}", "ошибка создания пользователя");
                return Errors(result);
            }

            _logger.LogInformation("Создан новый пользователь");

            return Ok();

        }


        /// <summary>
        /// Вход в систему пользователей и выдача токена
        /// </summary>
        /// <param name="Credentials"></param>
        /// <returns></returns>
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] ParamUser paramUser)
        {
            //Получить всю инфу по пользователю
            var user = await _userManager.FindByEmailAsync(paramUser.Email);

            var result = await _signInManager.PasswordSignInAsync(user, paramUser.Password, false, false);
          
            if (result.Succeeded)
            {
  
            IEnumerable<Claim> claims = await _userManager.GetClaimsAsync(user);
            var token = GetToken(user, claims);

                return Ok(token);
            }
            
            _logger.LogError("контроллер AccountController метод Register {numberError}", "ошибка создания пользователя");
            return BadRequest();
        }

        /// <summary>
        /// Созание токена по данным пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <param name="prinicpal"></param>
        /// <returns></returns>
        private string GetToken(IdentityUser user, IEnumerable<Claim> prinicpal)
        {

            var claims = prinicpal.ToList();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

            var jwt = new JwtSecurityToken(
                        issuer: _options.Issuer,
                        audience: _options.Audience,
                        claims: claims, 
                        expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
                        notBefore: DateTime.UtcNow,
                        signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
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
