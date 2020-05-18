using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Rasky.API.IdentityDb {
    public class AppUserDbContext : IdentityDbContext<AppUser> {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql ("Server=localhost;database=IdentityDb;Uid=testuser;Pwd=testpassword");
        }
        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
            builder.Entity<Address>().HasKey(x=>new {x.Longitude,x.Latitude});
            builder.Entity<Ride>().HasOne(x=>x.FromAddress);
            builder.Entity<Ride>().HasOne(x=>x.ToAddress);
        }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Address> Addresses{get;set;}
        public DbSet<UserProfile> Profiles { get; set; }
    }
}