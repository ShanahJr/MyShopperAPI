using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShopperAPI.Models
{
    public partial class ProductPrice
    {
        public int ProductPriceId { get; set; }
        //[Key]
        //[ForeignKey("Product")]
        public int ProductId { get; set; }
        //[Key]
        //[ForeignKey("Price")]
        public int PriceId { get; set; }
        public DateTime PriceCreationDate { get; set; }

        //public virtual Price Price { get; set; }
        //public virtual Product Product { get; set; }
    }
}
