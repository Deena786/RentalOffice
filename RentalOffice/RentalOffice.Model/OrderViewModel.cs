using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalOffice.Model
{
    public class OrderViewModel
    {
        [Required]
        public int OrderId { get; set; }
        
        public int UserId { get; set; }
        
        [Display(Name = "Заказчик:")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Контактный телефон:")]
        [RegularExpression(@"\d{3}-\d{3}-\d{2}-\d{2}")]
        public string Phone { get; set; }

        [Display(Name = "Email:")]
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }        
        
        [Required]
        public List<OrderItemViewModel> OrderItems { get; set; } 
       
        [Display(Name="Дата заказа:")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Дата доставки / самовывоза:")]
        public DateTime DeliveryDate { get; set; }

        public int AddressId { get; set; }

        public AddressViewModel Address { get; set; }
       
        [Display(Name = "Планируемая дата возврата:")]
        public DateTime ReturnDate { get; set; }

        public decimal Payment { get; set; }

        public decimal Cost { get; set; }

        public bool Execution { get; set; }
    }
}
