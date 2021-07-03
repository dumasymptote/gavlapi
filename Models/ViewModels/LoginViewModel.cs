using System.ComponentModel.DataAnnotations;

namespace gavl_api.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username {get;set;}
        [Required]
        public string Password {get;set;}
        public bool RememberMe {get;set;}
        public string ReturnUrl {get;set;}
    }
}
