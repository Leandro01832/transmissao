using business.Classes.Abstrato;
using RepositorioEF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Webcam.Models;
using business.Classes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Webcam
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DB, RepositorioEF.Migrations.Configuration>());
            ApplicationDbContext db = new ApplicationDbContext();            
            criarsuperuser(db);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private async void criarUsuario(DB banco)
        {
            banco.Usuario.Add(new UsuarioNormal
            {
                Email = "leandroleanleo@gmail.com",
                Nome = "Leandro Luis da Silva"
            });
            await banco.SaveChangesAsync();
        }

        private void criarsuperuser(ApplicationDbContext db)
        {
            var usermaneger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = usermaneger.FindByName("leandroleanleo@gmail.com");

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "leandroleanleo@gmail.com",
                    Email = "leandroleanleo@gmail.com"
                };

                usermaneger.Create(user, "Manequim1991");
            }

            DB banco = new DB();
            if (banco.Usuario.FirstOrDefault(u => u.Email == "leandroleanleo@gmail.com") == null)
              criarUsuario(banco);

        }
    }
}
