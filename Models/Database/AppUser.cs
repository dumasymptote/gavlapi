using Microsoft.AspNetCore.Identity;  
  
namespace gavl_api.Models  
{  
    public class AppUser : IdentityUser  
    {  
        public string FirstName {get;set;}
        public string LastName {get;set;}
    }  
}  