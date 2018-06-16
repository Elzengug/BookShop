using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Core.Models.Base;


namespace BookShop.Core.Models
{
   public class BookOrder : BaseEntity<int>
    {
        public int BookId { get; set; }
        public int Count { get; set; }
        public int BasketId { get; set; }

        public  Basket Basket { get; set; }
        public Book Book { get; set; }
    }
}
