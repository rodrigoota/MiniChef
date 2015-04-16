using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChef.Model
{
    public class ItemIngredienteModel
    {
        public int id { get; set; }
        public int idReceita { get; set; }
        public int idIngrediente { get; set; }
        public double quantidade { get; set; }
        public string unidadeMedida { get; set; }
    }
}
