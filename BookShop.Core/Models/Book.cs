using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Core.Models.Base;

namespace BookShop.Core.Models
{
    public class Book : BaseEntity<int>
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string PublicationDate { get; set; }

        public ICollection<BookOrder> BookOrders { get; set; }
    }
}
