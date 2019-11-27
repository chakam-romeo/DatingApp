using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set;}
        [Required]
        [StringLength(10,MinimumLength =4, ErrorMessage="Erreur longeur doit être >4")]
        public string Password { get; set;}
    }
}