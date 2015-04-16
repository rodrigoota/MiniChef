using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChef.Model
{
    public class ReceitaModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public DateTime? data { get; set; }
        public List<IngredienteModel> ingredientes { get; set; }
        public int tempo { get; set; }
        public int nota { get; set; }
        public string categoria { get; set; }
        public List<CategoriaModel> categorias { get; set; }
        public string foto { get; set; }
    }
}
