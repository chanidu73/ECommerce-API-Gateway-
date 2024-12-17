using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Models
{
    public class OrderItemModel
    {
        [Key]
        public int OrderItemId { get;set; }
        [ForeignKey("Order")]
        public int OrderId { get;set; }
        [ForeignKey("Product")]
        public int ProductId { get;set; }
        public string ProductName { get;set; }
        public int Quantity { get;set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice =>Quantity * UnitPrice ;
    }
}