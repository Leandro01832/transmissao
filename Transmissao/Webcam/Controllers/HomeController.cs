using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RepositorioEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webcam.Models;

namespace Webcam.Controllers
{
    public class HomeController : Controller
    {
        private DB db = new DB();
        private ApplicationDbContext banco = new ApplicationDbContext();

        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Index(string email)
        {
            var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(banco));
            var users = usermaneger.Users.ToList();
            var user = users.FirstOrDefault(u => u.UserName == User.Identity.GetUserName());

            var usuario = db.Usuario.First(u => u.Email == user.UserName);

            ViewBag.email = email;

            if (email == usuario.Email)
                ViewBag.condicao = true;
            else
                ViewBag.condicao = false;

            return View(usuario);
        }

        [Authorize]
        public ActionResult MinhaSala(string email)
        {
            var arr = email.Replace(" ", "").Split(',');

            if (arr[0] == arr[1])
                ViewBag.condicao2 = true;
            else
                ViewBag.condicao2 = false;

            var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(banco));
            var users = usermaneger.Users.ToList();
            var user = users.FirstOrDefault(u => u.UserName == User.Identity.GetUserName());

            var usuario = db.Usuario.First(u => u.Email == user.UserName);

            return PartialView(usuario);
        }
    }
}