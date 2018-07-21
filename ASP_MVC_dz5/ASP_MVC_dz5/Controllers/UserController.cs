using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_dz5.Models;

namespace ASP_MVC_dz5.Controllers
{
    public class UserController : Controller
    {
        IRepository<User> user = UserRepository.Instanse;
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User value)
        {
            if (ModelState.IsValid)
            {
                value.Id = UserRepository.Instanse.Count++;
                user.Add(value);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int? id)
        {
            if (id == null) { return RedirectToAction("Index"); }

            var users = UserRepository.Instanse._user.Find(author => author.Id == id);
            return View(users);
        }
        [HttpPost]
        public ActionResult Edit(int? id, User value)
        {
            user.Get((int)id).FirstName = value.FirstName;
            user.Get((int)id).LastName = value.LastName;
            user.Get((int)id).Login = value.Login;
            user.Get((int)id).Password = value.Password;
            user.Get((int)id).Phone = value.Phone;
            user.Get((int)id).Email = value.Email;
            user.Get((int)id).Role.Name = value.Role.Name;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            user.Delete((int)id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var users = UserRepository.Instanse._user.Find(author => author.Id == id);
            return View(users);
        }
    }
}