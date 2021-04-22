using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShopDbLibNew
{
      public enum Role
    {
        User, Admin
    }

    public interface IUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string Phone { get; set; }

    }
    public partial class User:IUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите имя ")]
        public string Name { get; set; }
         [Required(ErrorMessage = "Задайте пароль")]
        public string Password { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Укажите  телефон")]
        public string Phone { get; set; }
        public string Address { get; set; }
        [MaxLength(10)]
        [Required]
        public Role Role { get; set; }
    }
}
