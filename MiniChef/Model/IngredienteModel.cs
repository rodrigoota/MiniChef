using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChef.Model
{
    public class IngredienteModel
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public double quantidade { get; set; }
        public string unidadeMedida { get; set; }
    }
}
