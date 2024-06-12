using Microsoft.AspNetCore.Mvc;
using ImageTest.Data;
using ImageTest.Model;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;
using ImageTest.Model.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace ImageTest.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IWebHostEnvironment webHost;

        public ProjectController(IWebHostEnvironment webHost)
        {
            this.webHost = webHost;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(ProjectModel model)
        {
            if (model.ImageFiles != null && model.ImageFiles.Count > 0)
            {
                // Save the image files
                var imagePath = Path.Combine(webHost.WebRootPath, "images");
                var imageNames = new List<string>();
                foreach (var imageFile in model.ImageFiles)
                {
                    if (imageFile.Length > 0)
                    {
                        var imageName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                        var imageFilePath = Path.Combine(imagePath, imageName);
                        using (var stream = new FileStream(imageFilePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(stream);
                        }
                        imageNames.Add(imageName);
                    }
                }

                // Save the code
                // You can save the code to a database or any other storage mechanism
                // Here, we'll just save it to a text file
                var codePath = Path.Combine(webHost.WebRootPath, "codes");
                var codeFileName = Guid.NewGuid().ToString() + ".txt";
                var codeFilePath = Path.Combine(codePath, codeFileName);
                System.IO.File.WriteAllText(codeFilePath, model.Code);

                // Redirect to a view to display the uploaded images and code
                return RedirectToAction("Uploaded", new { imageUrls = imageNames.Select(name => "/images/" + name), codeUrl = "/codes/" + codeFileName });
            }

            return View();
        }
    }
}