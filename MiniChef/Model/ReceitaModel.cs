using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChef.Model
{
    [Table(Name = "tbReceitas")] 
    public class ReceitaModel
    {
        [Column(Name = "_Id", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int id { get; set; }

        [Column(Name = "_Nome", CanBeNull = false)]
        public string nome { get; set; }

        [Column(Name = "_Descricao", CanBeNull = false)]
        public string descricao { get; set; }

        [Column(Name = "_Data", CanBeNull = false)]
        public DateTime? data { get; set; }


        [Column(Name = "_Tempo", CanBeNull = false)]
        public int tempo { get; set; }

        [Column(Name = "_Nota", CanBeNull = false)]
        public int nota { get; set; }

        //[Column(Name = "_Categoria", CanBeNull = false)]
        //public string categoria { get; set; }

        [Column(Name = "_Foto", CanBeNull = false)]
        public string foto { get; set; }

        public List<IngredienteModel> ingredientes { get; set; }

        public List<CategoriaModel> categorias { get; set; }
    }
}
