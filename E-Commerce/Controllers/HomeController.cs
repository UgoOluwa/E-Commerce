using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Models;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Messages()
        {
            var context = new ApplicationDbContext();
            var messages = context.Messages;

            return View(messages);
        }

        [Authorize]
        public ActionResult Movies()
        {
            var context = new ApplicationDbContext();
            var Movies = context.Movies;

            return View((object)Movies);
        }

        [Authorize]
        public ActionResult WatchMovie(Movies movie)
        {

            return View(movie);
        }
        [Authorize]
        public ActionResult WatchMessage(Messages message)
        {

            return View(message);
        }
    }
}