using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_MVC_dz5.Models
{
    public class Book
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Название")]
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Display(Name = "Кол-во страниц")]
        [Required]
        public int PageCount { get; set; }
        [Display(Name = "ISBN")]
        [Required]
        [DataType(DataType.Text)]
        public string ISBN { get; set; }
        [Display(Name = "Дата публикации")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        [Display(Name = "Издатель")]
        public Publisher Publisher { get; set; }
        [Display(Name = "Автор")]
        public IEnumerable<Author> Authors { get; set; }
        public void AddAuthor(Author author) {
            Authors = Authors.Add(author);
        }
        public void DeleteAuthor(int id)
        {
            Authors = Authors.Delete(id);
        }
        public Book()
        {
            Publisher = new Publisher();
        }
    }
}