using System;
using System.Collections.Generic;

namespace MyShopperAPI.Models
{
    public partial class Price
    {
        public Price()
        {
            ProductPrice = new HashSet<ProductPrice>();
        }

        public int PriceId { get; set; }
        public decimal Price1 { get; set; }
        public DateTime PriceCreationDate { get; set; }

        public virtual ICollection<ProductPrice> ProductPrice { get; set; }
    }
}
