using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using BookShop.Core.Models.Base;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.Core.Models.Authorization
{
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

       // public ICollection<UserRole> UserRoles { get; set; }
        public Basket Basket { get; set; }
    }
}
