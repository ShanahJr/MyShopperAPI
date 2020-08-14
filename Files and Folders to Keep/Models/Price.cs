using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyShopperAPI.Models
{
    public partial class Price
    {
        public Price()
        {
            //ProductPrice = new HashSet<ProductPrice>();
        }

        public int PriceId { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price1 { get; set; }
        

       // public virtual ICollection<ProductPrice> ProductPrice { get; set; }
    }
}
