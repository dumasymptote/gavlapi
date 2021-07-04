using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace gavl_api.Models
{
    public class Client
    {
        [Key]
        public int Id {get;set;}
        [Required]
        [MaxLength(200)]
        public string FirstName {get;set;}
        [Required]
        [MaxLength(200)]
        public string LastName {get;set;}
        public string OrganizationName {get;set;}
        [Required]
        public DateTime DateOfBirth {get;set;}
        [Required]
        public int SSNFEIN {get;set;}
        [MaxLength(200)]
        public string MailingAddress {get;set;}
        [MaxLength(200)]
        public string MailingAddressLine2 {get;set;}
        [MaxLength(200)]
        public string MailingCity {get;set;}
        [MaxLength(3)]
        public string MailingState {get;set;}
        [MaxLength(9)]
        public string MailingPostalCode {get;set;}
        [MaxLength(200)]
        public string PhysicalAddress {get;set;}
        [MaxLength(200)]
        public string PhysicalAddressLine2 {get;set;}
        [MaxLength(200)]
        public string PhysicalCity {get;set;}
        [MaxLength(3)]
        public string PhysicalState {get;set;}
        [MaxLength(9)]
        public string PhysicalPostalCode {get;set;}
        public string Email {get;set;}
        [MaxLength(10)]
        public string PhoneNumber1 {get;set;}
        [MaxLength(10)]
        public string PhoneNumber2 {get;set;}
        public DateTime IntakeDate {get;set;}   
        public DateTime EngagmentDate {get;set;}
        public bool Active {get;set;}
        public Account Account {get;set;}
        public List<AppUser> AssignedUsers {get;set;}
    }
}