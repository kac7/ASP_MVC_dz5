using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_MVC_dz5.Models
{
    public class PublisherRepository : IRepository<Publisher>
    {
        private static PublisherRepository _instanse;
        public static PublisherRepository Instanse => _instanse ?? (_instanse = new PublisherRepository());
        private PublisherRepository() { }
        public List<Publisher> _publishers = new List<Publisher>();
        public int Count { get; set; } = 0;
        public void Add(Publisher item)
        {
            _publishers.Add(item);
        }
        public bool Delete(int id) => _publishers.Remove(Get(id));
        public Publisher Get(int id) => _publishers.Find(publisher => publisher.Id == id);
        public IEnumerable<Publisher> GetAll() => _publishers;
    }
}