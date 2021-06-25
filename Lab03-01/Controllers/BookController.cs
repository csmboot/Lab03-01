using Lab03_01.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab03_01.Controllers
{
    public class BookController : Controller
    {
        
        // GET: Book
        public ActionResult ListBook()
        {
            BookManagerContext context = new BookManagerContext();
            var listBook = context.Books.ToList();
            return View(listBook);
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            //[Bind(Include = "ID,Title,Description,Author,Images,Price")] 
            BookManagerContext context = new BookManagerContext();
        //    List<Book> listBook = context.Books.ToList();
            if (ModelState.IsValid)
            {
                context.Books.AddOrUpdate(book);
                context.SaveChanges();

            }
            return RedirectToAction("ListBook");
        }

        /*
         done, Dạ e cảm ơn

         */

        public ActionResult Edit(int? id)
        {
            BookManagerContext con = new BookManagerContext();
            //List<Book> listBook = con.Books.ToList();
            Book book = con.Books.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View();
        }
        [Authorize]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            BookManagerContext con = new BookManagerContext();
            //List<Book> listBook = con.Books.ToList();
            if (ModelState.IsValid)
            {
                con.Books.AddOrUpdate(book);
                con.SaveChanges();

            }
            return RedirectToAction("ListBook");
        }
        public ActionResult Delete(int? id)
        {
            BookManagerContext con = new BookManagerContext();
            List<Book> listBook = con.Books.ToList();
            Book book = con.Books.Find(id);

            if (id == null)
            {
                return new HttpStatusCodeResult(BookManagerContext.BadRequest);
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            BookManagerContext con = new BookManagerContext();
            List<Book> listBook = con.Books.ToList();
            Book book = con.Books.Find(id);
            if (ModelState.IsValid)
            {
                con.Books.Remove(book);
                con.SaveChanges();
            }    
            return RedirectToAction("ListBook", listBook);
        }
    }
}