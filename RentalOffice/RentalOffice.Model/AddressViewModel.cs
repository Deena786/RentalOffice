using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace RentalOffice.Model
{
    public class AddressViewModel
    {
        [Display(Name = "Область")]
        public string Region { get; set; }

        [Display(Name = "Индекс")]
        public int? Postcode { get; set; }
        
        [Display(Name="Город")]
        public string City { get; set; }

        [Display(Name = "Улица")]
        public string Street { get; set; }

        [Display(Name = "Дом")]
        public string Building { get; set; }

        [Display(Name = "Квартира")]
        public int? Apartment { get; set; }
    }
}
