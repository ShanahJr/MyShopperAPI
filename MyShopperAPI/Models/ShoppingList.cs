using System;
using System.Collections.Generic;

namespace MyShopperAPI.Models
{
    public partial class ShoppingList
    {
        public ShoppingList()
        {
            ShoppingListProduct = new HashSet<ShoppingListProduct>();
            ShoppingListStore = new HashSet<ShoppingListStore>();
        }

        public int ShoppingListId { get; set; }
        public string ShoppingListName { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<ShoppingListProduct> ShoppingListProduct { get; set; }
        public virtual ICollection<ShoppingListStore> ShoppingListStore { get; set; }
    }
}
