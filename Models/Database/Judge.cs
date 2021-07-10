using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace gavl_api.Models
{
    public class Judge
    {
        [Key]
        public int Id {get;set;}
        public string Name {get;set;}
        public Court Court {get;set;}
        public CourtSystem CourtSystem {get;set;}
        public IEnumerable<Case> Cases {get;set;}
    }
}