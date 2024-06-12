using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Core;
using MyFirstProject.Data;

namespace MyFirstProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IDataHelper<User> dataHelper;
        private User user;
        DBContext db;
        public UserController(IDataHelper<User> dataHelper)
        {
            this.dataHelper = dataHelper;
        }
      
        // GET: HomeController
        public ActionResult Index()
        {
            return View(dataHelper.GetData());
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            user = dataHelper.Find(id);
            return View(user);
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User collection)
        {
            try
            {
                db = new DBContext();
                dataHelper.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            user = dataHelper.Find(id);
            return View(user);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User collection)
        {
            try
            {
                db = new DBContext();
                dataHelper.Edit( id ,collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            user = dataHelper.Find(id);
            return View(user);
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User collection)
        {
            try
            {
                db = new DBContext();
                dataHelper.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
