using System;
using System.Collections.Generic;

namespace MyShopperAPI.Models
{
    public partial class MainStore
    {
        public MainStore()
        {
            MainStoreStore = new HashSet<MainStoreStore>();
        }

        public int MainStoreId { get; set; }
        //public byte[] MainStoreLogo { get; set; }
        public string MainStoreName { get; set; }

        public virtual ICollection<MainStoreStore> MainStoreStore { get; set; }
    }
}
