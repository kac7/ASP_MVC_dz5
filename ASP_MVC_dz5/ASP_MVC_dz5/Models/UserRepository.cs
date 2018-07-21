using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_MVC_dz5.Models
{
    public class UserRepository : IRepository<User>
    {
        private static UserRepository _instanse;
        public static UserRepository Instanse => _instanse ?? (_instanse = new UserRepository());
        private UserRepository() { }

        public List<User> _user = new List<User>();
        public int Count { get; set; } = 0;
        public void Add(User item)
        {
            _user.Add(item);
        }
        public bool Delete(int id) => _user.Remove(Get(id));
        public User Get(int id) => _user.Find(user => user.Id == id);
    }
}