using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_MVC_dz5.Models
{
    public class AuthorRepository : IRepository<Author>
    {
        private static AuthorRepository _instanse;

        public static AuthorRepository Instanse => _instanse ?? (_instanse = new AuthorRepository());
        private AuthorRepository() { }
        public List<Author> _authors = new List<Author>();
        public int Count { get; set; } = 0;
        public void Add(Author item)
        {
            _authors.Add(item);
        }
        public bool Delete(int id) => _authors.Remove(Get(id));
        public Author Get(int id) => _authors.Find(author => author.Id == id);
        public IEnumerable<Author> GetAll() => _authors;

    }
}