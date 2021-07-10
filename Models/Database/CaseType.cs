using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace gavl_api.Models
{
    public class CaseType
    {
        [Key]
        public int Id {get;set;}
        public string Name {get;set;}        
    }
}