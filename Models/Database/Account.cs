using System.ComponentModel.DataAnnotations;

namespace gavl_api.Models
{
    public class Account
    {
        [Key]
        public int Id {get;set;}
        [Required]
        [MaxLength(200)]
        public string Name {get;set;}
        [MaxLength(200)]
        public string MailingAddress {get;set;}
        [MaxLength(200)]
        public string MailingCity {get;set;}
        [MaxLength(3)]
        public string MailingState {get;set;}
        [MaxLength(9)]
        public string MailingPostal {get;set;}
        public int LicensedUsers {get;set;}
    }
}