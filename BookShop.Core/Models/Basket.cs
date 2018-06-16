using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Core.Models.Authorization;
using BookShop.Core.Models.Base;

namespace BookShop.Core.Models
{
    public class Basket : BaseEntity<string>
    {
        [Key]
        [ForeignKey("User")]
        public override string Id { get; set; }

        public User User { get; set; }
        public ICollection<BookOrder> BookOrders { get; set; }
    }
}
