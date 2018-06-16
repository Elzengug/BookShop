using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using BookShop.Core.Models.Base;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.Core.Models.Authorization
{
    public class Role : IdentityRole
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
