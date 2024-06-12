using BookLibrary.Models;
using BookLibrary.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IDataHelper<Author> dataHelper;
        private Author author;
        public AuthorController(IDataHelper<Author> dataHelper)
        {
            this.dataHelper = dataHelper;
        }

        // GET: AuthorController
        public ActionResult Index()
        {
            return View(dataHelper.GetData());
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            author = dataHelper.Find(id);
            return View(author);
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author collection)
        {
            try
            {
                dataHelper.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            author = dataHelper.Find(id);
            return View(author);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Author collection)
        {
            try
            {
                dataHelper.Edite(id,collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            author = dataHelper.Find(id);
            return View(author);
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Author collection)
        {
            try
            {
                dataHelper.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
