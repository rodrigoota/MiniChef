using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChef.Model
{
    [Table(Name = "tbCategorias")] 
    public class CategoriaModel
    {
        [Column(Name = "_Id", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int id { get; set; }

        [Column(Name = "_Descricao", CanBeNull = false)]
        public string descricao { get; set; }
    }
}
