using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Models
{
    public class PaymentModel
    {
        [Key]
        public int PaymentId { get;set ;}
        [ForeignKey("Order")]
        public int OrderId { get;set; }
        public decimal Amount { get;set ;}
        public string PaymentMethod { get;set; }
        public string PaymentStatus { get;set; }
        public DateOnly PaymentDate { get;set; }
    }
}