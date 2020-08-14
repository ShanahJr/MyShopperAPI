using System;
using System.Collections.Generic;

namespace MyShopperAPI.Models
{
    public partial class ShoppingListProduct
    {
        public int ShoppingListProductId { get; set; }
        public int ShoppingListId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public bool Checked { get; set; }

        public virtual Product Product { get; set; }
        public virtual ShoppingList ShoppingList { get; set; }
    }
}
