using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace gavl_api.Models
{
    public class Note
    {
        [Key]
        public int Id {get;set;}
        public AppUser User {get;set;}
        public Case Case {get;set;}
        public Client Client {get;set;}
        public string NoteText {get;set;}
        
    }
}