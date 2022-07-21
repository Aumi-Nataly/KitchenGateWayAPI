using System.ComponentModel.DataAnnotations;

namespace AuthorizationAPI.Models
{
    /// <summary>
    /// Учетные данные пользователя
    /// </summary>
    public class ParamUser
    {

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

      

    }
}
