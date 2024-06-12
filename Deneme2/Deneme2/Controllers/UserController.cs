using Deneme2.Models;
using Deneme2.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Deneme2.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> repository;

        public UserController( IRepository<User> repository)
        {
            this.repository = repository;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View(repository.GetData());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: UserController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                User user = new User
                {
                    Id = model.Id,
                    Name = model.Name
                };

                if (model.File != null && model.File.Length > 0)
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        model.File.CopyTo(stream);
                        user.image = stream.ToArray();
                    }
                }

                repository.Add(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while processing your request.");
                return View(model);
            }
        }
            // GET: UserController/Edit/5
            public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
