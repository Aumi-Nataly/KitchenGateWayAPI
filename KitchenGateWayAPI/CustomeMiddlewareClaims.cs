using Ocelot.Middleware;
using System.Security.Claims;

namespace KitchenGateWayAPI
{
    /// <summary>
    /// Получение стандартных значений claim пользователя
    /// </summary>
    public class CustomeMiddlewareClaims : OcelotPipelineConfiguration
    {
        public CustomeMiddlewareClaims()
        {
            PreAuthorizationMiddleware = async (ctx, next) =>
            {

                await ProcessGetClaim(ctx.User, next);
            };
        }

        public async Task ProcessGetClaim(ClaimsPrincipal context, System.Func<Task> next)
        {
            var claims = new List<Claim>();
            var Profession = context.Claims.Where(x => x.Type.Contains("Profession")).FirstOrDefault()?.Value;
            var SeniorManager = context.Claims.Where(x => x.Type.Contains("SeniorManager")).FirstOrDefault()?.Value;

            if (!string.IsNullOrWhiteSpace(Profession))
            {
                claims.Add(new Claim("Profession", Profession));
            }

            if (!string.IsNullOrWhiteSpace(SeniorManager))
            {              
                claims.Add(new Claim("SeniorManager", SeniorManager));
            }

            context.AddIdentity(new ClaimsIdentity(claims));

            await next.Invoke();

        }
    }
}
