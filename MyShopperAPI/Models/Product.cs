using System;
using System.Collections.Generic;

namespace MyShopperAPI.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductCategory = new HashSet<ProductCategory>();
            ProductPrice = new HashSet<ProductPrice>();
            ShoppingListProduct = new HashSet<ShoppingListProduct>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public byte[] ProductPicture { get; set; }

        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
        public virtual ICollection<ProductPrice> ProductPrice { get; set; }
        public virtual ICollection<ShoppingListProduct> ShoppingListProduct { get; set; }
    }
}
