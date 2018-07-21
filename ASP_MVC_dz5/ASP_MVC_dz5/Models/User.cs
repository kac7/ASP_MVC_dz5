using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_MVC_dz5.Models
{
    public class User
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Display(Name = "Логин")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The length of the log-in must be from 3 to 20 characters")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The length of the Password must be between 3 and 20 characters")]
        public string Password { get; set; }

        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Display(Name = "Телефон")]
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^(\s*)?(\+)?([-_():= +]?\d[-_():= +]?){10,14}(\s*)?$", ErrorMessage = "Invalid phone address")]
        public string Phone { get; set; }

        [Display(Name = "Роль")]
        [Required]
        [DataType(DataType.Text)]
        public Role Role { get; set; }
        //public Role Role = new Role();
        public User()
        {
            Role = new Role();
        }
    }
}