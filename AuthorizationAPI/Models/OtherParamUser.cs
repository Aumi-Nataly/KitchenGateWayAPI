using System.ComponentModel.DataAnnotations;

namespace AuthorizationAPI.Models
{
    /// <summary>
    /// Доп параметры при регистрации
    /// </summary>
    public class OtherParamUser: ParamUser
    {
        public string UserName { get; set; }
        public bool SeniorManager { get; set; } = false;

        [Required]
        public enumProfession Profession { get; set; }
    }
}
