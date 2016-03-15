using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace RentalOffice.Data.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }        

        [Required]
        public decimal Pledge { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required, MaxLength(50)]
        public string Category { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        [StringLength(16)]
        public string Released { get; set; }

        [StringLength(32)]
        public string Made { get; set; }

        [StringLength(32)]
        public string Producer { get; set; }

        [StringLength(256)]
        public string FilmStars  { get; set; }

        [StringLength(32)]
        public string Quality { get; set; }

        public string Image { get; set; }

        public string Availability { get; set; }
    }
}
