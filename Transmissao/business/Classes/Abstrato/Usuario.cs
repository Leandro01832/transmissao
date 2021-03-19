using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Classes.Abstrato
{
    [Table("Usuario")]
    public abstract class Usuario : modelocrud
    {
        public string Email { get; set; }
        public string Nome { get; set; }
    }
}
