using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUploadTest.Controllers.PreviewImage
{
    public class PreviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
