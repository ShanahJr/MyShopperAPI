﻿using System;
using System.Collections.Generic;

namespace MyShopperAPI.Models
{
    public partial class Category
    {
        //public Category()
        //{
        //    ProductCategory = new HashSet<ProductCategory>();
        //}

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

       // public virtual ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
