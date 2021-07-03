using Microsoft.AspNetCore.Identity.EntityFrameworkCore;  
using Microsoft.EntityFrameworkCore;  
using gavl_api.Models;

namespace gavl_api.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public  DbSet<Account> Accounts {get;set;}
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
                    MailingPostal = "12345",
                    LicensedUsers= 11});
        }
    }
}