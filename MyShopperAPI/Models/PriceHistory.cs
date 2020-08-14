using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopperAPI.Models
{
    public class PriceHistory
    {
        [Key]
        public int ProductHistoryId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
