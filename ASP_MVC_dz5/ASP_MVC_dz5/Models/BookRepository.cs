using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_MVC_dz5.Models
{
    public class BookRepository : IRepository<Book>
    {
        private static BookRepository _instanse;
        public static BookRepository Instanse => _instanse ?? (_instanse = new BookRepository());
        private BookRepository() { }
        public List<Book> _books = new List<Book>();
        public int Count { get; set; } = 0;
        public void Add(Book item)
        {
            _books.Add(item);
        }
        public bool Delete(int id) => _books.Remove(Get(id));
        public Book Get(int id) => _books.Find(book => book.Id == id);
        public IEnumerable<Book> GetAll() => _books;
    }
}