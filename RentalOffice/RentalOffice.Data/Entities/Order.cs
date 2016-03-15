using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalOffice.Data.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }        

        public IList<OrderItem> OrderItems { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
        
        public DateTime ReturnDate { get; set; }

        public decimal Payment { get; set; }
                
        public bool Execution { get; set; }
    }
}
