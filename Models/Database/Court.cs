using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace gavl_api.Models
{
    public class Court
    {
        [Key]
        public int Id {get;set;}
        public string Name {get;set;}
        public Court SuperiorCourt {get;set;}
        public CourtSystem CourtSystem {get;set;}
    }
}