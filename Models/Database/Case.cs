using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace gavl_api.Models
{
    public class Case
    {
        [Key]
        public int Id {get;set;}
        public CaseType CaseType {get;set;}
        public Client Client {get;set;}
        public Court Court {get;set;}
        public Judge Judge {get;set;}
        public IEnumerable<Note> CaseNotes {get;set;}
    }
}