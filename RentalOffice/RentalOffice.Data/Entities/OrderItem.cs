using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalOffice.Data.Entities
{
    [Table("OrderItems")]
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; }

        public int? OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public string ProductName { get; set; }
        
        public decimal Pledge { get; set; }
        
        public decimal Price { get; set; }
    }
}
