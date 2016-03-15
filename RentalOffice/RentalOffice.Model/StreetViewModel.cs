using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace RentalOffice.Model
{
    public class StreetViewModel
    {
        public int StreetId { get; set; }

        [Required]
        [Display(Name = "Улица")]
        public string StreetName { get; set; }  
    }
}
