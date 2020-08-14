using System;
using System.Collections.Generic;

namespace MyShopperAPI.Models
{
    public partial class MainStoreStore
    {
        public int MainStoreStoreId { get; set; }
        public int StoreId { get; set; }
        public int MainStoreId { get; set; }

        //public virtual MainStore MainStore { get; set; }
        //public virtual Store Store { get; set; }
    }
}
