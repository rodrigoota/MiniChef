using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChef.Model
{
    public class ReceitaCategoriaModel
    {
        public int id { get; set; }
        public int idReceita { get; set; }
        public int idCategoria { get; set; }
        public int tipo { get; set; }
    }
}
