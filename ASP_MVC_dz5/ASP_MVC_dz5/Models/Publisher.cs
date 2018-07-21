using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_MVC_dz5.Models
{
    public class Publisher
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public void Clear()
        {
            Id = 0;
            Name = null;
        }
    }
}