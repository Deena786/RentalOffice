using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalOffice.Model
{
    public class OrderChangeViewModel
    {
        [Required]
        public int OrderId { get; set; }

        public IList<int> UserId { get; set; }        

        [Display(Name = "Фамилия и имя заказчика")]
        public IList<UserViewModel> User { get; set; }

        [Required]
        [Display(Name = "Заказанный фильм")]
        public IList<ProductViewModel> Products { get; set; }

        [Required]
        [Display(Name = "Дата заказа")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Дата доставки или выдачи")]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "")]
        public int AddressId { get; set; }

        [Display(Name = "Дата возврата")]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "Стоимость проката")]
        public decimal Payment { get; set; }
                
        [Display(Name = "Выполнение")]
        public bool Execution { get; set; }
    }
}
