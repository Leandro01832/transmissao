using business.Classes;
using business.Classes.Abstrato;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioEF
{
   public class DB : DbContext
    {
        public DB() : base("DefaultConnection")
        {
            // Database.SetInitializer<DB>(null);
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioNormal> UsuarioNormal { get; set; }
        public DbSet<UsuarioBloqueado> UsuarioBloqueado { get; set; }
        public DbSet<UsuarioSilenciado> UsuarioSilenciado { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }
}
