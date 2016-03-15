using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalOffice.Model
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        [Display(Name = "Логин")]
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required]
        [DataType(DataType.Password)]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }

        [Display(Name = "Имя")]
        [Required, MaxLength(20)]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [Required, MaxLength(30)]
        public string Surname { get; set; }

        [Display(Name = "Электронная почта")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [MaxLength(30)]
        public string Email { get; set; }

        [Display(Name = "Контактный телефон:")]
        [RegularExpression(@"\d{3}-\d{3}-\d{2}-\d{2}")]
        [Required]
        public string Phone { get; set; }

        public int Role { get; set; }
    }
}
