using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Web.Mvc;
using E_Commerce.Models;

namespace E_Commerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin


        public ActionResult AdminHome()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminHome(Movies movie)
        {
            try
            {
                Account account = new Account(
                    "zorn",
                    "834965577395824",
                    "uctoPzHnQMZdz_A-MYWp2YLxhVk");

                Cloudinary cloudinary = new Cloudinary(account);
                cloudinary.Api.Timeout = 100000;

                var uploadParams = new VideoUploadParams()
                {
                    File = new FileDescription($@"{movie.Uri}"),
                    PublicId = $"Videos/{movie.Name}",
                    Tags = $"{movie.Name}"
                };
                var uploadResult = cloudinary.UploadLarge(uploadParams);
                movie.Uri = uploadResult.Uri.ToString();

                var context = new ApplicationDbContext();
                context.Movies.Add(movie);
                context.SaveChanges();
                ViewBag.Success = "Movie Added Successfully";
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
            }

            return View();
        }

        public ActionResult Index()
        {
            return RedirectToRoute("AdminHome");
        }
    }
}