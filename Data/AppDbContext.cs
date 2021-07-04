using Microsoft.AspNetCore.Identity.EntityFrameworkCore;  
using Microsoft.EntityFrameworkCore;  
using gavl_api.Models;
using System;

namespace gavl_api.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public  DbSet<Account> Accounts {get;set;}
        public DbSet<Client> Clients {get;set;}
        public AppDbContext(DbContextOptions<AppDbContext> options): base (options)
        {}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Account>().Property(p => p.LicensedUsers).HasDefaultValueSql("10") ;
            builder.Entity<Account>().HasData(
                new Account{
                    Id= 1, 
                    Name= "TestAccount1",
                    MailingAddress= "123 Main St",
                    MailingCity = "Cityopolis",
                    MailingState = "DC",
                    MailingPostalCode = "12345",
                    LicensedUsers= 11});
            builder.Entity<Client>().HasData(
                new Client{
                    Id = 1,
                    FirstName = "Test",
                    LastName = "Client",
                    OrganizationName = "Clients Against Testing",
                    DateOfBirth = DateTime.Today.AddYears(-30),
                    SSNFEIN = 111111111,
                    MailingAddress = "123 Test",
                    MailingAddressLine2 = "Suite 1",
                    MailingCity = "Testville",
                    MailingState = "TX",
                    MailingPostalCode = "76553",
                    PhysicalAddress = "123 Test",
                    PhysicalAddressLine2 = "Suite 1",
                    PhysicalCity = "Testville",
                    PhysicalState = "TX",
                    PhysicalPostalCode = "76553",
                    Email= "Test@example.com",
                    PhoneNumber1 = "2142129004",
                    PhoneNumber2 = "",
                    Active = true
                });
        }
    }
}