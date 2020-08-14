using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyShopperAPI.Models
{
    public partial class ShoppingList
    {
        public ShoppingList()
        {
            ShoppingListProduct = new HashSet<ShoppingListProduct>();
            //ShoppingListStore = new HashSet<ShoppingListStore>();
        }

        [Key]
        public int ShoppingListId { get; set; }
        [Required]
        public string ShoppingListName { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public int StoreId { get; set; }

        public Store Store { get; set; }
        public virtual ICollection<ShoppingListProduct> ShoppingListProduct { get; set; }
        //public virtual ICollection<ShoppingListStore> ShoppingListStore { get; set; }
    }
}
