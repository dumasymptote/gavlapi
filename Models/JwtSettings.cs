using System.ComponentModel.DataAnnotations;

namespace gavl_api.Models
{
    public class JwtSettings
    {
        public string Audience {get;set;}
        public string Issuer {get;set;}
        public string Secret {get;set;}
        public int ExpirationInDays{get;set;}
    }
}
