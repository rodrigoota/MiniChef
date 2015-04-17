using MiniChef.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChef.Data
{
    public class CategoriaDAO
    {
        public static IEnumerable<CategoriaModel> GetCategorias()
        {
            List<CategoriaModel> lista = null;

            lista = new List<CategoriaModel>();

            using (MinichefDbContext db = new MinichefDbContext(MinichefDbContext.ConnectionString))
            {
                var query = db.TabelaCategorias.OrderBy(d => d.id);

                foreach (CategoriaModel categoria in query)
                {
                    lista.Add(categoria);
                }
            }

            return lista;
        }

        internal static int Save(CategoriaModel novaCategoria)
        {
            using (MinichefDbContext db = new MinichefDbContext(MinichefDbContext.ConnectionString))
            {
                db.TabelaCategorias.InsertOnSubmit(novaCategoria);

                db.SubmitChanges();

                return novaCategoria.id;
            }
        }

        internal static void Remove(CategoriaModel categoria)
        {
            using (MinichefDbContext db = new MinichefDbContext(MinichefDbContext.ConnectionString))
            {
                var query = db.TabelaCategorias.Where(d => d.id == categoria.id);

                if (query.Count() > 0)
                {
                    db.TabelaCategorias.DeleteOnSubmit(query.First());

                    db.SubmitChanges();
                }
            }
        }
    }
}
