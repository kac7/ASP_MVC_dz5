using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_dz5.Models;

namespace ASP_MVC_dz5.Controllers
{
    public class AuthorController : Controller
    {
        IRepository<Author> author = AuthorRepository.Instanse;
        // GET: Author
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Author value)
        {
            var similarNames = AuthorRepository.Instanse._authors.Find(a => a.Name == value.Name);
            if (similarNames == null)
            {
                value.Id = AuthorRepository.Instanse.Count++;
                author.Add(value);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.HtmlStr = $"Имя {similarNames.Name} уже существует";
                return View();
            }

        }
        public ActionResult Edit(int id)
        {
            var authors = AuthorRepository.Instanse._authors.Find(author => author.Id == id);
            return View(authors);
        }
        [HttpPost]
        public ActionResult Edit(int id, Author value)
        {
            var similarNames = AuthorRepository.Instanse._authors.Find(a => a.Name == value.Name);
            if (similarNames == null || author.Get(id).Name == value.Name)
            {
                author.Get(id).Name = value.Name;
                author.Get(id).DateOfBirth = value.DateOfBirth;
                author.Get(id).DateOfDeath = value.DateOfDeath;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.newauthor = author.Get(id);
                ViewBag.HtmlStr = $"Имя {similarNames.Name} уже существует";
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            foreach (var item in BookRepository.Instanse._books)
            {
                item.DeleteAuthor(id);
            }
            author.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var authors = AuthorRepository.Instanse._authors.Find(author => author.Id == id);
            return View(authors);
        }
    }
}