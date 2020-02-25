using System;
using System.Collections.Generic;
using System.Configuration;
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

        #region Add Movies

        public ActionResult AddMovies()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMovies(Movies movie)
        {
            try
            {
                Account account = new Account(
                    "zorn",
                    ConfigurationManager.AppSettings["CloudKey"],
                    ConfigurationManager.AppSettings["CloudSecret"]);

                Cloudinary cloudinary = new Cloudinary(account);
                cloudinary.Api.Timeout = 100000;

                var uploadParams = new VideoUploadParams()
                {
                    File = new FileDescription($@"{movie.Uri}"),
                    PublicId = $"Videos/Movies/{movie.Name}",
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

        #endregion


        #region Add Messages

        public ActionResult AddMessages()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMessages(Messages movie)
        {
            try
            {
                Account account = new Account(
                    "zorn",
                    ConfigurationManager.AppSettings["CloudKey"],
                    ConfigurationManager.AppSettings["CloudSecret"]);

                Cloudinary cloudinary = new Cloudinary(account);
                cloudinary.Api.Timeout = 100000;

                var uploadParams = new VideoUploadParams()
                {
                    File = new FileDescription($@"{movie.Uri}"),
                    PublicId = $"Videos//Messages/{movie.Topic}",
                    Tags = $"{movie.Topic}"
                };
                var uploadResult = cloudinary.UploadLarge(uploadParams);
                movie.Uri = uploadResult.Uri.ToString();

                var context = new ApplicationDbContext();
                context.Messages.Add(movie);
                context.SaveChanges();
                ViewBag.Success = "Movie Added Successfully";
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
            }

            return View();
        }

        #endregion

        public ActionResult Index()
        {
            return View();
        }


    }
}