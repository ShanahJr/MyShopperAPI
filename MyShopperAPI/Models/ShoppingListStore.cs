using System;
using System.Collections.Generic;

namespace MyShopperAPI.Models
{
    public partial class ShoppingListStore
    {
        public int ShoppingListStoreId { get; set; }
        public int ShoppingListId { get; set; }
        public int StoreId { get; set; }

        public virtual ShoppingList ShoppingList { get; set; }
        public virtual Store Store { get; set; }
    }
}
