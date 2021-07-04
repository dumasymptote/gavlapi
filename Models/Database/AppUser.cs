using Microsoft.AspNetCore.Identity;  
using System.Collections.Generic;

namespace gavl_api.Models  
{  
    public class AppUser : IdentityUser  
    {  
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public Account Account {get;set;}
        public List<Client> Clients {get; set;}
    }  
}  