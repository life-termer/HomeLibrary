using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeLibrary.DAL;
using HomeLibrary.Models;
using PagedList;

namespace HomeLibrary.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private BookContext db = new BookContext();

        // GET: Book
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (User.IsInRole("Admin"))
            {
                this.Session["userrole"] = "Admin";
            }
            else
                this.Session["userrole"] = "User";

            ViewBag.CurrentSort = sortOrder;
            /*The ViewBag variables are used so that the view can configure the column 
            heading hyperlinks with the appropriate query string values:*/
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.LenghtSortParam = sortOrder == "Lenght" ? "lenght_desc" : "Lenght";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
           
            ViewBag.CurrentFilter = searchString;
            var books = from s in db.Books
                           select s;
            //Add filtering functionality
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title.Contains(searchString)
                                       || s.Author.Contains(searchString));
            }
            //Add sorting functionality
            switch (sortOrder)
            {
                case "name_desc":
                    books = books.OrderByDescending(s => s.Title);
                    break;
                case "Lenght":
                    books = books.OrderBy(s => s.Length);
                    break;
                case "lenght_desc":
                    books = books.OrderByDescending(s => s.Length);
                    break;
                case "Date":
                    books = books.OrderBy(s => s.PublicDate);
                    break;
                case "date_desc":
                    books = books.OrderByDescending(s => s.PublicDate);
                    break;
                default:
                    books = books.OrderBy(s => s.Title);
                    break;
            }

            //Add paging functionality
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(books.ToPagedList(pageNumber, pageSize));

        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Author,Genre,Type,Language,PublicDate,Length,Description")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Author,Genre,Type,Language,PublicDate,Length,Description")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            IQueryable<BookTypeGorup> data = from book in db.Books
                                             group book by book.Type into typeBook
                                             select new BookTypeGorup()
                                             {
                                                 BookType = typeBook.Key,
                                                 BookCount = typeBook.Count()
                                             };
            return View(data.ToList());
        }
    }
}
