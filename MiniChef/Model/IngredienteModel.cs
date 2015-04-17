using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChef.Model
{
    [Table(Name = "tbIngredientes")] 
    public class IngredienteModel
    {
        [Column(Name = "_Id", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int id { get; set; }

        [Column(Name = "_Descricao", CanBeNull = false)]
        public string descricao { get; set; }

        [Column(Name = "_Quantidade", CanBeNull = false)]
        public double quantidade { get; set; }

        [Column(Name = "_UnidadeMedida", CanBeNull = false)]
        public string unidadeMedida { get; set; }
    }
}
