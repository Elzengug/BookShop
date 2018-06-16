using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Core.Models.Base;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.Core.Models.Authorization
{
    public class UserRole : IdentityUserRole
    { 
        public User User { get; set; }
           
        public Role Role { get; set; }
    }
}
