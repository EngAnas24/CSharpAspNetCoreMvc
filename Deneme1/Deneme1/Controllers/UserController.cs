using Deneme1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Deneme1.Controllers
{

    public class UserController : Controller
    {
        DBData _users;
        public IActionResult Index()
        {
            return View(_users.Users.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _users.Users.Add(user);
                _users.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        public IActionResult Details(int id)
        {
            var user = _users.Users.ToList().FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult ToggleStatus(int id, bool isActive)
        {
            var user = _users.Users.ToList().FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            user.IsActive = isActive;

            return Ok(new { message = isActive ? "User activated successfully" : "User deactivated successfully" });
        }



    }
}
