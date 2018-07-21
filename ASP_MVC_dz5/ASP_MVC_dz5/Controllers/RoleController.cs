using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_dz5.Models;

namespace ASP_MVC_dz5.Controllers
{
    public class RoleController : Controller
    {
        IRepository<Role> role = RoleRepository.Instanse;
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create( Role value)
        {
            if (ModelState.IsValid)
            {
                value.Id = RoleRepository.Instanse.Count++;
                role.Add(value);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            ViewBag.newRole = role.Get((int)id);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int? id, string Name)
        {
            if (ModelState.IsValid)
            {
                role.Get((int)id).Name = Name;
                return RedirectToAction("Index");
            }
            return View();
;        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            foreach (var item in UserRepository.Instanse._user)
            {
                if (item.Role.Name == role.Get((int)id).Name)
                {
                    item.Role.Clear();
                }
            }
            role.Delete((int)id);
            return RedirectToAction("Index");
        }
    }
}