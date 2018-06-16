using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Core.Models.Base
{
   public abstract class BaseEntity<TKey>
    {
        public virtual TKey Id { get; set; }
    }
}
