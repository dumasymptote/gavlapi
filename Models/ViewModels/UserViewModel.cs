using System.ComponentModel.DataAnnotations;

namespace gavl_api.Models
{
    public class UserViewModel
    {
        [Required]
        public string Username {get;set;}
        [Required]
        public string Password {get;set;}
        public string Email {get; set;}
        public string PhoneNumber {get;set;}
    }
}
