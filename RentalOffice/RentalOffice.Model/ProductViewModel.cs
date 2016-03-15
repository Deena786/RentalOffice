using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalOffice.Model
{
    public class ProductViewModel
    {        
        public int ProductId { get; set; }

        [Display(Name= "Название: ")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Залоговая сумма: ")]
        [Required]
        public decimal Pledge { get; set; }

        [Display(Name="Плата за прокат")]
        [Required]
        public decimal Price { get; set; }
        
        [Display(Name = "Категория: ")]
        [Required, MaxLength(50)]
        public string Category { get; set; }

        [Display(Name = "Краткое описание: ")]
        public string Description { get; set; }

        [Display(Name = "Год выхода: ")]
        [StringLength(16)]
        public string Released { get; set; }

        [Display(Name = "Киностудия(страна): ")]
        [StringLength(32)]
        public string Made { get; set; }

        [Display(Name = "Режисер: ")]
        [StringLength(32)]
        public string Producer { get; set; }

        [Display(Name = "В ролях: ")]
        [StringLength(256)]
        public string FilmStars { get; set; }

        [Display(Name = "Качество: ")]
        [StringLength(32)]
        public string Quality { get; set; }

        public string Image { get; set; }

        public string Availability { get; set; }
    }
}
