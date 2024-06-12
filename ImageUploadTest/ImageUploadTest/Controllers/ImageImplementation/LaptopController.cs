using ImageUploadTest.Models.ImageImplementation;
using ImageUploadTest.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageUploadTest.Data;

namespace ImageUploadTest.Controllers.ImageImplementation
{
    public class LaptopController : Controller
    {
        private readonly ApplicationContext context;
        private readonly IWebHostEnvironment environment;

        public LaptopController(ApplicationContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            var data = context.Laptops.ToList();
            return View(data);
        }

        public IActionResult AddLaptop()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddLaptop(Laptop model)
        {
            try
            {
                string uniqueFileName = string.Empty;
                if (model.ImagePath != null)
                {
                    string uploadFolder = Path.Combine(environment.WebRootPath, "Content/Laptop/");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePath.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImagePath.CopyTo(fileStream);
                    }
                }

                var data = new Laptop()
                {
                    Brand = model.Brand,
                    Description = model.Description,
                    Path = uniqueFileName
                };
                context.Laptops.Add(data);
                context.SaveChanges();
                TempData["Success"] = "Record Successfully saved!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }



        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var data = context.Laptops.Where(e => e.Id == id).SingleOrDefault();
                if (data != null)
                {
                    string deleteFromFolder = Path.Combine(environment.WebRootPath, "Content/Laptop/");
                    string currentImage = Path.Combine(Directory.GetCurrentDirectory(), deleteFromFolder, data.Path);
                    if (currentImage != null)
                    {
                        if (System.IO.File.Exists(currentImage))
                        {
                            System.IO.File.Delete(currentImage);
                        }
                    }
                    context.Laptops.Remove(data);
                    context.SaveChanges();
                    TempData["Success"] = "Record Deleted!";
                }
            }
            return RedirectToAction("Index");
        }

       

        
   
    } 
}