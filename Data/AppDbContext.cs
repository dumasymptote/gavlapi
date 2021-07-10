using Microsoft.AspNetCore.Identity.EntityFrameworkCore;  
using Microsoft.EntityFrameworkCore;  
using gavl_api.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

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
            //INPUT TWO USERS THAT WERE CREATED MANUALLY 
            builder.Entity<AppUser>().HasData(
                new List<AppUser>{
                    new AppUser{
                        Id = "084def53-e5c5-4aad-b697-c657ac9717dd",
                        FirstName = "Mark",
                        LastName = "Guthrie",
                        UserName = "mguthriejr",
                        Email = "mguthriejr@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAEL4mOE5fWV4RQ7Udf568CMQRkUAV/CCv8jUSewKe8hxZGwRs5z+xFiL8oMGUJ0llwA==",
                        SecurityStamp = "HM33DR554OCFBFOZRYNWMZQGT5SYIELF",
                        ConcurrencyStamp = "e2f78592-86c4-4328-9043-3cd670c294f8"
                    },
                    new AppUser{
                        Id = "12299889-4137-4345-841c-b53056db16cb",
                        FirstName = "Test",
                        LastName = "Admin",
                        UserName = "admin",
                        Email = "admin@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELnTSv+fvA/fDHoafJiTHr/Elw7Xyt89IafjWsKHSV/BHuklfmdV+vQ1EjsuaRckZQ==",
                        SecurityStamp = "54VISVHGT2EJZUJSVSU7JY7KYQH5XJJV",
                        ConcurrencyStamp = "00b93e2b-c35c-4529-b151-fe7139272444"
                    }
                }
            );
            //seed some roles that we will assign to these users
            builder.Entity<IdentityRole>().HasData(new List<IdentityRole>{
                new IdentityRole{
                    Id = "f9d801db-9aaa-492a-a688-8e6054b3b0e7",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "b87beccb-7509-4f3e-98bc-bf4af14e44ca"
                },
                new IdentityRole{
                    Id = "df2ac2b5-bc8f-4324-abde-ce16f6855920",
                    Name = "BusinessAdmin",
                    NormalizedName = "BUSINESSADMIN",
                    ConcurrencyStamp = "cfa6f680-c428-46fc-bf92-90dde197f9b4"
               },
               new IdentityRole{
                    Id = "91a39665-e584-4267-ba8f-e42d8447e16d",
                    Name = "BusinessUser",
                    NormalizedName = "BUSINESSUSER",
                    ConcurrencyStamp = "5c026a41-490f-4acd-921d-2ce44058e197"
                }
            });
            //seed roles to users - admin has only admin other user has admin and business admin
            builder.Entity<IdentityUserRole<string>>().HasData(new List<IdentityUserRole<string>>{
                new IdentityUserRole<string>{
                    RoleId= "f9d801db-9aaa-492a-a688-8e6054b3b0e7",
                    UserId="12299889-4137-4345-841c-b53056db16cb"
                },
                new IdentityUserRole<string>{
                    RoleId= "f9d801db-9aaa-492a-a688-8e6054b3b0e7",
                    UserId="084def53-e5c5-4aad-b697-c657ac9717dd"
                },
                new IdentityUserRole<string>{
                    RoleId= "df2ac2b5-bc8f-4324-abde-ce16f6855920",
                    UserId="084def53-e5c5-4aad-b697-c657ac9717dd"
                }
            });

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