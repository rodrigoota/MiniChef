using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChef.Model
{
    [Table(Name = "tbReceitaCategoria")] 
    public class ReceitaCategoriaModel
    {
        [Column(Name = "_Id", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int id { get; set; }

        [Column(Name = "_IdReceita", CanBeNull = false)]
        public int idReceita { get; set; }

        [Column(Name = "_IdCategoria", CanBeNull = false)]
        public int idCategoria { get; set; }
    }
}
