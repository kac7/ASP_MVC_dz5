using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_dz5.Models;

namespace ASP_MVC_dz5.Controllers
{
    public class PublisherController : Controller
    {
        IRepository<Publisher> publisher = PublisherRepository.Instanse;
        // GET: Publisher
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create() => View();
        [HttpPost]
        public ActionResult Create(Publisher value)
        {
            value.Id = PublisherRepository.Instanse.Count++;
            publisher.Add(value);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null) { return RedirectToAction("Index"); }
            var publishers = PublisherRepository.Instanse._publishers.Find(p => p.Id == id);
            return View(publishers);
        }
        [HttpPost]
        public ActionResult Edit(int id, Publisher value)
        {
            publisher.Get(id).Name = value.Name;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            foreach (var item in BookRepository.Instanse._books)
            {
                if (item.Publisher.Name == publisher.Get(id).Name)
                {
                    item.Publisher.Clear();
                }
            }
            publisher.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var authors = PublisherRepository.Instanse._publishers.Find(author => author.Id == id);
            return View(authors);
        }
    }
}