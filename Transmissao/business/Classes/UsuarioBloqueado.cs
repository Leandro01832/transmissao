using business.Classes.Abstrato;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Classes
{
    [Table("UsuarioBloqueado")]
   public class UsuarioBloqueado : Usuario
    {
        public int Usuario_ { get; set; }
        [ForeignKey("Usuario_")]
        public virtual Usuario Usuario { get; set; }

        public override string alterar(int id)
        {
            throw new NotImplementedException();
        }

        public override string excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override List<modelocrud> recuperar(int? id)
        {
            throw new NotImplementedException();
        }

        public override string salvar()
        {
            throw new NotImplementedException();
        }
    }
}
