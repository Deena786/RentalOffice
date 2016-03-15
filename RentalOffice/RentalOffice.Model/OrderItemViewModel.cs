using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalOffice.Model
{
    public class OrderItemViewModel
    {
        
        public int OrderItemId { get; set; }

        
        public int OrderId { get; set; }
       
        
        public int ProductId { get; set; }

       
        public string ProductName { get; set; }

        
        public decimal Pledge { get; set; }

        
        public decimal Price { get; set; }
    }
}
