using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalOffice.Model
{
    public class UserRegistrViewModel
    {

        [Display(Name="Имя")]
        [Required]
        public string Name { get; set;}

        [Display(Name="Фамилия")]
        [Required]
        public string Surname{ get; set; }

        [Display(Name = "Логин")]
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }

        [Display(Name = "Повторить пароль")]
        [DataType(DataType.Password)]
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [StringLength(8, MinimumLength = 4)]
        public string PasswordConfirm { get; set; } 

        [Display(Name="Электронная почта")]
        [Required]        
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email{ get; set; }

       
        [Display(Name = "Телефон")]
        [Required, MaxLength(13)]
        public string Phone { get; set; }

        public int Role = 3;

        [Display(Name = "Как Вы узнали о нас?")]
        public string Advertisement { get; set; }
    }
}
