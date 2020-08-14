using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MyShopperAPI.Models
{
    public partial class MainStore
    {
        public MainStore()
        {
            // MainStoreStore = new HashSet<MainStoreStore>();
            Store = new HashSet<Store>();
        }

        [Key]
        public int MainStoreId { get; set; }
        public string ImageTitle { get; set; }
        public string MainStoreLogo { get; set; }
        public string MainStoreName { get; set; }

        public virtual ICollection<Store> Store { get; set; }
        //public virtual ICollection<MainStoreStore> MainStoreStore { get; set; }
    }
}
