using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace RentalOffice.Model
{
    public class SelectedItemShowModel
    {
        public int SelectedItemId { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; } 

        [Display(Name = "Наименование фильма")]
        public string ProductName { get; set; }

        [Display(Name = "Залоговая сумма: ")]
        [Required]
        public decimal Pledge { get; set; }

        [Display(Name = "Стоимость проката")]
        [Required]
        public decimal Price { get; set; }
    }
}
