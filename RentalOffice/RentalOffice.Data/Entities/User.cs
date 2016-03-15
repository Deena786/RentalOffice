using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace RentalOffice.Data.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        
        [Required, MaxLength(20)]
        public string Login { get; set; }
        
        [DataType(DataType.Password)]
        [Required, StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }
        
        [Required, MaxLength(20)]
        public string Name { get; set; }
        
        [Required, MaxLength(30)]
        public string Surname { get; set; }
             
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }                
        
        [RegularExpression(@"\d{3}-\d{3}-\d{2}-\d{2}")]
        public string Phone { get; set; }

        [Required]
        public Roles Role { get; set; }        
       
    }
}
