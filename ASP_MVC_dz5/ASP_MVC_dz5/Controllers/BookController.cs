using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_dz5.Models;

namespace ASP_MVC_dz5.Controllers
{
    public class BookController : Controller
    {
        IRepository<Book> book = BookRepository.Instanse;
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create() => View();
        [HttpPost]
        public ActionResult Create(Book value, string[] Authors)
        {
            value.Id = BookRepository.Instanse.Count++;
            foreach (var item in AuthorRepository.Instanse._authors)
            {
                if (Authors != null)
                {
                    foreach (var item2 in Authors)
                    {
                        if (item.Name == item2)
                        {
                            value.AddAuthor(item);
                            break;
                        }
                    }
                }
            }
            book.Add(value);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.newbook = book.Get(id);
            var authors = BookRepository.Instanse._books.Find(author => author.Id == id);
            return View(authors);
        }
        [HttpPost]
        public ActionResult Edit(int id, Book value, string[] Authors)
        {
            book.Get(id).Name = value.Name;
            book.Get(id).PageCount = value.PageCount;
            book.Get(id).ISBN = value.ISBN;
            book.Get(id).PublishDate = value.PublishDate;
            book.Get(id).Publisher = value.Publisher;

            book.Get(id).Authors = Enumerable.Empty<Author>();

            foreach (var item in AuthorRepository.Instanse._authors)
            {
                if (Authors != null)
                {
                    foreach (var item2 in Authors)
                    {
                        if (item.Name == item2)
                        {
                            book.Get(id).AddAuthor(item);
                            break;
                        }
                    }
                }
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            book.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var authors = BookRepository.Instanse._books.Find(author => author.Id == id);
            return View(authors);
        }
    }
}