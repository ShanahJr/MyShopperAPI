using System;
using System.Collections.Generic;

namespace MyShopperAPI.Models
{
    public partial class Store
    {
        public Store()
        {
            MainStoreStore = new HashSet<MainStoreStore>();
            ShoppingListStore = new HashSet<ShoppingListStore>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }
        public int? StoreRating { get; set; }

        public virtual ICollection<MainStoreStore> MainStoreStore { get; set; }
        public virtual ICollection<ShoppingListStore> ShoppingListStore { get; set; }
    }
}
