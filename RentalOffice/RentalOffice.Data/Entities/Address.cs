using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace RentalOffice.Data.Entities
{
    [Table("Addresses")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }

        public string Region { get; set; }

        public int? Postcode { get; set; }

        public string City { get; set; }
       
        public string Street { get; set; }
       
        public string Building { get; set; }

        public int? Apartment { get; set; }

    }
}