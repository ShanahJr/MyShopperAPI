using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyShopperAPI.Models
{
    public partial class Product
    {
        public Product()
        {
            //ProductCategory = new HashSet<ProductCategory>();
           // ProductPrice = new HashSet<ProductPrice>();
            ShoppingListProduct = new HashSet<ShoppingListProduct>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPicture { get; set; }
        public int CategoryId { get; set; }
        [DataType(DataType.Currency)]
        public decimal CurrentPrice { get; set; }
        public DateTime PriceCreationDate { get; set; }

        // public virtual ICollection<ProductCategory> ProductCategory { get; set; }
        public Category Category { get; set; }
        //public virtual ICollection<ProductPrice> ProductPrice { get; set; }
        public virtual ICollection<ShoppingListProduct> ShoppingListProduct { get; set; }
    }
}
