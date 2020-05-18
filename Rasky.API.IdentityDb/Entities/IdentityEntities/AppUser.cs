using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Rasky.API.IdentityDb {
    public class AppUser : IdentityUser, IEntity<AppUser> {
        [NotMapped]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber{get;set;}
        public bool IdNumberVerified{get;set;}
        public DateTime RegistedOn{get;set;}
        public virtual UserProfile Profile{get;set;}
        public AppUser AddErrors(object obj)
        {
            return this;
        }
    }
}