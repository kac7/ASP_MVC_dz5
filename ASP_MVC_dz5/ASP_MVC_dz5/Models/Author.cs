using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_MVC_dz5.Models
{
    public class Author
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Display(Name = "Дата Рождения")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Дата Смерти")]
        [DataType(DataType.Date)]
        public DateTime DateOfDeath { get; set; }
    }
}