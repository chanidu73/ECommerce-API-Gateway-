using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId {get;set; }
        public int UserId { get;set; }
        public DateTime OrderDate { get;set; }
        public decimal TotalAmount { get;set; }
        public string Status { get;set ;}
        public ICollection<OrderItemModel>OrderItems { get;set; }
        public PaymentModel Payment  {get;set; }
        
    }
}