using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.Models;
using BookLibrary.Models.Data;
using BookLibrary.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore;
using System.Runtime.Intrinsics.X86;
using System.Net;

namespace Bookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly IDataHelper<Book> bookRepository;
        private readonly IDataHelper<Author> authorRepository;
        private readonly IWebHostEnvironment hosting;
        public BookController(IDataHelper<Book> bookRepository,
            IDataHelper<Author> authorRepository,
            IWebHostEnvironment hosting)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
            this.hosting = hosting;
        }
        // GET: Book
        public ActionResult Index()
        {
            var books = bookRepository.GetData();
            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var book = bookRepository.Find(id);

            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            /* var model = new BookAuthorViewModel
             {
                 Authors = FillSelectList()
             };*/

            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorViewModel model)
        {

            try
            {
                string fileName = UploadImage(model.File, "uploads") ?? string.Empty;

                /* if (model.AuthorId == -1)
                 {
                     ViewBag.Message = "Please select an author from the list!";


                 }*/

                //  var authr = authorRepository.Find(model.AuthorId);
                Book book = new Book
                {
                    Id = model.Id,
                    Name = model.Title,
                    Description = model.Description,
                    ImageUrl = fileName,
                    AuthorNameList = model.AuthorNameList,
                    author = model.author,
                    AuthorId = authorRepository.GetData().Where(x => x.AuthorName == model.AuthorNameList).Select(x => x.Id).FirstOrDefault(),
                };

                bookRepository.Add(book);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookRepository.Find(id);
            // var authorId = book.author == null ? book.author.Id = 0 : book.author.Id;

            var viewModel = new BookAuthorViewModel
            {
                Id = book.Id,
                Title = book.Name,
                Description = book.Description,
                AuthorNameList = book.AuthorNameList,
                author = book.author,
                AuthorId = authorRepository.GetData().Where(x => x.AuthorName == book.AuthorNameList).Select(x => x.Id).FirstOrDefault(),
            };

            return View(viewModel);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookAuthorViewModel viewModel)
        {
            try
            {

                var book = bookRepository.Find(id);
                {
                    book.Id = viewModel.Id;
                    book.Name = viewModel.Title;
                    book.Description = viewModel.Description;
                    if (viewModel.File != null)
                    {
                        book.ImageUrl = UploadFile(viewModel.File, book.ImageUrl) ?? " ";
                    }
                    book.AuthorNameList = viewModel.AuthorNameList;
                    book.author = viewModel.author;
                    book.AuthorId = authorRepository.GetData().Where(x => x.AuthorName == viewModel.AuthorNameList).Select(x => x.Id).FirstOrDefault();
                };

                bookRepository.Edite(viewModel.Id, book);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookRepository.Find(id);

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Book model)
        {
            try
            {
                var book = bookRepository.Find(id);
                if (book == null)
                {
                    // Handle the case when the book is not found
                    return NotFound();
                }

                DeleteImage(book.ImageUrl);

                // Remove the book from the repository
                bookRepository.Remove(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                
                return View();
            }
        }

        public void DeleteImage(string imageUrl)
        {
            string uploadsFolder = Path.Combine(hosting.WebRootPath, "uploads");
            string imagePath = Path.Combine(uploadsFolder, imageUrl);

            // Delete the image file if it exists
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }


        List<Author> FillSelectList()
        {
            var authors = authorRepository.GetData().ToList();
            authors.Insert(0, new Author { Id = -1, AuthorName = "--- Please select an author ---" });

            return authors;
        }

        /* BookAuthorViewModel GetAllAuthors()
         {
             var vmodel = new BookAuthorViewModel
             {
                 Authors = FillSelectList()
             };

             return vmodel;
         }*/

        public string UploadImage(IFormFile file, string folder)
        {
            if (file != null)
            {
                string FileDir = Path.Combine(hosting.WebRootPath, folder);
                string fileName = Guid.NewGuid() + "-" + file.FileName;
                string fullpath = Path.Combine(FileDir, fileName);
                using (FileStream fileStream = new FileStream(fullpath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    return fileName;
                }
            }
            else
            {
                return string.Empty;
            }
        }
        public string UploadFile(IFormFile file, string imageUrl)
        {

            if (file != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, "uploads");
                string filname = Guid.NewGuid() + "-" + file.FileName;
                string newPath = Path.Combine(uploads, filname);
                string oldPath = Path.Combine(uploads, imageUrl);

                if (oldPath != newPath)
                {
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    file.CopyTo(new FileStream(newPath, FileMode.Create));
                }

                return filname;
            }

            return imageUrl;
        }
    
    }
}