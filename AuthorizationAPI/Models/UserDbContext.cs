using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationAPI.Models
{
    /// <summary>
    /// БД учетных записей пользователей
    /// </summary>
    public class UserDbContext : IdentityDbContext<IdentityUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }


    }
}
