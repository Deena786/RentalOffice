using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace RentalOffice.Model
{
    public class CityViewModel
    {
        public int СityId { get; set; }

        [Required]
        [Display(Name = "Город")]
        public string СityName { get; set; }
        
    }
}
