using System.ComponentModel.DataAnnotations;

namespace AuthorizationAPI.Models
{
    /// <summary>
    /// Учетные данные пользователя
    /// </summary>
    public class ParamUser
    {
        
        public string UserName { get; set; }
       
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool SeniorManager { get; set; } = false;

        [Required]
        public enumProfession Profession { get; set; }

    }
}
